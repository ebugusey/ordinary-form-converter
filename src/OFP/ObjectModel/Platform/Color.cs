using System;
using System.Collections.Generic;
using System.Text;

namespace OFP.ObjectModel.Platform
{
    public abstract class Color
    {
        public abstract ColorType Type { get; }
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

    public class StandardColor : StyleBasedColor<StandardColorStyle>
    {
        public override ColorType Type => ColorType.StyleItem;
        public override StandardColorStyle Style { get; set; }
    }

    public class WebColor : StyleBasedColor<WebColorStyle>
    {
        public override ColorType Type => ColorType.WebColor;
        public override WebColorStyle Style { get; set; }
    }

    public class AbsoluteColor : Color
    {
        public override ColorType Type => ColorType.Absolute;
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }

    public enum ColorType
    {
        Absolute = 0,
        WindowsColor = 1,
        WebColor = 2,
        StyleItem = 3,
        AutoColor = 4,
    }

    public enum WindowsColorStyle
    {
        ActiveBorder = 10,
        ActiveTitleBar = 2,
        ActiveTitleBarText = 9,
        ApplicationWorkspace = 12,
        ButtonDarkShadow = 21,
        ButtonFace = 15,
        ButtonHighlight = 20,
        ButtonLightShadow = 22,
        ButtonShadow = 16,
        ButtonText = 18,
        Desktop = 1,
        DisabledText = 17,
        Highlight = 13,
        HighlightText = 14,
        InactiveBorder = 11,
        InactiveTitleBar = 3,
        InactiveTitleBarText = 19,
        MenuBar = 4,
        MenuItemText = 7,
        ScrollBar = 0,
        ToolTip = 24,
        ToolTipText = 23,
        WindowBackground = 5,
        WindowFrame = 6,
        WindowText = 8,
    }

    public enum StandardColorStyle
    {
        BorderColor = -22,
        ButtonBackColor = -7,
        ButtonBorderColor = -34,
        ButtonTextColor = -21,
        FieldAlternativeBackColor = -13,
        FieldBackColor = -10,
        FieldSelectedTextColor = -15,
        FieldSelectionBackColor = -14,
        FieldTextColor = -11,
        FormBackColor = -1,
        FormTextColor = -3,
        NegativeTextColor = -17,
        ReportGroup1BackColor = -26,
        ReportGroup2BackColor = -27,
        ReportHeaderBackColor = -25,
        ReportLineColor = -28,
        SpecialTextColor = -16,
        TableFooterBackColor = -37,
        TableFooterTextColor = -38,
        TableHeaderBackColor = -35,
        TableHeaderTextColor = -36,
        ToolTipBackColor = -23,
        ToolTipTextColor = -24,
    }

    public enum WebColorStyle
    {
        AliceBlue = 1,
        AntiqueWhite = 2,
        Aqua = 3,
        Aquamarine = 4,
        Azure = 5,
        Beige = 6,
        Bisque = 7,
        Black = 8,
        BlanchedAlmond = 9,
        Blue = 10,
        BlueViolet = 11,
        Brown = 12,
        BurlyWood = 13,
        CadetBlue = 14,
        Chartreuse = 15,
        Chocolate = 16,
        Coral = 17,
        CornFlowerBlue = 18,
        CornSilk = 19,
        Cream = 20,
        Crimson = 21,
        Cyan = 22,
        DarkBlue = 23,
        DarkCyan = 24,
        DarkGoldenRod = 25,
        DarkGray = 26,
        DarkGreen = 27,
        DarkKhaki = 28,
        DarkMagenta = 29,
        DarkOliveGreen = 30,
        DarkOrange = 31,
        DarkOrchid = 32,
        DarkRed = 33,
        DarkSalmon = 34,
        DarkSeaGreen = 35,
        DarkSlateBlue = 36,
        DarkSlateGray = 37,
        DarkTurquoise = 38,
        DarkViolet = 39,
        DeepPink = 40,
        DeepSkyBlue = 41,
        DimGray = 42,
        DodgerBlue = 43,
        FireBrick = 44,
        FloralWhite = 45,
        ForestGreen = 46,
        Fuchsia = 47,
        Gainsboro = 48,
        GhostWhite = 49,
        Gold = 50,
        Goldenrod = 51,
        Gray = 52,
        Green = 53,
        GreenYellow = 54,
        HoneyDew = 55,
        HotPink = 56,
        IndianRed = 57,
        Indigo = 58,
        Ivory = 59,
        Khaki = 60,
        Lavender = 61,
        LavenderBlush = 62,
        LawnGreen = 63,
        LemonChiffon = 64,
        LightBlue = 65,
        LightCoral = 66,
        LightCyan = 67,
        LightGoldenRod = 68,
        LightGoldenRodYellow = 69,
        LightGray = 71,
        LightGreen = 70,
        LightPink = 72,
        LightSalmon = 73,
        LightSeaGreen = 74,
        LightSkyBlue = 75,
        LightSlateBlue = 76,
        LightSlateGray = 77,
        LightSteelBlue = 78,
        LightYellow = 79,
        Lime = 80,
        LimeGreen = 81,
        Linen = 82,
        Magenta = 83,
        Maroon = 84,
        MediumAquaMarine = 85,
        MediumBlue = 86,
        MediumGray = 87,
        MediumGreen = 88,
        MediumOrchid = 89,
        MediumPurple = 90,
        MediumSeaGreen = 91,
        MediumSlateBlue = 92,
        MediumSpringGreen = 93,
        MediumTurquoise = 94,
        MediumVioletRed = 95,
        MidnightBlue = 96,
        MintCream = 97,
        MistyRose = 98,
        Moccasin = 99,
        NavajoWhite = 100,
        Navy = 101,
        OldLace = 102,
        Olive = 103,
        Olivedrab = 104,
        Orange = 105,
        OrangeRed = 106,
        Orchid = 107,
        PaleGoldenrod = 108,
        PaleGreen = 109,
        PaleTurquoise = 110,
        PaleVioletRed = 111,
        PapayaWhip = 112,
        PeachPuff = 113,
        Peru = 114,
        Pink = 115,
        Plum = 116,
        PowderBlue = 117,
        Purple = 118,
        Red = 119,
        RosyBrown = 120,
        RoyalBlue = 121,
        SaddleBrown = 122,
        Salmon = 123,
        SandyBrown = 124,
        Seagreen = 125,
        SeaShell = 126,
        Sienna = 127,
        Silver = 128,
        SkyBlue = 129,
        SlateBlue = 130,
        SlateGray = 131,
        Snow = 132,
        SpringGreen = 133,
        SteelBlue = 134,
        Tan = 135,
        Teal = 136,
        Thistle = 137,
        Tomato = 138,
        Turquoise = 139,
        Violet = 140,
        VioletRed = 141,
        Wheat = 142,
        White = 143,
        WhiteSmoke = 144,
        Yellow = 145,
        YellowGreen = 146,
    }
}
