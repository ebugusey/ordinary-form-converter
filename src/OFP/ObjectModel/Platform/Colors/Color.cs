using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform.Colors
{
    public abstract class Color
    {
        public abstract ColorType Type { get; }
    }

    public class AutoColor : Color
    {
        public override ColorType Type => ColorType.AutoColor;
    }

    public class AbsoluteColor : Color
    {
        public override ColorType Type => ColorType.Absolute;
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }

    public abstract class StyleBasedColor<TStyle> : Color where TStyle : struct
    {
        public abstract TStyle Style { get; set; }
    }

    public class WindowsColor : StyleBasedColor<WindowsColorStyle>
    {
        public override ColorType Type => ColorType.WindowsColor;
        public override WindowsColorStyle Style { get; set; }
    }

    public class WebColor : StyleBasedColor<WebColorStyle>
    {
        public override ColorType Type => ColorType.WebColor;
        public override WebColorStyle Style { get; set; }
    }

    public class StandardColor : StyleBasedColor<StandardColorStyle>
    {
        public override ColorType Type => ColorType.StyleItem;
        public override StandardColorStyle Style { get; set; }
    }

    public class ColorFromConfiguration : StyleBasedColor<Guid>
    {
        public override ColorType Type => ColorType.StyleItem;
        public override Guid Style { get; set; }
    }
}
