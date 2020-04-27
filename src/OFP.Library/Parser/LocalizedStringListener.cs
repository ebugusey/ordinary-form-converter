using System;
using Antlr4.Runtime.Tree;
using OFP.ObjectModel.Localization;
using OFP.Parser.Extensions;
using OFP.Parser.Generated;

namespace OFP.Parser
{
    /// <summary>
    /// Реализация разбора и хранения значений с типом <see cref="LocalizedString"/>.
    /// </summary>
    internal class LocalizedStringListener : OrdinaryFormBaseListener, IValueCollector<LocalizedString>
    {
        private readonly ParseTreeProperty<LocalizedString> _values =
            new ParseTreeProperty<LocalizedString>();

        private readonly ITokenCollector _tokens;

        public LocalizedStringListener(ITokenCollector tokenCollector)
        {
            _tokens = tokenCollector;
        }

        public override void ExitLocalizedString(OrdinaryFormParser.LocalizedStringContext context)
        {
            var entireString = new LocalizedString();

            var count = _tokens.GetNumber(context.Count);
            for (int i = 0; i < count; i++)
            {
                var item = context.localizedStringItem(i);

                var locale = (Locale)_tokens.GetString(item.Locale);
                var value = _tokens.GetString(item.Value);

                entireString.Add(locale, value);
            }

            _values.Put(context, entireString);
        }

        public LocalizedString Get(IParseTree node)
        {
            var value = _values.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return value;
        }
    }
}
