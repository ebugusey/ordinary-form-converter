using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace OFP.ObjectModel.FormElements
{
    public readonly struct Identifier : IEquatable<Identifier>
    {
        private static readonly StringComparer ValueComparer =
            StringComparer.OrdinalIgnoreCase;

        public string Value =>
            _value ?? throw new InvalidOperationException("Значение не инициализировано.");

        public bool HasValue => _value != null;

        private readonly string _value;

        public Identifier(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Идентификатор не может быть пустым.", nameof(name));
            }
            if (!NameIsValid(name))
            {
                throw new ArgumentException(
                    "Идентификатор должен начинаться с _ или буквы.\n" +
                    "Идентификатор не должен содержать пробелов и переносов строк.",
                    nameof(name)
                );
            }

            _value = name;
        }

        private static bool NameIsValid(string name)
        {
            // Именем элемента должен быть валидный идентификатор.
            // Например: ИмяЭлемента1, _ИмяЭлемента2, elementName.
            // Но не: 1йЭлемент.
            // Первый символ -- _ или буква юникода.
            // Остальные символы -- числа, буквы и _.
            var pattern = @"^[_\p{L}][_\d\p{L}]*$";
            return Regex.IsMatch(name, pattern);
        }

        #region Object

        public override string ToString() => Value;

        public override int GetHashCode() => ValueComparer.GetHashCode(Value);

        public override bool Equals(object obj)
        {
            bool result;
            switch (obj)
            {
                case Identifier elementName:
                    result = Equals(in elementName);
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        #endregion

        #region IEquatable

        public bool Equals(Identifier other) => Equals(in other);

        #endregion

        private bool Equals(in Identifier other) =>
            ValueComparer.Equals(Value, other.Value);

        public static explicit operator Identifier(string source)
        {
            Identifier result;
            try
            {
                result = new Identifier(source);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidCastException(ex.Message, ex);
            }

            return result;
        }
        public static explicit operator string(in Identifier source) =>
            source.Value;

        public static bool operator ==(in Identifier left, in Identifier right) =>
            left.Equals(in right);
        public static bool operator !=(in Identifier left, in Identifier right) =>
            !left.Equals(in right);
    }
}
