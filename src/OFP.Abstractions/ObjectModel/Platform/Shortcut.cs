using System;

namespace OFP.ObjectModel.Platform
{
    /// <summary>
    /// СочетаниеКлавиш.
    /// </summary>
    public readonly struct Shortcut : IEquatable<Shortcut>
    {
        /// <summary>
        /// Alt, Ctrl, Shift.
        /// </summary>
        public KeyModifier Modifiers { get; }

        /// <summary>
        /// Клавиша.
        /// </summary>
        public Key Key { get; }

        public Shortcut(Key key, KeyModifier modifiers = KeyModifier.None)
        {
            (Key, Modifiers) = (key, modifiers);
        }

        #region Object

        public override string ToString() =>
            $"{nameof(Shortcut)}: {Modifiers}+{Key}";

        public override int GetHashCode() =>
            (Key, Modifiers).GetHashCode();

        public override bool Equals(object obj)
        {
            var result = obj switch
            {
                Shortcut shortcut => Equals(in shortcut),
                _ => false,
            };

            return result;
        }

        #endregion

        #region IEquatable

        public bool Equals(Shortcut other) => Equals(in other);

        #endregion

        private bool Equals(in Shortcut other)
        {
            return Key == other.Key && Modifiers == other.Modifiers;
        }

        public static bool operator ==(in Shortcut left, in Shortcut right) =>
            left.Equals(right);

        public static bool operator !=(in Shortcut left, in Shortcut right) =>
            !left.Equals(right);
    }
}
