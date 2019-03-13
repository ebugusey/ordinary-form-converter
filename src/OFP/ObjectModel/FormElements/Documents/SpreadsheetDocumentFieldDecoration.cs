using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using System;
using System.Collections.Generic;
using System.Text;

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
