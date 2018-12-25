using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using libUnpack.FileFormat;
using libUnpack.IO;

namespace libUnpack
{
    /// <summary>
    /// Представляет непосредственно основной формат хранения файлов платформы,
    /// таких как .epf, .erf, .cf, .cfe.
    /// </summary>
    public sealed class V8Container : IDisposable
    {
        /// <summary>
        /// Получает коллекцию файлов внутри контейнера.
        /// </summary>
        public ReadOnlyCollection<V8File> Files
        {
            get
            {
                ThrowIfDisposed();
                return _files.AsReadOnly();
            }
        }

        public const int MaxLength = Page.MaxAddress;

        /// <summary>
        /// Получает основной поток контейнера.
        /// Используется для чтения и записи содержимого контейнера
        /// другими классами библиотеки.
        /// </summary>
        internal Stream MainStream => _baseStream;

        /// <summary>
        /// Размер страницы для нового контейнера.
        /// <para>
        /// Стандартный размер страницы (<see cref="Literals.V8_DEFAULT_PAGE_SIZE"/>) маловат
        /// для большинства записываемых документов. Поэтому для новых контейнеров будем
        /// использовать свой.
        /// </para>
        /// </summary>
        private const int NewContainerPageSize = 4096;

        private int _defaultPageSize;

        private readonly Stream _baseStream;
        private readonly V8ContainerMode _mode;

        private readonly Stream _tocStream;
        private readonly List<V8File> _files;
        private readonly Dictionary<string, V8File> _filesDictionary;

        public V8Container(Stream stream, V8ContainerMode mode)
        {
            _baseStream = stream ?? throw new ArgumentNullException(nameof(stream));
            _defaultPageSize = NewContainerPageSize;

            _mode = mode;

            if (!stream.CanSeek)
            {
                throw new ArgumentException(
                    "Работа с потоками, не поддерживающими операцию Seek, не поддерживается.",
                    nameof(stream)
                );
            }

            switch (mode)
            {
                case V8ContainerMode.Read:
                    {
                        if (!stream.CanRead)
                        {
                            throw new ArgumentException(
                                "Работа с потоками, не поддерживающими операцию Read, не поддерживается.",
                                nameof(stream)
                            );
                        }

                        ReadHeader();

                        var TOC = new V8Document(this);
                        _files = ReadTOC(TOC);
                        _filesDictionary = _files.ToDictionary(file => file.Name);
                    }
                    break;

                case V8ContainerMode.Write:
                    {
                        if (!stream.CanWrite)
                        {
                            throw new ArgumentException(
                                "Работа с потоками, не поддерживающими операцию Write, не поддерживается.",
                                nameof(stream)
                            );
                        }

                        WriteHeader();

                        var TOC = CreateDocument();
                        _tocStream = TOC.Open();
                        _files = new List<V8File>();
                        _filesDictionary = new Dictionary<string, V8File>();
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(mode));
            }
        }

        /// <summary>
        /// Открывает указанный файл-контейнер для чтения.
        /// </summary>
        /// <param name="filename">Путь к файлу-контейнеру.</param>
        /// <returns>Открытый контейнер.</returns>
        public static V8Container Open(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            var stream = File.OpenRead(filename);

            V8Container container;
            try
            {
                container = new V8Container(stream, V8ContainerMode.Read);
            }
            catch
            {
                stream.Dispose();
                throw;
            }

            return container;
        }

        /// <summary>
        /// Создает или перезаписывает указанный файл-контейнер и открывает его для записи.
        /// </summary>
        /// <param name="filename">Путь к файлу-контейнеру.</param>
        /// <returns>Созданный контейнер.</returns>
        public static V8Container Create(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            var stream = File.Create(filename);

            V8Container container;
            try
            {
                container = new V8Container(stream, V8ContainerMode.Write);
            }
            catch
            {
                stream.Dispose();
                throw;
            }

            return container;
        }

