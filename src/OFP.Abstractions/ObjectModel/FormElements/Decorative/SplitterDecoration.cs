using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;

namespace OFP.ObjectModel.FormElements.Decorative
{
    /// <summary>
    /// Оформление Разделитель.
    /// </summary>
    public class SplitterDecoration
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
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        public SplitterDecoration()
        {
            BackgroundColor = new AutoColor();

            Border = new Border();
            BorderColor = new AutoColor();
        }
    }
}
