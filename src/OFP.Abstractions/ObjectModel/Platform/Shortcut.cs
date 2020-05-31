namespace OFP.ObjectModel.Platform
{
    /// <summary>
    /// СочетаниеКлавиш.
    /// </summary>
    public readonly struct Shortcut
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

        public override string ToString() =>
            $"{nameof(Shortcut)}: {Modifiers}+{Key}";
    }
}
