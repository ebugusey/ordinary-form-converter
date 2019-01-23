using OFP.ObjectModel.Platform;
using OFP.ObjectModel.Platform.Borders;
using OFP.ObjectModel.Platform.Colors;
using OFP.ObjectModel.Platform.Fonts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.FormElements
{
    public class TableBoxDecoration
    {
        public Border Border { get; set; }
        public Font Font { get; set; }
        public Color AlternationRowBackColor { get; set; }
        public Color BorderColor { get; set; }
        public Color FieldBackColor { get; set; }
        public Color FieldTextColor { get; set; }
        public Color FooterBackColor { get; set; }
        public Font FooterFont { get; set; }
        public Color FooterTextColor { get; set; }
        public Color HeaderBackColor { get; set; }
        public Font HeaderFont { get; set; }
        public Color HeaderTextColor { get; set; }
        public bool HorizontalLines { get; set; }
        public Color SelectionBackColor { get; set; }
        public Color SelectionTextColor { get; set; }
        public bool UseAlternationRowColor { get; set; }
        public bool VerticalLines { get; set; }
    }
}
