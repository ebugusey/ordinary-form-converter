using System;
using System.IO;
using System.Diagnostics;

namespace libUnpack.IO
{
    /// <summary>
    /// Поток, реализующий чтение и запись данных страницы документа.
    /// Страница имеет фиксированный размер, поэтому изменить
    /// длину потока нельзя.
    /// </summary>
    internal sealed class PageStream : StreamWithValidation
    {
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
        /// Не может быть больше длины потока, даже если поток поддерживает запись.
        /// </summary>
        protected override long PositionCore
        {
            get => _position;
            set
            {
                if (value > _length)
                {
                    throw CantChangeLengthException();
                }

                _position = (int)value;
            }
        }

        private bool EndOfPage => _position == _length;

        private int _position;
        private readonly int _length;

        private readonly Stream _superStream;
        private readonly long _startInSuperStream;

        /// <summary>
        /// Инициализирует новый экземпляр потока с использованием указанного
        /// базового потока, положения страницы внутри этого потока и размера страницы.
        /// </summary>
        /// <param name="superStream">Поток контейнера, в котором размещена страница.</param>
        /// <param name="startPosition">Позиция страницы в потоке контейнера.</param>
        /// <param name="pageSize">Размер страницы (длина потока страницы).</param>
        public PageStream(Stream superStream, long startPosition, int pageSize)
        {
            if (superStream == null)
            {
                throw new ArgumentNullException(nameof(superStream));
            }
            if (!superStream.CanSeek)
            {
                throw new ArgumentException("Поток не поддерживает перемещение указателя.", nameof(superStream));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            _superStream = superStream;
            _startInSuperStream = startPosition;

            CanRead = _superStream.CanRead;
            CanWrite = _superStream.CanWrite;

            _position = 0;
            _length = pageSize;
        }

        /// <summary>
        /// Сбрасывает буфер основного потока контейнера.
        /// </summary>
        protected override void FlushCore()
        {
            _superStream.Flush();
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
            if (EndOfPage)
            {
                return 0;
            }

            SyncSuperStreamPosition();

            int remaining = Math.Min(
                count,
                _length - _position
            );

            var bytesRead = _superStream.Read(buffer, offset, remaining);
            Debug.Assert(bytesRead >= 0);

            bool endOfSuperStream = (bytesRead == 0);

            _position += bytesRead;
            Debug.Assert(_position >= 0 && _position <= _length);

            if (endOfSuperStream && !EndOfPage)
            {
                // Перед выбросом исключения позиция перематывается назад,
                // так как по контракту поток не должен менять позицию,
                // если возникло исключение при чтении.
                _position -= bytesRead;
                throw new IOException("Неожиданный конец потока.");
            }

            return bytesRead;
        }

        /// <summary>
        /// Перемещает указатель потока.
        /// </summary>
        /// <param name="newPosition">Новая позиция указателя.</param>
        /// <returns>Новая позиция указателя.</returns>
        protected override long SeekCore(long newPosition)
        {
            if (newPosition == _position)
            {
                return newPosition;
            }

            // Страница имеет фиксированный размер.
            if (newPosition > _length)
            {
                newPosition = _length;
            }

            _position = (int)newPosition;
            Debug.Assert(_position >= 0 && _position <= _length);

            return newPosition;
        }

        /// <summary>
        /// Страница имеет фиксированный размер, поэтому эта операция
        /// всегда вызывает исключение <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="value">Новая длина потока.</param>
        protected override void SetLengthCore(long value)
        {
            throw CantChangeLengthException();
        }

        /// <summary>
        /// Записывает данные из указанного буфера в поток.
        /// <para>
        /// Страница имеет фиксированный размер, поэтому при попытке записать
        /// количество байт больше, чем поток может вместить, вызывается исключение <see cref="InvalidOperationException"/>.
        /// </para>
        /// </summary>
        /// <param name="buffer">Массив, из которого записываются байты в поток.</param>
        /// <param name="offset">Смещение в <paramref name="buffer"/>, с которого нужно взять байты для записи в поток.</param>
        /// <param name="count">Количество байт, которое нужно записать в поток.</param>
        protected override void WriteCore(byte[] buffer, int offset, int count)
        {
            int remaining = _length - _position;
            if (remaining < count)
            {
                throw CantChangeLengthException();
            }

            SyncSuperStreamPosition();

            _superStream.Write(buffer, offset, count);
            _position += count;

            Debug.Assert(_position >= 0 && _position <= _length);
        }

        /// <summary>
        /// Записывает только те данные, которые помещаются в поток.
        /// </summary>
        /// <remarks>
        /// Стандартная реализация <see cref="Stream.Writer(byte[], int, int)"/> должна записать все данные,
        /// которые ей переданы и увеличить размер потока, если это нужно.
        /// Так как страница имеет фиксированный размер <see cref="Write(byte[], int, int)"/> этого сделать
        /// не может и кидает исключение.
        /// Этот метод записывает только то, что помещается в поток и возвращает количество записанных байт.
        /// Если достигнут конец потока и записать больше ничего нельзя, он возвращает 0.
        /// </remarks>
        /// <param name="buffer">Массив, из которого записываются байты в поток.</param>
        /// <param name="offset">Смещение в <paramref name="buffer"/>, с которого нужно взять байты для записи в поток.</param>
        /// <param name="count">Количество байт, которое нужно записать в поток.</param>
        /// <returns>Количество байт, записанных в поток.</returns>
        public int WriteWhatYouCan(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();
            ThrowIfCantWrite();

            ValidateReadWriteArguments(buffer, offset, count);

            if (EndOfPage)
            {
                return 0;
            }

            int remaining = Math.Min(
                count,
                _length - _position
            );

            WriteCore(buffer, offset, remaining);

            return remaining;
        }

        private void SyncSuperStreamPosition()
        {
            var expecteSuperPosition = _startInSuperStream + _position;
            if (_superStream.Position != expecteSuperPosition)
            {
                _superStream.Seek(expecteSuperPosition, SeekOrigin.Begin);
            }

            if (_superStream.Position != expecteSuperPosition)
            {
                throw new IOException("Не удалось установить позицию базового потока.");
            }
        }

        private InvalidOperationException CantChangeLengthException()
        {
            return new InvalidOperationException("Страница имеет фиксированный размер.");
        }

        #region IDisposable

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            base.Dispose(disposing);

            _disposed = true;
        }

        #endregion
    }
}
