using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform
{
    public class Border
    {
        public BorderType Type { get; set; }
        public BorderStyle Style { get; set; }
        public byte Width { get; set; }
    }

    public enum BorderType
    {
        Absolute = 0,
        StyleItem = 1,
    }

    public enum BorderStyle
    {
        WithoutBorder = 0,
        Single = 1,
        Embossed = 2,
        Indented = 3,
        Underline = 4,
        DoubleUnderline = 5,
        Rounded = 6,
        Overline = 7,
        Double = 200,
    }
}
