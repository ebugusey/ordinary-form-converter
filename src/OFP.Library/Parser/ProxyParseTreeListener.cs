using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace OFP.Parser
{
    /// <summary>
    /// Позволяет использовать несколько listener-ов для обхода
    /// дерева парсинга.
    /// <para>
    /// В <see cref="ParseTreeWalker"/> можно использовать только один listener
    /// для обхода дерева. Так как <see cref="Generated.IOrdinaryFormListener"/>
    /// это достаточно большой интерфейс, его реализация разделена на несколько классов,
    /// что не позволяет использовать стандартный <see cref="ParseTreeWalker"/>
    /// для обхода дерева.
    /// </para>
    /// </summary>
    internal class ProxyParseTreeListener : IParseTreeListener
    {
        private readonly IEnumerable<IParseTreeListener> _listeners;

        /// <summary>
        /// Инициализировать новый экземпляр <see cref="ProxyParseTreeListener"/>.
        /// </summary>
        /// <param name="listeners">
        /// Список <see cref="IParseTreeListener"/>, в которые будут перебрасываться
        /// вызовы этого класса.
        /// </param>
        public ProxyParseTreeListener(IEnumerable<IParseTreeListener> listeners)
        {
            _listeners = listeners;
        }

        public void EnterEveryRule(ParserRuleContext ctx)
        {
            foreach (var listener in _listeners)
            {
                listener.EnterEveryRule(ctx);
                ctx.EnterRule(listener);
            }
        }

        public void ExitEveryRule(ParserRuleContext ctx)
        {
            foreach (var listener in _listeners)
            {
                ctx.ExitRule(listener);
                listener.ExitEveryRule(ctx);
            }
        }

        public void VisitErrorNode(IErrorNode node)
        {
            foreach (var listener in _listeners)
            {
                listener.VisitErrorNode(node);
            }
        }

        public void VisitTerminal(ITerminalNode node)
        {
            foreach (var listener in _listeners)
            {
                listener.VisitTerminal(node);
            }
        }
    }
}
