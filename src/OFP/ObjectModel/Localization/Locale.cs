using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Localization
{
    public readonly struct Locale : IEquatable<Locale>
    {
        public string Value => _value ?? DefaultLocale;

        private const string DefaultLocale = "ru";

        private readonly string _value;

        public Locale(string locale)
        {
            if (string.IsNullOrEmpty(locale))
            {
                _value = DefaultLocale;
            }
            else if (locale == "#")
            {
                _value = DefaultLocale;
            }
            else
            {
                _value = locale;
            }
        }

        #region Object

        public override string ToString() => Value;

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            bool result;
            switch (obj)
            {
                case Locale locale:
                    result = Equals(in locale);
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        #endregion

        #region IEquatable

        public bool Equals(Locale other) => Equals(in other);

        #endregion

        private bool Equals(in Locale other) =>
            Value == other.Value;

        public static implicit operator Locale(string source) =>
            new Locale(source);
        public static explicit operator string(in Locale source) =>
            source.Value;

        public static bool operator ==(in Locale left, in Locale right) =>
            left.Equals(in right);
        public static bool operator !=(in Locale left, in Locale right) =>
            !left.Equals(in right);
    }

}
