using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform.Fonts
{
    public abstract class Font
    {
        public abstract FontType Type { get; }
    }

    public abstract class RelativeFont : Font
    {
        public string FaceName { get; set; }
        public ushort? Size { get; set; }
        public ushort? Scale { get; set; }
        public bool? Bold { get; set; }
        public bool? Strikeout { get; set; }
        public bool? Italic { get; set; }
        public bool? Underline { get; set; }
    }

    public abstract class StyleBasedFont<TStyle> : RelativeFont where TStyle : struct
    {
        public abstract TStyle Style { get; set; }
    }

    public class WindowsFont : StyleBasedFont<WindowsFontStyle>
    {
        public override FontType Type => FontType.WindowsFont;
        public override WindowsFontStyle Style { get; set; }
    }

    public class StandardFont : StyleBasedFont<StandardFontStyle>
    {
        public override FontType Type => FontType.StyleItem;
        public override StandardFontStyle Style { get; set; }
    }

    public class FontFromConfiguration : StyleBasedFont<Guid>
    {
        public override FontType Type => FontType.StyleItem;
        public override Guid Style { get; set; }
    }

    public class AutoFont : RelativeFont
    {
        public override FontType Type => FontType.AutoFont;
    }

    public class AbsoluteFont : Font
    {
        public override FontType Type => FontType.Absolute;

        public string FaceName { get; set; }
        public ushort Size { get; set; }
        public ushort Scale { get; set; }
        public bool Bold { get; set; }
        public bool Strikeout { get; set; }
        public bool Italic { get; set; }
        public bool Underline { get; set; }
    }



}
