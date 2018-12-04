using System;
using System.IO;

namespace libUnpack.IO.Utils
{
    /// <summary>
    /// Утилиты для работы с потоками.
    /// </summary>
    internal static class StreamUtils
    {
        /// <summary>
        /// Вычисляет новую позицию потока для операции <see cref="Stream.Seek(long, SeekOrigin)"/>.
        /// </summary>
        /// <param name="position">Текущая позиция потока.</param>
        /// <param name="length">Текущая длина потока.</param>
        /// <param name="offset">Смещение, на которое нужно переместить позицию.</param>
        /// <param name="origin">Позиция, относительно которой, должен сместится поток.</param>
        /// <returns>Новая позиция потока.</returns>
        public static long GetNewPosition(long position, long length, long offset, SeekOrigin origin)
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
                    throw new ArgumentException($"Неизвестный {nameof(origin)}.", nameof(origin));
            }

            if (newPosition < 0)
            {
                throw new ArgumentException("Попытка передвинуть указатель за пределы потока.");
            }

            return newPosition;
        }

        /// <summary>
        /// Проверяет аргументы передаваемые операциям <see cref="Stream.Read(byte[], int, int)"/>
        /// и <see cref="Stream.Write(byte[], int, int)"/>.
        /// </summary>
        /// <param name="buffer">Буфер, используемый для операций чтения или записи.</param>
        /// <param name="offset">Смещение внутри буфера, начиная с которого будут записываться или читаться байты.</param>
        /// <param name="count">Количество байт, которые нужно прочитать или записать из буфера.</param>
        public static void ValidateReadWriteArguments(byte[] buffer, int offset, int count)
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
        /// Проверяет позицию потока при установке через свойство <see cref="Stream.Position"/>.
        /// </summary>
        /// <param name="position">Новая позиция.</param>
        public static void ValidatePosition(long position)
        {
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException("Position", "Позиция потока не может быть меньше 0.");
            }
        }
    }
}
