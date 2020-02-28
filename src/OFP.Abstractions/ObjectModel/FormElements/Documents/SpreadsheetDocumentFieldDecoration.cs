using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;

namespace OFP.ObjectModel.FormElements.Documents
{
    /// <summary>
    /// Оформление ПолеТабличногоДокумента.
    /// </summary>
    public class SpreadsheetDocumentFieldDecoration
    {
        /// <summary>
        /// Рамка.
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// ЦветРамки.
        /// </summary>
        public Color BorderColor { get; set; }

        public SpreadsheetDocumentFieldDecoration()
        {
            Border = new Border();
            BorderColor = new AutoColor();
        }
    }
}
