using System;
using System.Collections.Concurrent;
using System.Globalization;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using OFP.Parser.Annotations;
using OFP.Parser.Extensions;
using Token = OFP.Parser.Generated.OrdinaryFormLexer;

namespace OFP.Parser
{
    /// <summary>
    /// Реализация разбора и хранения токенов (листьев дерева парсинга).
    /// </summary>
    internal class TokenListener : Generated.OrdinaryFormBaseListener, ITokenCollector
    {
        private readonly ParseTreeValue<long> _numbers = new ParseTreeValue<long>();
        private readonly ParseTreeProperty<string> _strings = new ParseTreeProperty<string>();
        private readonly ParseTreeValue<Guid> _guids = new ParseTreeValue<Guid>();
        private readonly ParseTreeProperty<byte[]> _base64Data = new ParseTreeProperty<byte[]>();

        private readonly ConcurrentDictionary<IToken, ITerminalNode> _terminalByToken =
            new ConcurrentDictionary<IToken, ITerminalNode>();

        public long GetNumber(ITerminalNode node)
        {
            return GetValue(_numbers, node);
        }

        public long GetNumber(IToken token)
        {
            var node = GetTerminal(token);
            var value = GetValue(_numbers, node);

            return value;
        }

        public string GetString(ITerminalNode node)
        {
            return GetValue(_strings, node);
        }

        public string GetString(IToken token)
        {
            var node = GetTerminal(token);
            var value = GetValue(_strings, node);

            return value;
        }

        public Guid GetGuid(ITerminalNode node)
        {
            return GetValue(_guids, node);
        }

        public Guid GetGuid(IToken token)
        {
            var node = GetTerminal(token);
            var value = GetValue(_guids, node);

            return value;
        }

        public ReadOnlyMemory<byte> GetBase64(ITerminalNode node)
        {
            return GetValue(_base64Data, node);
        }

        public ReadOnlyMemory<byte> GetBase64(IToken token)
        {
            var node = GetTerminal(token);
            var value = GetValue(_base64Data, node);

            return value;
        }

        private ITerminalNode GetTerminal(IToken token)
        {
            if (!_terminalByToken.TryGetValue(token, out var terminal))
            {
                throw new InvalidOperationException();
            }

            return terminal;
        }

        private static T GetValue<T>(ParseTreeProperty<T> annotations, ITerminalNode node) where T : class
        {
            var value = annotations.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return value;
        }

        private static T GetValue<T>(ParseTreeValue<T> annotations, ITerminalNode node) where T : struct
        {
            var value = annotations.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return (T)value;
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
            _terminalByToken[node.Symbol] = node;
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
            _terminalByToken[node.Symbol] = node;
        }

        private void ParseGuid(ITerminalNode node)
        {
            var text = node.GetText();

            var value = Guid.Parse(text);

            _guids.Put(node, value);
            _terminalByToken[node.Symbol] = node;
        }

        private void ParseBase64(ITerminalNode node)
        {
            var text = node.GetText();

            const string prefix = "#base64:";
            var base64 = text.Substring(prefix.Length);

            var value = Convert.FromBase64String(base64);

            _base64Data.Put(node, value);
            _terminalByToken[node.Symbol] = node;
        }
    }
}
