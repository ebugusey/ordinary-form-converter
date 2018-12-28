using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OFP.ObjectModel.Localization
{
    public class LocalizedString : IDictionary<Locale, string>
    {
        private readonly IDictionary<Locale, string> _strings;

        public string this[Locale key]
        {
            get => _strings[key];
            set => _strings[key] = value;
        }
        public ICollection<Locale> Keys => _strings.Keys;
        public ICollection<string> Values => _strings.Values;
        public int Count => _strings.Count;
        public bool IsReadOnly => _strings.IsReadOnly;

        public LocalizedString()
        {
            _strings = new Dictionary<Locale, string>();
        }

        public void Add(Locale key, string value)
        {
            _strings.Add(key, value);
        }

        public void Add(KeyValuePair<Locale, string> item)
        {
            _strings.Add(item);
        }

        public void Clear()
        {
            _strings.Clear();
        }

        public bool Contains(KeyValuePair<Locale, string> item)
        {
            return _strings.Contains(item);
        }

        public bool ContainsKey(Locale key)
        {
            return _strings.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<Locale, string>[] array, int arrayIndex)
        {
            _strings.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<Locale, string>> GetEnumerator()
        {
            return _strings.GetEnumerator();
        }

        public bool Remove(Locale key)
        {
            return _strings.Remove(key);
        }

        public bool Remove(KeyValuePair<Locale, string> item)
        {
            return _strings.Remove(item);
        }

        public bool TryGetValue(Locale key, out string value)
        {
            return _strings.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _strings.GetEnumerator();
        }
    }
}
