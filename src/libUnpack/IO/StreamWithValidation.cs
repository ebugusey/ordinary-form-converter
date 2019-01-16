using System;
using System.IO;

namespace libUnpack.IO
{
    internal abstract class StreamWithValidation : Stream
    {
        public sealed override long Length
        {
            get
            {
                ThrowIfDisposed();
                ThrowIfCantSeek();
                return LengthCore;
            }
        }

        public sealed override long Position
        {
            get
            {
                ThrowIfDisposed();
                ThrowIfCantSeek();
                return PositionCore;
            }
            set
            {
                ThrowIfDisposed();
                ThrowIfCantSeek();
                ValidatePosition(value);

                PositionCore = value;
            }
        }

        protected abstract long LengthCore { get; }
        protected abstract long PositionCore { get; set; }

        public sealed override void Flush()
        {
            ThrowIfDisposed();
            FlushCore();
        }

        public sealed override int Read(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();
            ThrowIfCantRead();
            ValidateReadWriteArguments(buffer, offset, count);

            return ReadCore(buffer, offset, count);
        }

        public sealed override long Seek(long offset, SeekOrigin origin)
        {
            ThrowIfDisposed();
            ThrowIfCantSeek();

            var newPosition = GetNewPosition(PositionCore, LengthCore, offset, origin);

            return SeekCore(newPosition);
        }

        public sealed override void SetLength(long value)
        {
            ThrowIfDisposed();
            ThrowIfCantWrite();
            ThrowIfCantSeek();

            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            SetLengthCore(value);
        }

        public sealed override void Write(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();
            ThrowIfCantWrite();
            ValidateReadWriteArguments(buffer, offset, count);

            WriteCore(buffer, offset, count);
        }

        protected abstract void FlushCore();
        protected abstract int ReadCore(byte[] buffer, int offset, int count);
        protected abstract long SeekCore(long newPosition);
        protected abstract void SetLengthCore(long value);
        protected abstract void WriteCore(byte[] buffer, int offset, int count);

        /// <summary>
        /// Проверяет позицию потока при установке через свойство <see cref="Stream.Position"/>.
        /// </summary>
        /// <param name="position">Новая позиция.</param>
        protected static void ValidatePosition(long position)
        {
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Position), "Позиция потока не может быть меньше 0.");
            }
        }

        /// <summary>
        /// Проверяет аргументы передаваемые операциям <see cref="Stream.Read(byte[], int, int)"/>
        /// и <see cref="Stream.Write(byte[], int, int)"/>.
        /// </summary>
        /// <param name="buffer">Буфер, используемый для операций чтения или записи.</param>
        /// <param name="offset">Смещение внутри буфера, начиная с которого будут записываться или читаться байты.</param>
        /// <param name="count">Количество байт, которые нужно прочитать или записать из буфера.</param>
        protected static void ValidateReadWriteArguments(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "Не может быть меньше 0.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Не может быть меньше 0.");
            }

            if (offset + count > buffer.Length)
            {
                throw new ArgumentException($"{nameof(offset)} или {nameof(count)} выходят за пределы {nameof(buffer)}");
            }
        }

        /// <summary>
        /// Вычисляет новую позицию потока для операции <see cref="Stream.Seek(long, SeekOrigin)"/>.
        /// </summary>
        /// <param name="position">Текущая позиция потока.</param>
        /// <param name="length">Текущая длина потока.</param>
        /// <param name="offset">Смещение, на которое нужно переместить позицию.</param>
        /// <param name="origin">Позиция, относительно которой, должен сместится поток.</param>
        /// <returns>Новая позиция потока.</returns>
        protected static long GetNewPosition(long position, long length, long offset, SeekOrigin origin)
        {
            long newPosition = 0;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPosition = offset;
                    break;
                case SeekOrigin.Current:
                    newPosition = position + offset;
                    break;
                case SeekOrigin.End:
                    newPosition = length + offset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(origin), $"Неизвестное значение {nameof(SeekOrigin)}.");
            }

            if (newPosition < 0)
            {
                throw new ArgumentException("Попытка передвинуть указатель за пределы потока.");
            }

            return newPosition;
        }

        #region Валидация состояния потока

        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().ToString());
            }
        }

        protected void ThrowIfCantRead()
        {
            if (!CanRead)
            {
                throw new NotSupportedException("Поток не доступен для чтения.");
            }
        }

        protected void ThrowIfCantSeek()
        {
            if (!CanSeek)
            {
                throw new NotSupportedException("Перемещение указателя потока не доступно.");
            }
        }

        protected void ThrowIfCantWrite()
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

            base.Dispose(disposing);

            _disposed = true;
        }

        #endregion
    }
}
