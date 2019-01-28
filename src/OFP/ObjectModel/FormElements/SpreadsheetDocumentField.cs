using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    public class SpreadsheetDocumentField : Element
    {
        public SpreadsheetDocumentFieldDecoration Decor { get; set; }
        public bool EnableDrag { get; set; }
        public bool EnableStartDrag { get; set; }
        public Events<SpreadsheetDocumentFieldEvent> Events { get; set; }
        public SpreadsheetDocumentSelectionShowModeType ShowSelection { get; set; }
        public UseOutput Output { get; set; }
        public bool HorizontalScrollBar { get; set; }
        public bool VerticalScrollBar { get; set; }
    }
}
