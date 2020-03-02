using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using OFP.ObjectModel.Platform.Pictures;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Оформление поля ввода.
    /// </summary>
    public class TextBoxDecoration
    {
        /// <summary>
        /// Выравнивание текста поля ввода.
        /// </summary>
        public TextAlignment TextAlignment { get; set; }

        /// <summary>
        /// ПрозрачныйФон.
        /// </summary>
        public bool IsTransparentBackground { get; set; }

        /// <summary>
        /// ЦветФонаПоля.
        /// </summary>
        public Color FieldBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаПоля.
        /// </summary>
        public Color FieldTextColor { get; set; }

        /// <summary>
        /// ЦветФонаКнопки.
        /// </summary>
        public Color ButtonBackgroundColor { get; set; }

        /// <summary>
        /// ЦветТекстаКнопки.
        /// </summary>
        public Color ButtonTextColor { get; set; }

        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// Шрифт.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        /// КартинкаКнопкиВыбора.
        /// </summary>
        public Picture ChoiceButtonPicture { get; set; }

        /// <summary>
        /// ВысотаСпискаВыбора.
        /// </summary>
        public ushort ChoiceListHeight { get; set; }

        /// <summary>
        /// ШиринаСпискаВыбора.
        /// </summary>
        public ushort ChoiceListWidth { get; set; }

        public TextBoxDecoration()
        {
            TextAlignment = new TextAlignment
            {
                Horizontal = HorizontalTextAlignment.Auto,
                Vertical = VerticalTextAlignment.Top,
            };

            FieldBackgroundColor = new AutoColor();
            FieldTextColor = new AutoColor();

            ButtonBackgroundColor = new AutoColor();
            ButtonTextColor = new AutoColor();

            Border = new Border();
            BorderColor = new AutoColor();

            TextFont = new AutoFont();

            Picture = new EmptyPicture();
            ChoiceButtonPicture = new EmptyPicture();
        }
    }
}
