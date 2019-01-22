using OFP.ObjectModel.Common;
using OFP.ObjectModel.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    public class TableBoxColumn
    {
        public bool AutoCellHeight { get; set; }
        public bool AutoMarkIncomplete { get; set; }
        public int CellHeight { get; set; }
        public bool ChangePosition { get; set; }
        public bool ChangeSetting { get; set; }
        public bool ChangeVisible { get; set; }
        public bool CheckBoxThreeState { get; set; }
        public bool CheckData { get; set; }
        public Element Control { get; set; }
        public string DataPath { get; set; }
        public TableBoxColumnDecoration Decor { get; set; }
        public ColumnEditMode EditMode { get; set; }
        public bool Enabled { get; set; }
        public HorizontalAlign FooterHorizontalAlign { get; set; }
        public HorizontalAlign HeaderHorizontalAlign { get; set; }
        public LocalizedString HeaderToolTip { get; set; }
        public HorizontalAlign HorizontalAlignInColumn { get; set; }
        public bool Hyperlink { get; set; }
        public ColumnLocation Location { get; set; }
        public bool MarkNegatives { get; set; }
        public string Name { get; set; }
        public string PictureData { get; set; }
        public bool ReadOnly { get; set; }
        public bool ShowHierarchy { get; set; }
        public bool ShowInFooter { get; set; }
        public bool ShowInHeader { get; set; }
        public SizeChange SizeChange { get; set; }
        public bool SkipOnInput { get; set; }
        public string FooterText { get; set; }
        public string HeaderText { get; set; }
        public bool Visible { get; set; }
    }
}
