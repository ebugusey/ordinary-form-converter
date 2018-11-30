using System;
using System.IO;
using System.Diagnostics;
using libUnpack.FileFormat;

namespace libUnpack.IO
{
    /// <summary>
    /// Представляет цепочку страниц документа.
    /// Вспомогательный класс для управления страницами в <see cref="DocumentStream"/>.
    /// </summary>
    internal class Page : IDisposable
    {
        /// <summary>
        /// Стартовая позиция страницы внутри документа.
        /// </summary>
        public int Start { get; private set; }

        /// <summary>
        /// Конечная позиция страницы внутри документа.
        /// </summary>
        public int End => Start + _header.PageSize;

        /// <summary>
        /// Текущая позиция <see cref="Stream"/> относительно документа.
        /// Может принимать значения между <see cref="Start"/> и <see cref="End"/>.
        /// </summary>
        public int DocumentPosition
        {
            get
            {
                ThrowIfDisposed();

                return Start + (int)_pageStream.Position;
            }
            set
            {
                ThrowIfDisposed();

                if (value < Start || value > End)
                {
                    throw new ArgumentOutOfRangeException(nameof(DocumentPosition));
                }

                _pageStream.Position = value - Start;
            }
        }

        /// <summary>
        /// Поток для чтения и записи содержимого страницы.
        /// </summary>
        public PageStream Stream => _pageStream;

        /// <summary>
        /// Адрес страницы, позиция внутри потока контейнера.
        /// </summary>
        public long Address => _startInSuperStream;

        /// <summary>
        /// Размер содержимого документа. Имеет смысл только для первой страницы.
        /// </summary>
        public int DataSize {
            get
            {
                ThrowIfDisposed();

                return _header.DataSize;
            }
            set
            {
                ThrowIfDisposed();

                _header = new PageHeader(_header, dataSize: value);
                WriteHeader();
            }
        }

        /// <summary>
        /// Определяет, является ли страница первой страницей в цепочке.
        /// </summary>
        public bool IsFirstPage => _prevPage == null;

        /// <summary>
        /// Получает предыдущую страницу в цепочке.
        /// </summary>
        public Page Prev
        {
            get
            {
                ThrowIfDisposed();

                return _prevPage;
            }
        }

        /// <summary>
        /// Получает следующую страницу в цепочке.
        /// </summary>
        public Page Next
        {
            get
            {
                ThrowIfDisposed();

                if (_nextPage == null)
                {
                    if (!_header.IsLastPage)
                    {
                        _nextPage = FromPreviousPage(this);
                    }
                }

                return _nextPage;
            }
        }

        private Stream SuperStream => _container.MainStream;
        private long HeaderPosition => _startInSuperStream;
        private long DataPosition => _startInSuperStream + PageHeader.Size;

        private readonly V8Container _container;
        private readonly long _startInSuperStream;

        private PageHeader _header;
        private readonly PageStream _pageStream;

        private Page _prevPage;
        private Page _nextPage;

        private Page(V8Container container, long start, PageHeader header, int startInDocument = 0)
        {
            Debug.Assert(container != null);
            Debug.Assert(start >= 0);
            Debug.Assert(startInDocument >= 0);
            Debug.Assert(header.PageSize > 0);

            _container = container;
            _startInSuperStream = start;

            _header = header;

            Start = startInDocument;

            _pageStream = new PageStream(SuperStream, DataPosition, _header.PageSize);
        }

        private Page(Page prevPage, long start, PageHeader header)
            : this(prevPage._container, start, header, startInDocument: prevPage.End)
        {
            Debug.Assert(prevPage != null);

            _prevPage = prevPage;
        }

        #region Фабрики для создания экземпляров страниц

        /// <summary>
        /// Создает новую страницу в указанном контейнере и выделяет под неё пространство.
        /// </summary>
        /// <param name="container">Контейнер, в котором создается страница.</param>
        /// <param name="start">Позиция страницы в потоке контейнера.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Созданная страница.</returns>
        public static Page Create(V8Container container, long start, int pageSize)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            var header = new PageHeader(pageSize: pageSize);

            var page = new Page(container, start, header);
            page.Allocate();

            return page;
        }

