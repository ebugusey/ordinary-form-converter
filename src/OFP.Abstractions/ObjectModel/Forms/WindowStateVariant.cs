namespace OFP.ObjectModel.Forms
{
    /// <summary>
    /// ВариантСостоянияОкна.
    /// </summary>
    public enum WindowStateVariant
    {
        /// <summary>
        /// Прикрепленное.
        /// </summary>
        Docked = 1,

        /// <summary>
        /// Свободное.
        /// </summary>
        Float = 2,

        /// <summary>
        /// Обычное.
        /// </summary>
        Normal = 4,

        /// <summary>
        /// Прячущееся.
        /// </summary>
        Autohide = 16,
    }
}
