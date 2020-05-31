using System;
using Antlr4.Runtime.Tree;
using OFP.ObjectModel.Platform;
using OFP.Parser.Annotations;
using OFP.Parser.Generated;

namespace OFP.Parser
{
    /// <summary>
    /// Реализация разбора и хранения значений с типом <see cref="Shortcut"/>.
    /// </summary>
    internal class ShortcutListener : OrdinaryFormBaseListener, IValueCollector<Shortcut>
    {
        private readonly ParseTreeValue<Shortcut> _values =
            new ParseTreeValue<Shortcut>();

        private readonly ITokenCollector _tokens;

        public ShortcutListener(ITokenCollector tokenCollector)
        {
            _tokens = tokenCollector;
        }

        public Shortcut Get(IParseTree node)
        {
            var value = _values.TryGet(node);
            if (value == null)
            {
                throw new InvalidOperationException(
                    $"Для узла дерева не найден элемент с типом {nameof(Shortcut)}.");
            }

            return (Shortcut)value;
        }

        public override void ExitShortcut(OrdinaryFormParser.ShortcutContext context)
        {
            var key = (Key)_tokens.GetNumber(context.Key);
            var modifier = (KeyModifier)_tokens.GetNumber(context.Modifier);

            var shortcut = new Shortcut(key, modifier);

            _values.Put(context, shortcut);
        }
    }
}
