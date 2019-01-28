using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OFP.ObjectModel.Localization
{
    public class LocalizedString : IEnumerable<KeyValuePair<Locale, string>>
    {
        private readonly IDictionary<Locale, string> _strings;

        public string this[Locale key]
        {
            get => _strings[key];
            set => _strings[key] = value;
        }

        public int Count => _strings.Count;

        public LocalizedString()
        {
            _strings = new Dictionary<Locale, string>();
        }

        public void Add(Locale locale, string value)
        {
            _strings.Add(locale, value);
        }

        public bool HasLocale(Locale locale)
        {
            return _strings.ContainsKey(locale);
        }

        public bool TryGetString(Locale locale, out string value)
        {
            return _strings.TryGetValue(locale, out value);
        }

        public bool Remove(Locale locale)
        {
            return _strings.Remove(locale);
        }

        public IEnumerator<KeyValuePair<Locale, string>> GetEnumerator()
        {
            return _strings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _strings.GetEnumerator();
        }
    }
}
