using System;
using System.IO;
using System.Diagnostics;

namespace libUnpack.IO
{
    /// <summary>
    /// Поток, реализующий чтение и запись данных документа.
    /// </summary>
    internal sealed class DocumentStream : StreamWithValidation
    {
        public const long MaxLength = int.MaxValue;

        /// <summary>
        /// Поток поддерживает чтение.
        /// </summary>
        public override bool CanRead { get;  }

        /// <summary>
        /// Поток поддерживает перемещение указателя потока.
        /// </summary>
        public override bool CanSeek => true;

        /// <summary>
        /// Поток поддерживает запись.
        /// </summary>
        public override bool CanWrite { get;  }

        /// <summary>
        /// Текущая длина потока.
        /// </summary>
        protected override long LengthCore => _length;

        /// <summary>
        /// Текущая позиция указателя в потоке.
        /// </summary>
        protected override long PositionCore
        {
            get => _position;
            set => SeekCore(value);
        }

        private bool EndOfDocument => _position >= _length;

        private int DocumentLength
        {
            get => _length;
            set
            {
                Debug.Assert(value >= 0 && value <= MaxLength);
                _length = value;
                _firstPage.DataSize = value;
            }
        }

        private int _position;
        private int _length;

        private readonly Page _firstPage;
        private Page _currentPage;

        /// <summary>
        /// Инициализирует новый экземпляр потока с использованием первой страницы документа.
        /// </summary>
        /// <param name="firstPage">Первая страница документа.</param>
        public DocumentStream(Page firstPage)
        {
            if (firstPage == null)
            {
                throw new ArgumentNullException(nameof(firstPage));
            }
            if (!firstPage.IsFirstPage)
            {
                throw new ArgumentException("Нужна первая страница в цепочке.", nameof(firstPage));
            }

            _firstPage = firstPage;
            _currentPage = firstPage;

            CanRead = firstPage.Stream.CanRead;
            CanWrite = firstPage.Stream.CanWrite;

            _position = 0;
            _length = firstPage.DataSize;
        }

        /// <summary>
        /// Сбрасывает буфер основного потока контейнера.
        /// </summary>
        protected override void FlushCore()
        {
            _firstPage.Stream.Flush();
        }

        /// <summary>
        /// Читает данные из потока в указанный буфер.
        /// </summary>
        /// <param name="buffer">Массив для сохранения прочитанных байтов.</param>
        /// <param name="offset">Смещение в <paramref name="buffer"/>, с которого нужно разместить прочитанные байты.</param>
        /// <param name="count">Количество байт, которое нужно прочитать из потока.</param>
        /// <returns>Количество прочитанных байт.</returns>
        protected override int ReadCore(byte[] buffer, int offset, int count)
        {
            if (EndOfDocument)
            {
                return 0;
            }

            var remaining = Math.Min(
                count,
                DocumentLength - _position
            );
            Debug.Assert(remaining >= 0);

            var bytesRead = ReadFromCurrentPage(buffer, offset, remaining);

            bool endOfPage = (bytesRead == 0);
            if (endOfPage)
            {
                if (GoToNextPage())
                {
                    bytesRead = ReadFromCurrentPage(buffer, offset, remaining);
                }
            }

            return bytesRead;
        }

        /// <summary>
        /// Устанавливает новую длину потока.
        /// </summary>
        /// <param name="value">Новая длина потока.</param>
        protected override void SetLengthCore(long value)
        {
            if (value == DocumentLength)
            {
                return;
            }

            if (value > DocumentLength)
            {
                ExpandStream((int)value);
            }

            DocumentLength = (int)value;
        }

