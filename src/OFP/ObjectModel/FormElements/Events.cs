using System;
using System.Collections;
using System.Collections.Generic;

namespace OFP.ObjectModel.FormElements
{
    public class Events<TEvent> : IEnumerable<KeyValuePair<TEvent, Identifier>> where TEvent : Enum
    {
        private readonly Dictionary<TEvent, Identifier> _events;

        public Identifier this[TEvent key]
        {
            get => _events[key];
            set => _events[key] = value;
        }

        public int Count => _events.Count;

        public Events()
        {
            _events = new Dictionary<TEvent, Identifier>();
        }

        public void Add(TEvent @event, Identifier handlerName)
        {
            _events.Add(@event, handlerName);
        }

        public bool HasEvent(TEvent @event)
        {
            return _events.ContainsKey(@event);
        }

        public bool TryGetEventHandler(TEvent @event, out Identifier handlerName)
        {
            return _events.TryGetValue(@event, out handlerName);
        }

        public bool Remove(TEvent @event)
        {
            return _events.Remove(@event);
        }

        public bool Remove(TEvent @event, out Identifier handlerName)
        {
            return _events.Remove(@event, out handlerName);
        }

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
