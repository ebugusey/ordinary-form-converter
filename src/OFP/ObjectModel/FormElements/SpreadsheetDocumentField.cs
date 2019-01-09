using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    class SpreadsheetDocumentField : Element
    {

        public bool EnableDrag { get; set; }
        public bool EnableStartDrag { get; set; }
        public Event<SpreadsheetDocumentField> Events { get; set; }
        public SpreadsheetDocumentSelectionShowModeType ShowSelection { get; set; }
        public UseOutput Output { get; set; }
        public bool HorizontalScrollBar { get; set; }
        public bool VerticalScrollBar { get; set; }

    }
}
