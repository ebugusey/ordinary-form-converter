using System.Collections.Generic;
using Antlr4.Runtime;
using Autofac;
using NUnit.Framework;
using OFP.Parser.Generated;

namespace OFP.Library.Tests.Parser
{
    /// <summary>
    /// Базовый класс для реализации тестов на listener-ы для обхода
    /// дерева парсера.
    /// <para>
    /// Автоматически инициализирует <see cref="TestSubject"/> перед запуском
    /// тестов и содержит методы для инициализации парсера со всеми его зависимостями.
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
        /// Создать парсер, которые будет парсить переданную
        /// в <paramref name="input"/> строку.
        /// </summary>
        /// <param name="input">Разбираемая парсером строка.</param>
        /// <returns>Инициализированные парсер с подключенными listener-ами.</returns>
        protected OrdinaryFormParser CreateParser(string input)
        {
            var stream = CharStreams.fromstring(input);
            var lexer = new OrdinaryFormLexer(stream);
            var tokens = new CommonTokenStream(lexer);

            var parser = new OrdinaryFormParser(tokens);

            var listeners = _currentScope.Resolve<IEnumerable<IOrdinaryFormListener>>();
            foreach (var listener in listeners)
            {
                parser.AddParseListener(listener);
            }

            return parser;
        }
    }
}
