namespace OFP.ObjectModel.FormElements
{
    /// <summary>
    /// РазмерКартинки.
    /// </summary>
    public enum PictureSize
    {
        /// <summary>
        /// РеальныйРазмер.
        /// </summary>
        RealSize = 0,

        /// <summary>
        /// Растянуть.
        /// </summary>
        Stretch = 1,

        /// <summary>
        /// Пропорционально.
        /// </summary>
        Proportionally = 2,

        /// <summary>
        /// Черепица.
        /// </summary>
        Tile = 3,

        /// <summary>
        /// АвтоРазмер.
        /// </summary>
        AutoSize = 4,

        /// <summary>
        /// РеальныйРазмерБезУчетаМасштаба.
        /// </summary>
        RealSizeIgnoreScale = 5,

        /// <summary>
        /// АвтоРазмерБезУчетаМасштаба.
        /// </summary>
        AutoSizeIgnoreScale = 6,
    }
}
