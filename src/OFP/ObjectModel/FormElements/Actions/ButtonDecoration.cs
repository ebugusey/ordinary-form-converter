using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Actions
{
    /// <summary>
    /// Оформление кнопки.
    /// </summary>
    public class ButtonDecoration
    {
        /// <summary>
        /// Шрифт.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// ЦветФонаКнопки.
        /// </summary>
        public Color ButtonBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаКнопки.
        /// </summary>
        public Color ButtonTextColor { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// ПоложениеКартинки.
        /// </summary>
        public ButtonPicturePosition PicturePosition { get; set; }

        /// <summary>
        /// РазмерКартинки.
        /// </summary>
        public PictureSize PictureSize { get; set; }
    }
}
