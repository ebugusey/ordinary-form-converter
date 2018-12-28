using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform
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

    class AutoFont : RelativeFont
    {
        public override FontType Type => FontType.AutoFont;
    }

    class AbsoluteFont : Font
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

    public enum FontType
    {
        Absolute = 0,
        WindowsFont = 1,
        StyleItem = 2,
        AutoFont = 3,
    }

    public enum WindowsFontStyle
    {
        DefaultGUIFont = 0,
        OEMFixedFont = 1,
        ANSIFixedFont = 2,
        ANSIVariableFont = 3,
        SystemFont = 4,
    }

    public enum StandardFontStyle
    {
        TextFont = -20,
        SmallTextFont = -30,
        NormalTextFont = -31,
        LargeTextFont = -32,
        ExtraLargeTextFont = -33,
    }
}
