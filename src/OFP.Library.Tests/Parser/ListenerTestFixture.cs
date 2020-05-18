using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public abstract class ListenerTestFixture<T> where T : class, IOrdinaryFormListener
    {
        /// <summary>
        /// SUT, тестируемый класс.
        /// Полностью инициализируется перед запуском каждого теста,
        /// и очищается после завершения каждого теста.
        /// </summary>
        protected T TestSubject { get; private set; } = default!;

        /// <summary>
        /// DI контейнер для разрешения зависимостей <see cref="T"/> в тестах.
        /// </summary>
        protected ILifetimeScope Container => _currentScope;

        private IContainer _container = default!;
        private ILifetimeScope _currentScope = default!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(OrdinaryFormParser).Assembly)
                .AssignableTo<IOrdinaryFormListener>()
                .Except<OrdinaryFormBaseListener>()
                .Except<T>()
                .AsImplementedInterfaces().AsSelf()
                .InstancePerLifetimeScope();

            var setupMethod = GetType()
                .GetMethod(nameof(SetupTestSubject), BindingFlags.Instance | BindingFlags.NonPublic);
            var setupOverridden =
                 setupMethod!.DeclaringType != typeof(ListenerTestFixture<T>);
            if (setupOverridden)
            {
                builder.Register(_ => SetupTestSubject()!)
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<T>()
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .InstancePerLifetimeScope();
            }

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

            TestSubject = _currentScope.Resolve<T>();
        }

        [TearDown]
        public void TearDown()
        {
            _currentScope.Dispose();
            _currentScope = null!;
        }

        /// <summary>
        /// Переопредели этот метод, чтобы настроить создание <see cref="TestSubject"/>.
        /// Этот метод вызывается перед выполнением каждого теста.
        /// </summary>
        /// <returns>
        /// Инициализированное значение с типом <see cref="T"/>,
        /// которое должно быть установлено в качестве <see cref="TestSubject"/>.
        /// </returns>
        protected virtual T? SetupTestSubject()
        {
            return null;
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
