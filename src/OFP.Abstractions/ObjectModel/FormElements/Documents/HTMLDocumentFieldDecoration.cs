using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;

namespace OFP.ObjectModel.FormElements.Documents
{

    /// <summary>
    /// Оформление ПолеHTMLДокумента.
    /// </summary>
    public class HTMLDocumentFieldDecoration
    {
        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        public HTMLDocumentFieldDecoration()
        {
            Border = new Border();
            BorderColor = new AutoColor();
        }
    }
}
