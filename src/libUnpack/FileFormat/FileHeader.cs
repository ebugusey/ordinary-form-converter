using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using libUnpack.Exceptions;

namespace libUnpack.FileFormat
{
    /// <summary>
    /// Представляет формат документа с заголовком файла.
    /// Предоставляет методы для чтения и записи этого документа.
    /// </summary>
    internal readonly struct FileHeader
    {
        /// <summary>
        /// Размер заголовка в байтах без учета длины имени файла.
        /// </summary>
        public const int SizeWithoutName =
            sizeof(long) + // CreatedAt
            sizeof(long) + // LastModified
            sizeof(int) + // Reserved
            sizeof(int); // еще одно зарезервированное значение, которое идет после имени и читается вместе с ним

        /// <summary>
        /// Размер заголовка в байтах.
        /// </summary>
        public int Size => GetSize(Name);

        /// <summary>
        /// Дата и время создания файла.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Дата и время последней модификации файла.
        /// </summary>
        public DateTime LastModified { get; }

        /// <summary>
        /// Зарезервированное поле.
        /// </summary>
        public int Reserved { get; }

        /// <summary>
        /// Имя файла.
        /// </summary>
        public string Name => _name ?? string.Empty;

        private const string NameLastChars = "\0\0";
        private static readonly Encoding NameEncoding = Encoding.Unicode;

        private readonly string _name;

        /// <summary>
        /// Инициализирует заголовок указанными значениями.
        /// Зарезервированные поля инициализировать нельзя,
        /// мы не знаем для чего они нужны и на текущей момент они
        /// всегда имеют значение 0.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <param name="createdAt">Дата и время создания файла.</param>
        /// <param name="lastModified">Дата и время последнего изменения файла.</param>
        public FileHeader(string name, DateTime createdAt, DateTime lastModified)
            : this(
                  name,
                  createdAt,
                  lastModified,
                  reserved: 0
            )
        {
        }

        private FileHeader(string name, DateTime createdAt, DateTime lastModified, int reserved)
        {
            Debug.Assert(reserved == 0);

            _name = name ?? throw new ArgumentNullException(nameof(name));
            CreatedAt = createdAt;
            LastModified = lastModified;
            Reserved = reserved;
        }

        /// <summary>
        /// Рассчитывает размер заголовка с учетом длины имени файла.
        /// Длина имени является переменным значением и заранее узнать размер
        /// заголовка, не зная размера имени, нельзя.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <returns>Размер заголовка с учетом имени файла в байтах.</returns>
        public static int GetSize(string name)
        {
            return SizeWithoutName + name.Length * 2; // длина имени дважды, потому что это UTF16
        }

        /// <summary>
        /// Читает заголовок из указанного потока.
        /// </summary>
        /// <param name="input">Поток документа с заголовком файла.</param>
        /// <returns>Прочитанный заголовок файла.</returns>
        public static FileHeader Read(Stream input)
        {
            Debug.Assert(input != null);
            Debug.Assert(input.CanRead);

            using (var reader = new BinaryReader(input, NameEncoding, leaveOpen: true))
            {
                var creationTime = ReadTime(reader, nameof(CreatedAt));
                var lastModified = ReadTime(reader, nameof(LastModified));
                int reserved = reader.ReadInt32();
                var name = ReadName(reader);

                FileHeader header;
                try
                {
                    header = new FileHeader(
                        name,
                        creationTime,
                        lastModified,
                        reserved
                    );
                }
                catch (ArgumentException ex)
                {
                    throw new InvalidFileHeader($"{ex.ParamName} содержит некорректные данные.", ex);
                }

                return header;
            }
        }

        /// <summary>
        /// Записывает заголовок в указанный поток.
        /// </summary>
        /// <param name="output">Поток документа с заголовком файла.</param>
        public void Write(Stream output)
        {
            Debug.Assert(output != null);
            Debug.Assert(output.CanWrite);

            using (var writer = new BinaryWriter(output, NameEncoding, leaveOpen: true))
            {
                WriteTime(writer, CreatedAt);
                WriteTime(writer, LastModified);
                writer.Write(Reserved);
                WriteName(writer, Name);
            }
        }

        private static DateTime ReadTime(BinaryReader reader, string timeName)
        {
            long temp;
            try
            {
                temp = reader.ReadInt64();
            }
            catch (EndOfStreamException ex)
            {
                throw new InvalidFileHeader("Достигнут конец потока прежде чем заголовок был прочитан полностью.", ex);
            }

            DateTime time;
            try
            {
                time = V8TimeToDateTime(temp);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidFileHeader($"{temp} выходит за пределы возможных значений даты/времени в свойстве {timeName}.", ex);
            }

            return time;
        }

        private static void WriteTime(BinaryWriter writer, DateTime value)
        {
            long temp = DateTimeToV8Time(value);
            writer.Write(temp);
        }

        private static string ReadName(BinaryReader reader)
        {
            // Стандартное имя файла в контейнере не превышает 40 символов,
            // так как обычно это GUID + постфикс.
            // Берем размер буфера с запасом, чтобы в большинстве случаев
            // строка была прочитана за один раз.
            const int bufSize = 64;

            var buf = new char[bufSize];
            var sb = new StringBuilder(bufSize);

            while (true)
            {
                var charsRead = reader.Read(buf, 0, bufSize);
                if (charsRead == 0)
                {
                    break;
                }

                sb.Append(buf, 0, charsRead);
            }

            // Имя файла идет не совсем до конца. После имени файла еще идет (int)0.
            // Но так как для его обработки нужно откатывать поток, будем считать
            // его частью строки.
            const string expectedLastChars = NameLastChars;
            if (sb.Length < expectedLastChars.Length)
            {
                throw new InvalidFileHeader("После имени файла должен идти (int)0, но длина документа не позволяет его прочитать.");
            }

            var lastChars = new char[expectedLastChars.Length];
            sb.CopyTo(sb.Length - lastChars.Length, lastChars, 0, lastChars.Length);

            if (expectedLastChars != new string(lastChars))
            {
                var bytes = NameEncoding.GetBytes(lastChars);
                var value = BitConverter.ToInt32(bytes, 0);
                throw new InvalidFileHeader($"После имени файла должен идти (int)0, а не (int){value}.");
            }

            sb.Remove(sb.Length - lastChars.Length, lastChars.Length);

            return sb.ToString();
        }

        private static void WriteName(BinaryWriter writer, string value)
        {
            var buf = value.ToCharArray();
            writer.Write(buf);
            writer.Write(NameLastChars.ToCharArray());
        }

        private static DateTime V8TimeToDateTime(long value)
        {
            return new DateTime(ticks: value * 1000);
        }

        private static long DateTimeToV8Time(DateTime value)
        {
            return value.Ticks / 1000;
        }

        #region Object

        public override string ToString()
        {
            return $"{nameof(FileHeader)} (name: {Name}; createdAd: {CreatedAt}; lastModified: {LastModified})";
        }

        #endregion
    }
}
