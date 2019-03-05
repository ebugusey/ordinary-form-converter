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
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// Шрифт.
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// ЦветФона.
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// ЦветТекста.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// ПрозрачныйФон.
        /// </summary>
        public bool IsTransparent { get; set; }

        /// <summary>
        /// Выравнивание текста флажка.
        /// </summary>
        public TextAlignment TextAlignment { get; }
    }
}