        /// <summary>
        /// Читает заголовок страницы из потока и инициализирует на его основании
        /// страницу.
        /// </summary>
        /// <param name="container">Контейнер, которому принадлежит страница.</param>
        /// <param name="start">Позиция страницы в потоке контейнера.</param>
        /// <returns>Инициализированная страница.</returns>
        public static Page FromStream(V8Container container, long start)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            var stream = container.MainStream;

            stream.Position = start;
            var header = PageHeader.Read(stream);

            var page = new Page(container, start, header);

            return page;
        }

        /// <summary>
        /// Находит и читает заголовок страницы из потока на основании данных предыдущей страницы
        /// в цепочке.
        /// Прицепляет инициализированную страницу в конец цепочки.
        /// </summary>
        /// <param name="prevPage">Предыдущая страница, из которой можно получить данные для следующей страницы.</param>
        /// <returns>Инициализированная страница.</returns>
        private static Page FromPreviousPage(Page prevPage)
        {
            var stream = prevPage.SuperStream;
            var start = prevPage._header.NextPageAddr;

            stream.Position = start;
            var header = PageHeader.Read(stream);

            var page = new Page(
                prevPage,
                start,
                header
            );

            return page;
        }

        #endregion

        #region Работа с цепочкой страниц

        /// <summary>
        /// Ищет страницу, в которой есть указанная позиция документа, в цепочке страниц.
        /// </summary>
        /// <param name="page">Одна из страниц цепочки, в которой нужно осуществить поиск.</param>
        /// <param name="position">Искомая позиция документа.</param>
        /// <returns>Найденная страница или <c><see langword="null"/></c>, если ничего не найдено.</returns>
        public static Page FindPosition(Page page, int position)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            if (page.HasPosition(position))
            {
                return page;
            }

            Page result = null;
            if (page.Prev != null)
            {
                result = FindPosition(page.Prev, position);
            }

            if (result == null && page.Next != null)
            {
                result = FindPosition(page.Next, position);
            }

            return result;
        }

        /// <summary>
        /// Находит последнюю страницу в цепочке.
        /// </summary>
        /// <param name="page">Одна из страниц цепочки, в которой нужно осуществить поиск.</param>
        /// <returns>Последняя страница в цепочке.</returns>
        public static Page LastPage(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            var currentPage = page;
            while (currentPage.Next != null)
            {
                currentPage = currentPage.Next;
            }

            Debug.Assert(currentPage != null);

            return currentPage;
        }

        #endregion

        /// <summary>
        /// Определяет есть ли указанная позиция документа в странице.
        /// </summary>
        /// <param name="position">Позиция документа.</param>
        /// <returns>Признак существования указанной позиция в странице.</returns>
        public bool HasPosition(int position)
        {
            return position >= Start && position <= End;
        }

        /// <summary>
        /// Создает следующую страницу в цепочке.
        /// Новые страницы могут быть созданы только в конце цепочки.
        /// </summary>
        /// <returns>Созданная странице.</returns>
        public Page CreateNextPage()
        {
            ThrowIfDisposed();

            if (Next != null)
            {
                throw new InvalidOperationException("Новые страницы можно создавать только в конце цепочки.");
            }

            _nextPage = _container.AllocatePage();
            _nextPage.Start = End;
            _nextPage._prevPage = this;

            var nextPageAddr = (int)_nextPage.Address;
            _header = new PageHeader(_header, nextPageAddr: nextPageAddr);
            WriteHeader();

            return _nextPage;
        }

        private void Allocate()
        {
            WriteHeader();
            ErasePageStream();
        }

        private void WriteHeader()
        {
            var stream = SuperStream;
            stream.Position = HeaderPosition;

            _header.Write(stream);
        }

        private void ErasePageStream()
        {
            var size = _header.PageSize;
            var zeroBuf = new byte[size];

            _pageStream.Position = 0;
            _pageStream.Write(zeroBuf, 0, size);
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

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            // Сразу задаем признак того, что ресурсы освобождены,
            // потому что при освобождении одной страницы,
            // освобождается вся цепочка, и Dispose() может быть вызван повторно
            // до того как этот флаг установлен.
            _disposed = true;

            if (disposing)
            {
                _pageStream.Dispose();

                _prevPage?.Dispose();
                _nextPage?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
