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
    }
}
