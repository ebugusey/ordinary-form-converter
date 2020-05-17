using System;
using Antlr4.Runtime.Tree;
using OFP.ObjectModel.Platform.Fonts;
using OFP.Parser.Extensions;
using OFP.Parser.Generated;

namespace OFP.Parser
{
    /// <summary>
    /// Реализация разбора и хранения значений с типом <see cref="Font"/>
    /// и его дочерних классов.
    /// </summary>
    internal class FontListener : OrdinaryFormBaseListener, IValueCollector<Font>
    {
        private readonly ParseTreeProperty<Font> _values =
            new ParseTreeProperty<Font>();

        private readonly ITokenCollector _tokens;

        public FontListener(ITokenCollector tokenCollector)
        {
            _tokens = tokenCollector;
        }

        public Font Get(IParseTree node)
        {
            var value = _values.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return value;
        }

        public override void ExitRelativeFont(OrdinaryFormParser.RelativeFontContext context)
        {
            var kind = (FontType)_tokens.GetNumber(context.Kind);

            RelativeFont font;
            switch (kind)
            {
                case FontType.AutoFont:
                    font = ParseAutoFont(context);
                    break;
                case FontType.WindowsFont:
                    font = ParseWindowsFont(context);
                    break;
                case FontType.StyleItem:
                    font = ParseStyleItem(context);
                    break;
                default:
                    return;
            }

            _values.Put(context.Parent, font);
        }

        private AutoFont ParseAutoFont(OrdinaryFormParser.RelativeFontContext context)
        {
            var font = new AutoFont();

            FillRelativeFont(font, context);

            return font;
        }

        private WindowsFont ParseWindowsFont(OrdinaryFormParser.RelativeFontContext context)
        {
            var fontStyle = context.fontStyle();
            var style = (WindowsFontStyle)_tokens.GetNumber(fontStyle.Value);

            var font = new WindowsFont
            {
                Style = style,
            };

            FillRelativeFont(font, context);

            return font;
        }

        private RelativeFont ParseStyleItem(OrdinaryFormParser.RelativeFontContext context)
        {
            var fontStyle = context.fontStyle();
            var style = (StandardFontStyle)_tokens.GetNumber(fontStyle.Value);

            var font = new StandardFont
            {
                Style = style,
            };

            FillRelativeFont(font, context);

            return font;
        }

        internal virtual void FillRelativeFont(
            RelativeFont font,
            OrdinaryFormParser.RelativeFontContext context)
        {
            var mask = (FontMask)_tokens.GetNumber(context.Mask);

            var optionalValueSequence = new[]
            {
                FontMask.Size,
                FontMask.Bold,
                FontMask.Italic,
                FontMask.Underline,
                FontMask.Strikeout,
            };

            var offset = 3;
            foreach (var flag in optionalValueSequence)
            {
                if ((mask & flag) == 0)
                {
                    continue;
                }

                var node = context.NUMBER(offset);
                var value = _tokens.GetNumber(node);

                switch (flag)
                {
                    case FontMask.Size:
                        font.Size = ParseSize(value);
                        break;
                    case FontMask.Bold:
                        font.Bold = ParseBold(value);
                        break;
                    case FontMask.Italic:
                        font.Italic = ParseBoolean(value);
                        break;
                    case FontMask.Underline:
                        font.Underline = ParseBoolean(value);
                        break;
                    case FontMask.Strikeout:
                        font.Strikeout = ParseBoolean(value);
                        break;
                    default:
                        break;
                }

                offset++;
            }

            if ((mask & FontMask.FaceName) != 0)
            {
                font.FaceName = _tokens.GetString(context.FaceName);
            }

            font.Scale = (ushort)_tokens.GetNumber(context.Scale);
        }

        public override void ExitAbsoluteFont(OrdinaryFormParser.AbsoluteFontContext context)
        {
            var size = _tokens.GetNumber(context.Size);
            var bold = _tokens.GetNumber(context.Bold);
            var strikeout = _tokens.GetNumber(context.Strikeout);
            var italic = _tokens.GetNumber(context.Italic);
            var underline = _tokens.GetNumber(context.Underline);

            var font = new AbsoluteFont
            {
                FaceName = _tokens.GetString(context.FaceName),
                Size = ParseSize(size),
                Scale = (ushort)_tokens.GetNumber(context.Scale),
                Bold = ParseBold(bold),
                Strikeout = ParseBoolean(strikeout),
                Italic = ParseBoolean(italic),
                Underline = ParseBoolean(underline),
            };

            _values.Put(context.Parent, font);
        }

        internal static ushort ParseSize(long value)
        {
            var size = value / 10;

            return (ushort)size;
        }

        internal static bool ParseBold(long value)
        {
            var result = value switch
            {
                400 => false,
                700 => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };

            return result;
        }

        internal static bool ParseBoolean(long value)
        {
            var result = (value != 0);

            return result;
        }
    }
}
