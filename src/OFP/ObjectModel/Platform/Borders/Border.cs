namespace OFP.ObjectModel.Platform.Borders
{
    /// <summary>
    /// Рамка.
    /// </summary>
    public class Border
    {
        /// <summary>
        /// Вид.
        /// </summary>
        public BorderType Type { get; set; }

        /// <summary>
        /// ТипРамки.
        /// </summary>
        public BorderStyle Style { get; set; }

        /// <summary>
        /// Толщина.
        /// </summary>
        public byte Width { get; set; }
    }
}
