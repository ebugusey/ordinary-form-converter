using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Оформление надписи.
    /// </summary>
    public class LabelDecoration
    {
        /// <summary>
        /// Выравнивание текста надписи.
        /// </summary>
        public TextAlignment TextAlignment { get; set; }

        /// <summary>
        /// ПрозрачныйФон.
        /// </summary>
        public bool IsTransparentBackground { get; set; }

        /// <summary>
        /// ЦветФона.
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекста.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// ШрифтТекста.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// ПоложениеКартинкиНадписи.
        /// </summary>
        public LabelPicturePosition PicturePosition { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// РазмерКартинки.
        /// </summary>
        public PictureSize PictureSize { get; set; }

        public LabelDecoration()
        {
            TextAlignment = new TextAlignment
            {
                Horizontal = HorizontalTextAlignment.Auto,
                Vertical = VerticalTextAlignment.Center,
            };

            BackgroundColor = new AutoColor();
            TextColor = new AutoColor();

            Border = new Border();
            BorderColor = new AutoColor();

            TextFont = new AutoFont();

            PicturePosition = LabelPicturePosition.Left;
            Picture = new EmptyPicture();
            PictureSize = PictureSize.AutoSize;
        }
    }
}