        /// <summary>
        /// Получает файл из контейнера по его имени.
        /// </summary>
        /// <param name="name">Имя файла, который необходимо получить из контейнера.</param>
        /// <returns>
        /// Файл с указанным в <paramref name="name"/> именем;
        /// <c><see langword="null"/></c> если такого файла в контейнере не существует.
        /// </returns>
        public V8File GetFile(string name)
        {
            ThrowIfDisposed();

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (_filesDictionary.TryGetValue(name, out var file))
            {
                return file;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Создает файл в контейнере с указанным именем.
        /// </summary>
        /// <param name="name">Имя файла, который необходимо создать в контейнере.</param>
        /// <returns>Созданный файл.</returns>
        public V8File CreateFile(string name)
        {
            ThrowIfDisposed();

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} не может быть пустым.", nameof(name));
            }

            if (_mode == V8ContainerMode.Read)
            {
                throw new InvalidOperationException("Контейнер открыт в режиме чтения. Создание файлов невозможно.");
            }

            if (_filesDictionary.ContainsKey(name))
            {
                throw new InvalidOperationException("Файл с таким именем уже существует.");
            }

            if (_baseStream.Length >= MaxLength)
            {
                throw new InvalidOperationException("Контейнер достиг максимального размера, создание новых файлов невозможно.");
            }

            var file = V8File.Create(this, name);
            file.Address.Write(_tocStream);

            _files.Add(file);
            _filesDictionary.Add(name, file);

            return file;
        }

        /// <summary>
        /// Создает новый документ с вместимостью по-умолчанию
        /// с выделением пространства в контейнере под него.
        /// </summary>
        /// <returns>Созданный документ.</returns>
        internal V8Document CreateDocument()
        {
            return CreateDocument(_defaultPageSize);
        }

        /// <summary>
        /// Создает новый документ с указанной начальной вместимостью
        /// с выделением памяти под него.
        /// </summary>
        /// <param name="capacity">Начальная вместимость документа.</param>
        /// <returns>Созданный документ.</returns>
        internal V8Document CreateDocument(int capacity)
        {
            ThrowIfDisposed();

            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            long address;
            using (var firstPage = AllocatePage(capacity))
            {
                address = firstPage.Address;
            }

            var document = new V8Document(this, (int)address);

            return document;
        }

        /// <summary>
        /// Выделяет свободную страницу в контейнере.
        /// </summary>
        /// <returns></returns>
        internal Page AllocatePage()
        {
            return AllocatePage(_defaultPageSize);
        }

        internal Page AllocatePage(int pageSize)
        {
            ThrowIfDisposed();

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            var pageAddr = _baseStream.Length;

            // TODO: Не писать в поток пустые байты при создании страниц.
            //      Страница всегда размещается в конец контейнера,
            //      потому что при создании страница автоматически выделяет себе место.
            //      Возможно стоит размещать только заголовок страницы, чтобы
            //      не писать лишний раз в поток.
            // TODO: Добавить возможность выделения страниц из пула свободных страниц.
            //      Форма позволяет организовать пул свободных страниц,
            //      но при текущей реализации такая функциональность пока не нужна.
            var page = Page.Create(this, pageAddr, pageSize);
            return page;
        }

        private List<V8File> ReadTOC(V8Document TOC)
        {
            using (var reader = TOC.Open())
            {
                var files = FileAddress.ReadTOC(reader)
                    .Select(addr => V8File.FromStream(this, addr));
                return files.ToList();
            }
        }

        private void ReadHeader()
        {
            _baseStream.Position = 0;

            var header = ContainerHeader.Read(_baseStream);
            _defaultPageSize = header.PageSize;
        }

        private void WriteHeader()
        {
            _baseStream.Position = 0;

            var header = new ContainerHeader(pageSize: _defaultPageSize);
            header.Write(_baseStream);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().ToString());
            }
        }

        #region IDisposable

        private bool _disposed = false;

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _tocStream?.Dispose();
                _baseStream.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
