using System;
using System.Globalization;
using Antlr4.Runtime.Tree;
using OFP.Parser.Annotations;
using OFP.Parser.Extensions;
using Token = OFP.Parser.Generated.OrdinaryFormLexer;

namespace OFP.Parser
{
    internal class TokenListener : Generated.OrdinaryFormBaseListener, ITokenCollector
    {
        private readonly ParseTreeValue<long> _numbers = new ParseTreeValue<long>();
        private readonly ParseTreeProperty<string> _strings = new ParseTreeProperty<string>();
        private readonly ParseTreeValue<Guid> _guids = new ParseTreeValue<Guid>();
        private readonly ParseTreeProperty<byte[]> _base64Data = new ParseTreeProperty<byte[]>();

        public long GetNumber(ITerminalNode node)
        {
            var value = _numbers.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return (long)value;
        }

        public string GetString(ITerminalNode node)
        {
            var value = _strings.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return value;
        }

        public Guid GetGuid(ITerminalNode node)
        {
            var value = _guids.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return (Guid)value;
        }

        public ReadOnlyMemory<byte> GetBase64(ITerminalNode node)
        {
            var data = _base64Data.TryGet(node);
            if (data == null)
            {
                throw new InvalidOperationException();
            }

            return data.AsMemory();
        }

        public override void VisitTerminal(ITerminalNode node)
        {
            switch (node.Symbol.Type)
            {
                case Token.NUMBER:
                    ParseNumber(node);
                    break;

                case Token.STRING:
                    ParseString(node);
                    break;

                case Token.EMPTY_GUID:
                case Token.GUID:
                    ParseGuid(node);
                    break;

                case Token.BASE64:
                    ParseBase64(node);
                    break;

                default:
                    break;
            }
        }

        private void ParseNumber(ITerminalNode node)
        {
            var text = node.GetText();

            var value = long.Parse(
                text,
                NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent,
                CultureInfo.InvariantCulture);

            _numbers.Put(node, value);
        }

        private void ParseString(ITerminalNode node)
        {
            var text = node.GetText();

            var value = text;
            // Срезаем кавычки.
            value = value.Substring(1, text.Length - 2);
            // Заменяем escape-последовательность на реальный символ.
            value = value.Replace("\"\"", "\"");

            _strings.Put(node, value);
        }

        private void ParseGuid(ITerminalNode node)
        {
            var text = node.GetText();

            var value = Guid.Parse(text);

            _guids.Put(node, value);
        }

        private void ParseBase64(ITerminalNode node)
        {
            var text = node.GetText();

            const string prefix = "#base64:";
            var base64 = text.Substring(prefix.Length);

            var value = Convert.FromBase64String(base64);

            _base64Data.Put(node, value);
        }
    }
}
