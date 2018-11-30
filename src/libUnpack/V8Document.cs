using System;
using System.Diagnostics;
using System.IO;
using libUnpack.IO;

namespace libUnpack
{
    /// <summary>
    /// Представляет документ внутри контейнера платформы.
    /// </summary>
    internal class V8Document
    {
        /// <summary>
        /// Адрес (позиция в потоке), по которому находится первая страница документа.
        /// </summary>
        public int Address => _address;

        private readonly V8Container _container;
        private readonly Stream _superStream;
        private readonly int _address;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="V8Document"/> из указанного контейнера.
        /// В качестве адреса документа будет взята текущая позиция основного потока контейнера.
        /// </summary>
        /// <param name="container">Контейнер, документ которого инициализируется.</param>
        public V8Document(V8Container container)
            : this(container, 0)
        {
            Debug.Assert(_superStream.CanSeek);

            _address = checked((int)_superStream.Position);
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="V8Document"/> из указанного контейнера.
        /// В качестве адреса документ будет использован <paramref name="address"/>.
        /// </summary>
        /// <param name="container">Контейнер, документ которого инициализируется.</param>
        /// <param name="address">Адрес документа.</param>
        public V8Document(V8Container container, int address)
        {
            if (address < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(address));
            }

            _container = container ?? throw new ArgumentNullException(nameof(container));
            _superStream = container.MainStream;
            _address = address;
        }

        /// <summary>
        /// Открывает документ для чтения или записи.
        /// </summary>
        /// <returns>Поток для чтения или записи данных документа.</returns>
        public Stream Open()
        {
            var firstPage = FirstPage();
            var stream = new DocumentStream(firstPage);

            return stream;
        }

        private Page FirstPage()
        {
            return Page.FromStream(_container, _address);
        }

        #region Object

        public override string ToString()
        {
            return $"{nameof(V8Document)} (address: 0x{_address:x8})";
        }

        #endregion
    }
}
