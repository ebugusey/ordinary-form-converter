using System;
using System.Text.RegularExpressions;

namespace OFP.ObjectModel.Common
{
    /// <summary>
    /// Строка представляющая идентификатор чего-либо.
    /// Это может быть имя колонки в таблице, имя метода в форме или имя элемента.
    /// </summary>
    public readonly struct Identifier : IEquatable<Identifier>
    {
        private static readonly StringComparer ValueComparer =
            StringComparer.OrdinalIgnoreCase;

        /// <summary>
        /// Строковое представление идентификатора.
        /// </summary>
        /// <exception cref="InvalidOperationException">Если значение не было инициализировано из строки.</exception>
        public string Value =>
            _value ?? throw new InvalidOperationException("Значение не инициализировано.");

        /// <summary>
        /// Значение было инициализировано из строки.
        /// </summary>
        public bool HasValue => _value != null;

        private readonly string _value;

        /// <summary>
        /// Инициализировать идентификатор указанным значением.
        /// </summary>
        /// <param name="value">Строковое представление идентификатора.</param>
        public Identifier(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Идентификатор не может быть пустым.", nameof(value));
            }
            if (!IsValid(value))
            {
                throw new ArgumentException(
                    "Идентификатор должен начинаться с _ или буквы.\n" +
                    "Идентификатор не должен содержать пробелов и переносов строк.",
                    nameof(value)
                );
            }

            _value = value;
        }

        private static bool IsValid(string value)
        {
            // Именем элемента должен быть валидный идентификатор.
            // Например: ИмяЭлемента1, _ИмяЭлемента2, elementName.
            // Но не: 1йЭлемент.
            // Первый символ -- _ или буква юникода.
            // Остальные символы -- числа, буквы и _.
            var pattern = @"^[_\p{L}][_\d\p{L}]*$";
            return Regex.IsMatch(value, pattern);
        }

        #region Object

        public override string ToString() => Value;

        public override int GetHashCode() => ValueComparer.GetHashCode(Value);

        public override bool Equals(object obj)
        {
            var result = obj switch
            {
                Identifier elementName => Equals(in elementName),
                _ => false,
            };
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
