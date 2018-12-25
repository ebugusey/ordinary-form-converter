using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using libUnpack.Exceptions;

namespace libUnpack.FileFormat
{
    /// <summary>
    /// Представляет заголовок страницы документа.
    /// </summary>
    internal struct PageHeader
    {
        /// <summary>
        /// Размер заголовка в байтах.
        /// </summary>
        public const int Size =
            2 * sizeof(byte) + // CRLF
            HexSize +          // DataSize
            sizeof(byte) +     // SPACE
            HexSize +          // PageSize
            sizeof(byte) +     // SPACE
            HexSize +          // NextPageAddr
            sizeof(byte) +     // SPACE
            2 * sizeof(byte);  // CRLF

        /// <summary>
        /// Размер документа в байтах.
        /// Имеет смысл только для первой страницы документа.
        /// </summary>
        public int DataSize { get; }

        /// <summary>
        /// Размер страницы в байтах.
        /// </summary>
        public int PageSize => _explicitlyConstructed ? _pageSize : DefaultPageSize;

        /// <summary>
        /// Адрес следующей страницы в документе.
        /// </summary>
        public int NextPageAddr => _explicitlyConstructed ? _nextPageAddr : DefaultPageAddr;

        /// <summary>
        /// Определяет является ли страница последней в документе.
        /// </summary>
        public bool IsLastPage => NextPageAddr == Literals.V8_LAST_PAGE;

        private const int DefaultDataSize = 0;
        private const int DefaultPageSize = Literals.V8_DEFAULT_PAGE_SIZE;
        private const int DefaultPageAddr = Literals.V8_LAST_PAGE;

        private const byte CR    = 0x0D;
        private const byte LF    = 0x0A;
        private const byte SPACE = 0x20;

        private static readonly byte[] CRLF_SEQ = new[] { CR, LF };
        private static readonly byte[] SPACE_SEQ = new[] { SPACE };

        private const int HexSize = 8;
        private const string HexFormat = "x8";
        private static readonly Encoding HexEncoding = Encoding.ASCII;

        private readonly int _pageSize;
        private readonly int _nextPageAddr;

        private readonly bool _explicitlyConstructed;

        /// <summary>
        /// Инициализирует заголовок страницы указанными значениями.
        /// </summary>
        /// <param name="dataSize">Размер документа в байтах.</param>
        /// <param name="pageSize">Размер страницы в байтах.</param>
        /// <param name="nextPageAddr">Адрес следующей страницы документа.</param>
        public PageHeader(
            int dataSize = DefaultDataSize,
            int pageSize = DefaultPageSize,
            int nextPageAddr = DefaultPageAddr)
        {
            if (dataSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dataSize));
            }

            if (pageSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            if (nextPageAddr < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nextPageAddr));
            }

            DataSize = dataSize;
            _pageSize = pageSize;
            _nextPageAddr = nextPageAddr;

            _explicitlyConstructed = true;
        }

        /// <summary>
        /// Инициализирует заголовок страницы значениями из другого заголовка
        /// и заменяет размер документа и адрес следующей страницы, если они указаны.
        /// </summary>
        /// <param name="oldValue">Заголовок, из которого нужно скопировать значения.</param>
        /// <param name="dataSize">Новый размер документа.</param>
        /// <param name="nextPageAddr">Новый адрес следующей страницы.</param>
        public PageHeader(PageHeader oldValue, int? dataSize = null, int? nextPageAddr = null)
            : this(
                  dataSize ?? oldValue.DataSize,
                  oldValue.PageSize,
                  nextPageAddr ?? oldValue.NextPageAddr
            )
        {
        }

        /// <summary>
        /// Читает заголовок из указанного потока.
        /// </summary>
        /// <param name="input">Поток контейнера, из которого нужно прочитать заголовок.</param>
        /// <returns>Прочитанный заголовок.</returns>
        public static PageHeader Read(Stream input)
        {
            Debug.Assert(input != null);
            Debug.Assert(input.CanRead);

            using (var reader = new BinaryReader(input, HexEncoding, leaveOpen: true))
            {
                MatchBytes(reader, CRLF_SEQ);

                int dataSize = ReadHex(reader, nameof(DataSize));
                MatchBytes(reader, SPACE_SEQ);
                int pageSize = ReadHex(reader, nameof(PageSize));
                MatchBytes(reader, SPACE_SEQ);
                int nextPageAddr = ReadHex(reader, nameof(NextPageAddr));
                MatchBytes(reader, SPACE_SEQ);

                MatchBytes(reader, CRLF_SEQ);

                PageHeader header;
                try
                {
                    header = new PageHeader(
                        dataSize,
                        pageSize,
                        nextPageAddr
                    );
                }
                catch (ArgumentException ex)
                {
                    throw new InvalidPageHeader($"{ex.ParamName} содержит некорректные данные.", ex);
                }

                return header;
            }
        }

        /// <summary>
        /// Записывает заголовок в указанный поток.
        /// </summary>
        /// <param name="output">Поток контейнера, в который нужно записать заголовок.</param>
        public void Write(Stream output)
        {
            Debug.Assert(output != null);
            Debug.Assert(output.CanWrite);

            using (var writer = new BinaryWriter(output, HexEncoding, leaveOpen: true))
            {
                writer.Write(CRLF_SEQ);

                WriteHex(writer, DataSize);
                writer.Write(SPACE_SEQ);
                WriteHex(writer, PageSize);
                writer.Write(SPACE_SEQ);
                WriteHex(writer, NextPageAddr);
                writer.Write(SPACE_SEQ);

                writer.Write(CRLF_SEQ);
            }
        }

        private static void MatchBytes(BinaryReader reader, params byte[] expected)
        {
            var buf = reader.ReadBytes(expected.Length);
            if (!buf.SequenceEqual(expected))
            {
                throw new InvalidPageHeader($"Ожидалась последовательность байтов: {expected.ToString()}, а получили: {buf.ToString()}.");
            }
        }

        private static int ReadHex(BinaryReader reader, string hexName)
        {
            var buf = reader.ReadChars(HexSize);
            if (buf.Length < HexSize)
            {
                throw new InvalidPageHeader("Достигнут конец потока прежде чем заголовок был прочитан полностью.");
            }

            var hex = new string(buf);

            int result;
            try
            {
                result = Convert.ToInt32(hex, 16);
            }
            catch (FormatException ex)
            {
                throw new InvalidPageHeader($"Неверный формат шестнадцатеричного значения, представляющего {hexName}.", ex);
            }
            catch (OverflowException ex)
            {
                throw new InvalidPageHeader($"0x{hex} больше максимально возможного для {hexName}.", ex);
            }

            return result;
        }

        private static void WriteHex(BinaryWriter writer, int value)
        {
            var hex = value.ToString(HexFormat);
            var buf = hex.ToCharArray();
            writer.Write(buf);
        }

        #region Object

        public override string ToString()
        {
            return $"{nameof(PageHeader)} (data size: {DataSize}; page size: {PageSize}; next page: 0x{NextPageAddr:x8})";
        }

        #endregion
    }
}
