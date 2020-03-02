using System;
using System.Collections;
using System.Collections.Generic;

namespace OFP.ObjectModel.Common
{
    /// <summary>
    /// События элемента управления.
    /// На одно событие может быть назначен только один обработчик.
    /// Набор событий элемента ограничен и описывается перечислением.
    /// В качестве обработчика указывается имя метода формы в виде <see cref="Identifier"/>.
    /// </summary>
    /// <typeparam name="TEvent">Перечисление-идентификатор события элемента.</typeparam>
    public class Events<TEvent> : IEnumerable<KeyValuePair<TEvent, Identifier>> where TEvent : Enum
    {
        private readonly Dictionary<TEvent, Identifier> _events;

        public Identifier this[TEvent key]
        {
            get => _events[key];
            set => _events[key] = value;
        }

        /// <summary>
        /// Количество событий, назначенных на элемент.
        /// </summary>
        public int Count => _events.Count;

        /// <summary>
        /// Инициализировать новую коллекцию событий.
        /// </summary>
        public Events()
        {
            _events = new Dictionary<TEvent, Identifier>();
        }

        /// <summary>
        /// Добавить новое событие в коллекцию.
        /// </summary>
        /// <param name="event">Идентификатор события.</param>
        /// <param name="handlerName">Имя метода-обработчика события.</param>
        public void Add(TEvent @event, Identifier handlerName)
        {
            _events.Add(@event, handlerName);
        }

        /// <summary>
        /// Проверить есть ли уже событие в коллекции.
        /// </summary>
        /// <param name="event">Идентификатор события.</param>
        /// <returns><c><see langword="true"/></c>, если событие уже есть в коллекции.</returns>
        public bool HasEvent(TEvent @event)
        {
            return _events.ContainsKey(@event);
        }

        /// <summary>
        /// Получить имя метода-обработчика события по его идентификатору события.
        /// Если обработчика для указанного <paramref name="event"/> нет, возвращает
        /// <c><see langword="false"/></c>.
        /// </summary>
        /// <param name="event">Идентификатор события.</param>
        /// <param name="handlerName">Имя метода-обработчика события.</param>
        /// <returns><c><see langword="true"/></c>, если есть обработчик назначен.</returns>
        public bool TryGetEventHandler(TEvent @event, out Identifier handlerName)
        {
            return _events.TryGetValue(@event, out handlerName);
        }

        /// <summary>
        /// Удалить обработчик события.
        /// </summary>
        /// <param name="event">Идентификатор события.</param>
        /// <returns><c><see langword="true"/></c>, если такое событие было.</returns>
        public bool Remove(TEvent @event)
        {
            return _events.Remove(@event);
        }

        /// <summary>
        /// Удалить обработчик события и получить имя метода-обработчика,
        /// которое было назначено до удаления.
        /// </summary>
        /// <param name="event">Идентификатор события.</param>
        /// <param name="handlerName">Имя метода-обработчика события.</param>
        /// <returns><c><see langword="true"/></c>, если такое событие было.</returns>
        public bool Remove(TEvent @event, out Identifier handlerName)
        {
            return _events.Remove(@event, out handlerName);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TEvent, Identifier>> GetEnumerator()
        {
            return _events.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _events.GetEnumerator();
        }
    }
}
