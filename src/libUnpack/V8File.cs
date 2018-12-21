using System;
using System.Diagnostics;
using System.IO;
using libUnpack.FileFormat;

namespace libUnpack
{
    /// <summary>
    /// Представляет файл внутри контейнера платформы.
    /// </summary>
    public sealed class V8File
    {
        /// <summary>
        /// Получает имя файла.
        /// </summary>
        public string Name => _header.Name;

        /// <summary>
        /// Получает время создания файла.
        /// </summary>
        public DateTime CreatedAt => _header.CreatedAt;

        /// <summary>
        /// Получает время последнего изменения файла.
        /// </summary>
        public DateTime LastModified => _header.LastModified;

        /// <summary>
        /// Получает структуру <see cref="FileAddress"/>,
        /// которую необходимо записать в оглавление.
        /// </summary>
        internal FileAddress Address => new FileAddress(_headerDoc.Address, _dataDoc.Address);

        private FileHeader _header;

        private readonly V8Document _headerDoc;
        private readonly V8Document _dataDoc;

        private V8File(V8Container container, FileAddress fileAddress)
        {
            Debug.Assert(container != null);

            _headerDoc = new V8Document(container, fileAddress.HeaderAddr);
            _dataDoc = new V8Document(container, fileAddress.DataAddr);
        }

        private V8File(V8Container container, string name, V8Document headerDoc, V8Document dataDoc)
        {
            _header = new FileHeader(name, DateTime.Now, DateTime.Now);

            _headerDoc = headerDoc;
            _dataDoc = dataDoc;
        }

        /// <summary>
        /// Создает файл с указанным именем в указанном контейнере.
        /// </summary>
        /// <param name="container">Контейнер, в котором нужно создать файл.</param>
        /// <param name="name">Имя создаваемого файла.</param>
        /// <returns>Созданный файл.</returns>
        internal static V8File Create(V8Container container, string name)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var headerSize = FileHeader.GetSize(name);
            var headerDoc = container.CreateDocument(headerSize);
            var contentDoc = container.CreateDocument();

            var file = new V8File(container, name, headerDoc, contentDoc);
            file.WriteHeader();

            return file;
        }

        /// <summary>
        /// Читает файл из указанного контейнера по указанному адресу.
        /// </summary>
        /// <param name="container">Контейнер, из потока которого нужно прочитать файл.</param>
        /// <param name="fileAddress">Структура с адресом заголовка и содержимого файла.</param>
        /// <returns>Прочитанный файл.</returns>
        internal static V8File FromStream(V8Container container, FileAddress fileAddress)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var file = new V8File(container, fileAddress);
            file.ReadHeader();

            return file;
        }

        /// <summary>
        /// Открывает файл для чтения или записи.
        /// </summary>
        /// <returns>Поток для чтения или записи данных файла.</returns>
        public Stream Open()
        {
            return _dataDoc.Open();
        }

        private void ReadHeader()
        {
            using (var stream = _headerDoc.Open())
            {
                _header = FileHeader.Read(stream);
            }
        }

        private void WriteHeader()
        {
            using (var stream = _headerDoc.Open())
            {
                _header.Write(stream);
            }
        }

        #region Object

        public override string ToString()
        {
            return $"{nameof(V8File)} (name: {Name})";
        }

        #endregion
    }
}
