using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;

namespace OFP.ObjectModel.FormElements.Data
{
    /// <summary>
    /// Оформление флажка.
    /// </summary>
    public class CheckBoxDecoration
    {
        /// <summary>
        /// Выравнивание текста флажка.
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
        /// Шрифт.
        /// </summary>
        public Font TextFont { get; set; }

        public CheckBoxDecoration()
        {
            TextAlignment = new TextAlignment
            {
                Horizontal = HorizontalTextAlignment.Left,
                Vertical = VerticalTextAlignment.Center,
            };

            BackgroundColor = new AutoColor();
            TextColor = new AutoColor();

            Border = new Border();
            BorderColor = new AutoColor();

            TextFont = new AutoFont();
        }
    }
}
