using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements.Data
{
    public class RadioButton : Element
    {
        public RadioButtonDecoration Decor { get; set; }
        public bool IsDefaultControl { get; set; }
        public Events<RadioButtonEvent> Events { get; set; }
        public HorizontalAlign HorizontalAlign { get; set; }
        public SimpleTypeValue SelectionValue { get; set; }
        public TitleLocation TitleLocation { get; set; }
        public VerticalAlign VerticalAlign { get; set; }
    }
}
