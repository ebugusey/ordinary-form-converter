using OFP.ObjectModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    public class RadioButton : Element
    {

        public bool IsDefaultControl { get; set; }
        public Event<RadioButton> Events { get; set; }
        public HorizontalAlign HorizontalAlign { get; set; }
        public SimpleTypeValue SelectionValue { get; set; }
        public TitleLocation TitleLocation { get; set; }
        public VerticalAlign VerticalAlign { get; set; }


    }
}
