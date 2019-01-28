using System;
using System.Collections.Generic;
using System.Text;
using OFP.ObjectModel.Localization;
using OFP.ObjectModel.Common;

namespace OFP.ObjectModel.FormElements.Decorative
{
    public class Label : Element
    {
        public LocalizedString Title { get; set; }
        public LabelDecoration Decor { get; set; }
        public Events<LabelEvent> Events { get; set; }
        public string Format { get; set; }
        public HorizontalAlign HorizontalAlign { get; set; }
        public VerticalAlign VerticalAlign { get; set; }
        public bool IsHyperlink { get; set; }
        public bool MarkNegatives { get; set; }
        public ScrollingTextMode ScrollingText { get; set; }
    }
}
