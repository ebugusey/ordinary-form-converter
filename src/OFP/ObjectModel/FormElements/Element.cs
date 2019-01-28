using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Bindings;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements
{
    public abstract class Element
    {
        public Identifier Name { get; set; }
        public bool AutoContextMenu { get; set; }
        public BorderBindings Bindings { get; set; }
        public string DataPath { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public bool FirstInGroup { get; set; }
        public bool ModifiesData { get; set; }
        public bool SkipOnInput { get; set; }
        public LocalizedString ToolTip { get; set; }
        public Position Position { get; set; }
    }
}
