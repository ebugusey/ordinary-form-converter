namespace OFP.ObjectModel.Platform.Borders
{
    /// <summary>
    /// ТипРамкиЭлементаУправления.
    /// </summary>
    public enum BorderStyle
    {
        /// <summary>
        /// БезРамки.
        /// </summary>
        WithoutBorder = 0,

        /// <summary>
        /// Одинарная.
        /// </summary>
        Single = 1,

        /// <summary>
        /// Выпуклая.
        /// </summary>
        Embossed = 2,

        /// <summary>
        /// Вдавленная.
        /// </summary>
        Indented = 3,

        /// <summary>
        /// Подчеркивание.
        /// </summary>
        Underline = 4,

        /// <summary>
        /// ДвойноеПодчеркивание.
        /// </summary>
        DoubleUnderline = 5,

        /// <summary>
        /// Скругленная.
        /// </summary>
        Rounded = 6,

        /// <summary>
        /// ЧертаСверху.
        /// </summary>
        Overline = 7,

        /// <summary>
        /// Двойная.
        /// </summary>
        Double = 200,
    }
}
