using System;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using NSubstitute;
using NUnit.Framework;
using OFP.Parser;

namespace OFP.Library.Tests.Parser
{
    /// <summary>
    /// Тесты на <see cref="ProxyParseTreeListener"/>.
    /// </summary>
    [TestFixture]
    public class ProxyParseTreeListenerTests
    {
        private ParserRuleContext _context = default!;
        private IParseTreeListener[] _listeners = default!;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<ParserRuleContext>();
            // Этот метод переопределен в этом классе.
            // Если его не переопределить в тестах,
            // в текстах ошибок будет пустая строка.
            _context.ToString()
                .Returns(nameof(ParserRuleContext));

            _listeners = new[]
            {
                Substitute.For<IParseTreeListener>(),
                Substitute.For<IParseTreeListener>(),
            };
        }

        [Test]
        public void ProxyParseTreeListener_EnterEveryRule_DispatchesToAllListeners()
        {
            // Given.
            var dispatcher = new ProxyParseTreeListener(_listeners);

            // When.
            dispatcher.EnterEveryRule(_context);

            // Then.
            foreach (var listener in _listeners)
            {
                listener.Received(1)
                    .EnterEveryRule(_context);

                listener.DidNotReceiveWithAnyArgs()
                    .ExitEveryRule(default);
            }
        }

        [Test]
        public void ProxyParseTreeListener_EnterEveryRule_DispatchesListenersToContext()
        {
            // Given.
            var dispatcher = new ProxyParseTreeListener(_listeners);

            // When.
            dispatcher.EnterEveryRule(_context);

            // Then.
            _context.Received(_listeners.Length)
                .EnterRule(Arg.Is<IParseTreeListener>(x =>
                    _listeners.Contains(x)));

            _context.DidNotReceiveWithAnyArgs()
                .ExitRule(default);
        }

        [Test]
        public void ProxyParseTreeListener_ExitEveryRule_DispatchesToAllListeners()
        {
            // Given.
            var dispatcher = new ProxyParseTreeListener(_listeners);

            // When.
            dispatcher.ExitEveryRule(_context);

            // Then.
            foreach (var listener in _listeners)
            {
                listener.Received(1)
                    .ExitEveryRule(_context);

                listener.DidNotReceiveWithAnyArgs()
                    .EnterEveryRule(default);
            }
        }

        [Test]
        public void ProxyParseTreeListener_ExitEveryRule_DispatchesListenerToContext()
        {
            // Given.
            var dispatcher = new ProxyParseTreeListener(_listeners);

            // When.
            dispatcher.ExitEveryRule(_context);

            // Then.
            _context.Received(_listeners.Length)
                .ExitRule(Arg.Is<IParseTreeListener>(x =>
                    _listeners.Contains(x)));

            _context.DidNotReceiveWithAnyArgs()
                .EnterRule(default);
        }

        [Test]
        public void ProxyParseTreeListener_VisitErrorNode_DispatchesToAllListeners()
        {
            // Given.
            var node = Substitute.For<IErrorNode>();
            var dispatcher = new ProxyParseTreeListener(_listeners);

            // When.
            dispatcher.VisitErrorNode(node);

            // Then.
            foreach (var listener in _listeners)
            {
                listener.Received(1)
                    .VisitErrorNode(node);

                listener.DidNotReceiveWithAnyArgs()
                    .VisitTerminal(default);
            }
        }

        [Test]
        public void ProxyParseTreeListener_VisitTerminal_DispatchesToAllListeners()
        {
            // Given.
            var node = Substitute.For<ITerminalNode>();
            var dispatcher = new ProxyParseTreeListener(_listeners);

            // When.
            dispatcher.VisitTerminal(node);

            // Then.
            foreach (var listener in _listeners)
            {
                listener.Received(1)
                    .VisitTerminal(node);
            }
        }
    }
}
