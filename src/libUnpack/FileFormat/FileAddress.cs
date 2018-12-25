using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using libUnpack.Exceptions;

namespace libUnpack.FileFormat
{
    /// <summary>
    /// Представляет структуру для хранения адресов заголовка и данных файла.
    /// Является частью документа-оглавления контейнера.
    /// Предоставляет методы для чтения и записи как документа-оглавления целиком,
    /// так и единичных его записей.
    /// </summary>
    internal struct FileAddress
    {
        /// <summary>
        /// Размер структуры адреса в байтах.
        /// </summary>
        public const int Size =
            sizeof(int) + // HeaderAddr
            sizeof(int) + // DataAddr
            sizeof(int);  // Signature

        /// <summary>
        /// Адрес документа с заголовком файла.
        /// </summary>
        public int HeaderAddr { get; }

        /// <summary>
        /// Адрес документа с данными файла.
        /// </summary>
        public int DataAddr { get; }

        /// <summary>
        /// Некая сигнатура. Всегда <see cref="Literals.V8_FF_SIGNATURE"/>.
        /// </summary>
        public int Signature => _explicitlyConstructed ? _signature : V8Signature;

        private const int V8Signature = Literals.V8_FF_SIGNATURE;

        private static readonly Encoding AnyEncoding = Encoding.ASCII;

        private readonly int _signature;

        private readonly bool _explicitlyConstructed;

        /// <summary>
        /// Инициализирует структуру адреса указанными значениями.
        /// <see cref="Signature"/> установить нельзя, так как это значение не должно меняться.
        /// </summary>
        /// <param name="headerAddr">Адрес заголовка файла.</param>
        /// <param name="dataAddr">Адрес данных файла.</param>
        public FileAddress(int headerAddr, int dataAddr)
            : this(headerAddr, dataAddr, V8Signature)
        {
        }

        private FileAddress(int headerAddr, int dataAddr, int signature)
        {
            if (headerAddr < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(headerAddr));
            }

            if (dataAddr < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dataAddr));
            }

            if (signature != V8Signature)
            {
                throw new ArgumentException(
                    $"Получена некорректная сигнатура адреса файла: 0x{signature:x8}.\n" +
                    $"Сигнатура файла неизменна и всегда должна быть 0x{V8Signature:x8}",
                    nameof(signature)
                );
            }

            HeaderAddr = headerAddr;
            DataAddr = dataAddr;
            _signature = signature;

            _explicitlyConstructed = true;
        }

        /// <summary>
        /// Читает содержимое документа-оглавления в виде списка структур адреса файла.
        /// Поток читается до конца, ожидается что весь документ-оглавление состоит только
        /// из адресов.
        /// </summary>
        /// <param name="input">Поток документа-оглавления.</param>
        /// <returns>Список прочитанных адресов.</returns>
        public static List<FileAddress> ReadToC(Stream input)
        {
            Debug.Assert(input != null);
            Debug.Assert(input.CanRead);

            var tableOfContents = new List<FileAddress>();
            using (var reader = new BinaryReader(input, AnyEncoding, leaveOpen: true))
            {
                while (Read(reader, out var fileAddress))
                {
                    tableOfContents.Add(fileAddress);
                }
            }

            return tableOfContents;
        }

        /// <summary>
        /// Записывает список адресов в поток, тем самым формируя документ-оглавление.
        /// </summary>
        /// <param name="output">Поток документа-оглавления.</param>
        /// <param name="tableOfContents">Список адресов, который нужно записать в документ-оглавление.</param>
        public static void WriteToC(Stream output, IEnumerable<FileAddress> tableOfContents)
        {
            Debug.Assert(output != null);
            Debug.Assert(tableOfContents != null);
            Debug.Assert(output.CanWrite);

            using (var writer = new BinaryWriter(output, AnyEncoding, leaveOpen: true))
            {
                foreach (var fileAddr in tableOfContents)
                {
                    fileAddr.Write(writer);
                }
            }
        }

        /// <summary>
        /// Записывает адрес в поток.
        /// </summary>
        /// <param name="output">Поток документа-оглавления.</param>
        public void Write(Stream output)
        {
            Debug.Assert(output != null);
            Debug.Assert(output.CanWrite);

            using (var writer = new BinaryWriter(output, AnyEncoding, leaveOpen: true))
            {
                Write(writer);
            }
        }

        private static bool Read(BinaryReader reader, out FileAddress fileAddress)
        {
            var buf = reader.ReadBytes(Size);
            if (buf.Length == 0)
            {
                fileAddress = default;
                return false;
            }
            else if (buf.Length < Size)
            {
                throw new InvalidFileAddress("Достигнут конец потока прежде чем адрес файла был прочитан полностью.");
            }

            int headerAddr = BitConverter.ToInt32(buf, 0);
            int dataAddr   = BitConverter.ToInt32(buf, sizeof(int));
            int signature  = BitConverter.ToInt32(buf, 2 * sizeof(int));

            try
            {
                fileAddress = new FileAddress(headerAddr, dataAddr, signature);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidFileAddress($"{ex.ParamName} содержит некорректные данные.", ex);
            }

            return true;
        }

        private void Write(BinaryWriter writer)
        {
            writer.Write(HeaderAddr);
            writer.Write(DataAddr);
            writer.Write(Signature);
        }

        #region Object

        public override string ToString()
        {
            return $"{nameof(FileAddress)} (header: 0x{HeaderAddr:x8}; data: 0x{DataAddr:x8}; signature: 0x{Signature:x8})";
        }

        #endregion
    }
}
