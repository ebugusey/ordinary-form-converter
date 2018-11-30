using System;
using System.IO;
using System.Diagnostics;
using libUnpack.IO.Utils;

namespace libUnpack.IO
{
    /// <summary>
    /// Поток, реализующий чтение и запись данных документа.
    /// </summary>
    internal sealed class DocumentStream : Stream
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
        public override long Length
        {
            get
            {
                ThrowIfDisposed();

                return _length;
            }
        }

        /// <summary>
        /// Текущая позиция указателя в потоке.
        /// </summary>
        public override long Position {
            get
            {
                ThrowIfDisposed();

                return _position;
            }
            set
            {
                ThrowIfDisposed();
                StreamUtils.ValidatePosition(value);

                if (value > _length)
                {
                    ThrowIfCantWrite();
                }

                SeekCore(value);
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
        public override void Flush()
        {
            ThrowIfDisposed();

            _firstPage.Stream.Flush();
        }

        /// <summary>
        /// Читает данные из потока в указанный буфер.
        /// </summary>
        /// <param name="buffer">Массив для сохранения прочитанных байтов.</param>
        /// <param name="offset">Смещение в <paramref name="buffer"/>, с которого нужно разместить прочитанные байты.</param>
        /// <param name="count">Количество байт, которое нужно прочитать из потока.</param>
        /// <returns>Количество прочитанных байт.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();
            ThrowIfCantRead();

            StreamUtils.ValidateReadWriteArguments(buffer, offset, count);

            if (_position == _length)
            {
                return 0;
            }

            var remaining = Math.Min(
                count,
                _length - _position
            );

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
        /// Перемещает указатель потока.
        /// </summary>
        /// <param name="offset">
        /// Позиция относительно <paramref name="origin"/>, куда нужно переместить указатель.
        /// </param>
        /// <param name="origin">
        /// Ориентир, относительно которого указан <paramref name="offset"/>.
        /// </param>
        /// <returns>Новая позиция указателя.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            ThrowIfDisposed();

            long newPosition = StreamUtils.GetNewPosition(_position, _length, offset, origin);

            if (newPosition == _position)
            {
                return _position;
            }

            if (newPosition > _length && !CanWrite)
            {
                newPosition = _length;
            }

            SeekCore(newPosition);

            return newPosition;
        }

        /// <summary>
        /// Устанавливает новую длину потока.
        /// </summary>
        /// <param name="value">Новая длина потока.</param>
        public override void SetLength(long value)
        {
            ThrowIfDisposed();
            ThrowIfCantWrite();

            if (value == _length)
            {
                return;
            }

            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var currentPage = _currentPage;
            ChangePage((int)value, createIfDoesntExist: true);
            _currentPage = currentPage;

            ChangeLength((int)value);
        }

        /// <summary>
        /// Записывает данные из указанного буфера в поток.
        /// </summary>
        /// <param name="buffer">Массив, из которого записываются байты в поток.</param>
        /// <param name="offset">Смещение в <paramref name="buffer"/>, с которого нужно взять байты для записи в поток.</param>
        /// <param name="count">Количество байт, которое нужно записать в поток.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();
            ThrowIfCantWrite();

            StreamUtils.ValidateReadWriteArguments(buffer, offset, count);

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
            if (_length < _position)
            {
                ChangeLength(_position);
            }
        }

        private void SeekCore(long newPosition)
        {
            if (newPosition > MaxLength)
            {
                throw MaxLengthReachedException();
            }

            int position = unchecked((int)newPosition);

            ChangePage(position, createIfDoesntExist: CanWrite);

            _currentPage.DocumentPosition = position;
            _position = position;
        }

        private void ChangeLength(int newLength)
        {
            _firstPage.DataSize = newLength;
            _length = newLength;
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

        private IOException MaxLengthReachedException()
        {
            return new IOException($"Достигнут максимальный размер потока: {MaxLength}.");
        }

        #region Валидация состояния потока

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().ToString());
            }
        }

        private void ThrowIfCantRead()
        {
            if (!CanRead)
            {
                throw new NotSupportedException("Поток не доступен для чтения.");
            }
        }

        private void ThrowIfCantWrite()
        {
            if (!CanWrite)
            {
                throw new NotSupportedException("Поток не доступен для записи.");
            }
        }

        #endregion

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
