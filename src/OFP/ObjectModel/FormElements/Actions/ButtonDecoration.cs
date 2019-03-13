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
        /// ЦветФонаКнопки.
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаКнопки.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// Шрифт.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// ПоложениеКартинки.
        /// </summary>
        public ButtonPicturePosition PicturePosition { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// РазмерКартинки.
        /// </summary>
        public PictureSize PictureSize { get; set; }

        /// <summary>
        /// Выравнивание текста кнопки.
        /// </summary>
        public TextAlignment TextAlignment { get; }

        public ButtonDecoration()
        {
            BackgroundColor = new AutoColor();
            TextColor = new AutoColor();

            BorderColor = new AutoColor();

            TextFont = new AutoFont();

            PicturePosition = ButtonPicturePosition.Left;
            Picture = new EmptyPicture();
            PictureSize = PictureSize.AutoSize;

            TextAlignment = new TextAlignment
            {
                Horizontal = HorizontalTextAlignment.Center,
                Vertical = VerticalTextAlignment.Center,
            };
        }
    }
}
