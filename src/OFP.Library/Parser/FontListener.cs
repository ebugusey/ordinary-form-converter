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
