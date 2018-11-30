using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using libUnpack.Exceptions;

namespace libUnpack.FileFormat
{
    /// <summary>
    /// Представляет заголовок контейнера.
    /// Предоставляет методы для чтения и записи заголовка контейнера.
    /// </summary>
    internal struct ContainerHeader
    {
        /// <summary>
        /// Размер заголовка в байтах.
        /// </summary>
        public const int Size =
            sizeof(int) + // NextPageAddr
            sizeof(int) + // PageSize
            sizeof(int) + // Revision
            sizeof(int); // Reserved

        /// <summary>
        /// Адрес первой свободной страницы в контейнере,
        /// или <see cref="Literals.V8_LAST_PAGE"/>, если таких страниц
        /// в контейнере нет.
        /// </summary>
        public int NextPageAddr => _initialized ? _nextPageAddr : DefaultPageAddr;

        /// <summary>
        /// Размер страницы по умолчанию.
        /// </summary>
        public int PageSize => _initialized ? _pageSize : DefaultPageSize;

        /// <summary>
        /// Ревизия/версия содержимого контейнера.
        /// </summary>
        public readonly int Revision;

        /// <summary>
        /// Зарезервированное поле.
        /// </summary>
        public readonly int Reserved;

        private const int DefaultPageAddr = Literals.V8_LAST_PAGE;
        private const int DefaultPageSize = Literals.V8_DEFAULT_PAGE_SIZE;

        private readonly int _nextPageAddr;
        private readonly int _pageSize;

        private readonly bool _initialized;

        /// <summary>
        /// Инициализирует заголовок указанными значениями.
        /// Устанавливаются только <see cref="NextPageAddr"/> и <see cref="PageSize"/>,
        /// так как ревизия и зарезервированное поле не важны для формата.
        /// </summary>
        /// <param name="nextPageAddr">Адрес первой свободной страницы в контейнере.</param>
        /// <param name="pageSize">Размер страницы по умолчанию.</param>
        public ContainerHeader(
            int nextPageAddr = DefaultPageAddr,
            int pageSize = DefaultPageSize)
            : this(
                nextPageAddr,
                pageSize,
                revision: 0,
                reserved: 0
            )
        {
        }

        private ContainerHeader(int nextPageAddr, int pageSize, int revision, int reserved)
        {
            if (nextPageAddr < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nextPageAddr));
            }

            if (pageSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            // Reserved должно быть равно 0, но в реальной жизни
            // может и не быть.
            Debug.Assert(reserved == 0);

            _nextPageAddr = nextPageAddr;
            _pageSize = pageSize;
            Revision = revision;
            Reserved = reserved;

            _initialized = true;
        }

        /// <summary>
        /// Читает заголовок из указанного потока.
        /// </summary>
        /// <param name="input">Поток контейнера, из которого нужно прочитать заголовок.</param>
        /// <returns>Прочитанный заголовок.</returns>
        public static ContainerHeader Read(Stream input)
        {
            Debug.Assert(input != null);
            Debug.Assert(input.CanRead);

            int nextPageAddr;
            int pageSize;
            int revision;
            int reserved;

            using (var reader = new BinaryReader(input, Encoding.Default, leaveOpen: true))
            {
                try
                {
                    nextPageAddr = reader.ReadInt32();
                    pageSize = reader.ReadInt32();
                    revision = reader.ReadInt32();
                    reserved = reader.ReadInt32();
                }
                catch (EndOfStreamException)
                {
                    throw new InvalidContainerHeader();
                }
            }

            ContainerHeader header;
            try
            {
                header = new ContainerHeader(
                    nextPageAddr,
                    pageSize,
                    revision,
                    reserved
                );
            }
            catch (Exception ex)
            {
                throw new InvalidContainerHeader(ex);
            }

            return header;
        }

        /// <summary>
        /// Записывает заголовок в указанный поток.
        /// </summary>
        /// <param name="output">Поток контейнера, в который нужно записать заголовок.</param>
        public void Write(Stream output)
        {
            Debug.Assert(output != null);
            Debug.Assert(output.CanWrite);

            using (var writer = new BinaryWriter(output, Encoding.Default, leaveOpen: true))
            {
                writer.Write(NextPageAddr);
                writer.Write(PageSize);
                writer.Write(Revision);
                writer.Write(Reserved);
            }
        }

        #region Object

        public override string ToString()
        {
            return $"{nameof(ContainerHeader)} (next page: 0x{NextPageAddr:x8}; page size: {PageSize}; rev: {Revision})";
        }

        #endregion
    }
}
