using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    public class TableBox : Element
    {
        public bool AutoInsertNewRow { get; set; }
        public bool ChangePositionOfColumns { get; set; }
        public bool ChangeRowOrder { get; set; }
        public bool ChangeRowSet { get; set; }
        public bool ChangeSettingOfColumns { get; set; }
        public List<TableBoxColumn> Columns { get; }
        public TableBoxDecoration Decor { get; set; }
        public bool DefaultControl { get; set; }
        public bool EnableDrag { get; set; }
        public bool EnableStartDrag { get; set; }
        public Events<TableBoxEvent> Events { get; set; }
        public int FixedLeft { get; set; }
        public int FixedRight { get; set; }
        public bool Footer { get; set; }
        public int FooterHeight { get; set; }
        public bool Header { get; set; }
        public int HeaderHeight { get; set; }
        public ScrollBarUse HorizontalScrollBar { get; set; }
        public InitialListView InitialListView { get; set; }
        public UseOutput Output { get; set; }
        public bool ReadOnly { get; set; }
        public TableBoxRowInputMode RowInputMode { get; set; }
        public TableBoxRowSelectionMode RowSelectionMode { get; set; }
        public TableBoxSelectionMode SelectionMode { get; set; }
        public ScrollBarUse VerticalScrollBar { get; set; }
    }
}