        /// <summary>
        /// Записывает данные из указанного буфера в поток.
        /// </summary>
        /// <param name="buffer">Массив, из которого записываются байты в поток.</param>
        /// <param name="offset">Смещение в <paramref name="buffer"/>, с которого нужно взять байты для записи в поток.</param>
        /// <param name="count">Количество байт, которое нужно записать в поток.</param>
        protected override void WriteCore(byte[] buffer, int offset, int count)
        {
            long newPosition = _position + count;
            if (newPosition > MaxLength)
            {
                throw MaxLengthReachedException();
            }

            var remaining = count;
            var currentOffset = offset;

            while (remaining > 0)
            {
                var bytesWritten = WriteToCurrentPage(buffer, currentOffset, remaining);

                remaining -= bytesWritten;
                currentOffset += bytesWritten;

                bool endOfPage = (bytesWritten == 0);
                bool needMorePages = (remaining > 0);
                if (endOfPage && needMorePages)
                {
                    GoToNextPage(createIfDoesntExist: true);
                }
            }

            // Перемещение по страницам автоматически расширяет супер-поток,
            // поэтому можно без зазрения совести просто увеличить длину,
            // если она меньше текущей позиции.
            if (DocumentLength < _position)
            {
                DocumentLength = _position;
            }
        }

        /// <summary>
        /// Перемещает указатель потока.
        /// </summary>
        /// <param name="newPosition">Новая позиция указателя.</param>
        /// <returns>Новая позиция указателя.</returns>
        protected override long SeekCore(long newPosition)
        {
            if (newPosition > MaxLength)
            {
                throw MaxLengthReachedException();
            }

            if (newPosition == _position)
            {
                return newPosition;
            }

            int position = (int)newPosition;

            // При изменении позиции по идее не должны вносится изменения в поток,
            // но так как изменение текущей страницы не влияет на супер-поток,
            // а не на текущий (длина не меняется, данные не записываются),
            // то можно забить на это ради простоты работы со страницами.
            ChangePage(position, createIfDoesntExist: CanWrite);

            _position = position;

            return newPosition;
        }

        #region Операции с текущей страницей

        private int ReadFromCurrentPage(byte[] buffer, int offset, int count)
        {
            SyncCurrentPagePosition();

            var bytesRead = _currentPage.Stream.Read(buffer, offset, count);
            _position = _currentPage.DocumentPosition;

            return bytesRead;
        }

        private int WriteToCurrentPage(byte[] buffer, int offset, int count)
        {
            SyncCurrentPagePosition();

            var bytesWritten = _currentPage.Stream.WriteWhatYouCan(buffer, offset, count);
            _position = _currentPage.DocumentPosition;

            return bytesWritten;
        }

        private void SyncCurrentPagePosition()
        {
            Debug.Assert(_currentPage != null);

            if (_currentPage.DocumentPosition != _position)
            {
                _currentPage.DocumentPosition = _position;
            }
        }

        private bool GoToNextPage(bool createIfDoesntExist = false)
        {
            var nextPage = _currentPage.Next;
            bool nextPageExists = (nextPage != null);

            if (nextPageExists)
            {
                _currentPage = nextPage;
            }
            else if (createIfDoesntExist)
            {
                _currentPage = _currentPage.CreateNextPage();
                nextPageExists = true;
            }

            return nextPageExists;
        }

        private void ChangePage(int position, bool createIfDoesntExist = false)
        {
            var page = Page.FindPosition(_currentPage, position);

            if (page == null && createIfDoesntExist)
            {
                page = Page.LastPage(page);
                do
                {
                    page = page.CreateNextPage();
                } while (!page.HasPosition(position));
            }

            _currentPage = page;
            Debug.Assert(_currentPage != null);
        }

        #endregion

        private void ExpandStream(int newLength)
        {
            // Установка страницы автоматически увеличивает длину потока,
            // но менять страницу нам не надо.
            var temp = _currentPage;
            ChangePage(newLength, createIfDoesntExist: true);
            _currentPage = temp;
        }

        private IOException MaxLengthReachedException()
        {
            return new IOException($"Достигнут максимальный размер потока: {MaxLength}.");
        }

        #region IDisposable

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _firstPage.Dispose();
            }

            _currentPage = null;

            base.Dispose(disposing);

            _disposed = true;
        }

        #endregion
    }
}
