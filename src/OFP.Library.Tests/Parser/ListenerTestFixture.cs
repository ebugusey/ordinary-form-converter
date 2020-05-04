using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Autofac;
using NUnit.Framework;
using OFP.Parser;
using OFP.Parser.Generated;

namespace OFP.Library.Tests.Parser
{
    /// <summary>
    /// Базовый класс для реализации тестов на listener-ы для обхода
    /// дерева парсера.
    /// <para>
    /// Автоматически инициализирует <see cref="TestSubject"/> перед запуском
    /// тестов и содержит методы для инициализации парсера со всеми его зависимостями
    /// и обхода дерева, полученного в результате работы парсера.
    /// </para>
    /// </summary>
    /// <typeparam name="T">Тип тестируемого listener-а.</typeparam>
    public abstract class ListenerTestFixture<T> where T : IOrdinaryFormListener
    {
        /// <summary>
        /// SUT, тестируемый класс.
        /// Полностью инициализируется перед запуском каждого теста,
        /// и очищается после завершения каждого теста.
        /// </summary>
        public T TestSubject { get; set; } = default!;

        private IContainer _container = default!;
        private ILifetimeScope _currentScope = default!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(OrdinaryFormParser).Assembly)
                .AsImplementedInterfaces().AsSelf()
                .InstancePerLifetimeScope();

            _container = builder.Build();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _container.Dispose();
            _container = null!;
        }

        [SetUp]
        public void SetUp()
        {
            _currentScope = _container.BeginLifetimeScope();
            _currentScope.InjectProperties(this);
        }

        [TearDown]
        public void TearDown()
        {
            _currentScope.Dispose();
            _currentScope = null!;
        }

        /// <summary>
        /// Создать парсер, который будет парсить переданную
        /// в <paramref name="input"/> строку.
        /// <para>
        /// Listener-ы подключаются, чтобы проверить их работу
        /// используй <see cref="WalkParseTree(IParseTree)"/>.
        /// </para>
        /// </summary>
        /// <param name="input">Разбираемая парсером строка.</param>
        /// <returns>Инициализированный парсер.</returns>
        protected OrdinaryFormParser CreateParser(string input)
        {
            var stream = CharStreams.fromstring(input);
            var lexer = new OrdinaryFormLexer(stream);
            var tokens = new CommonTokenStream(lexer);

            var parser = new OrdinaryFormParser(tokens)
            {
                ErrorHandler = new BailErrorStrategy(),
            };

            return parser;
        }

        /// <summary>
        /// Обойти дерево парсинга при помощи <see cref="ParseTreeWalker"/>.
        /// Подключаются все listener-ы из сборки <see cref="OFP.Library"/>.
        /// </summary>
        /// <param name="tree">
        /// Корень дерева, которое будет обходить <see cref="ParseTreeWalker"/>.
        /// </param>
        protected void WalkParseTree(IParseTree tree)
        {
            var listeners = _currentScope.Resolve<IEnumerable<IOrdinaryFormListener>>();
            var dispatcher = new ProxyParseTreeListener(listeners);

            var walker = ParseTreeWalker.Default;
            walker.Walk(dispatcher, tree);
        }
    }
}
