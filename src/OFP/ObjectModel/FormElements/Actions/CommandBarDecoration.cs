using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;

namespace OFP.ObjectModel.FormElements.Actions
{
    /// <summary>
    /// Оформление командной панели.
    /// </summary>
    public class CommandBarDecoration
    {
        /// <summary>
        /// ПрозрачныйФон.
        /// </summary>
        public bool IsTransparentBackground { get; set; }

        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// Шрифт.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// ЦветФона.
        /// </summary>
        public Color BackgroundColor { get; set; }

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
    }
}
