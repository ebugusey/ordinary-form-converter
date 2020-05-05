using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using OFP.ObjectModel.Localization;
using OFP.Parser;

namespace OFP.Library.Tests.Parser
{
    /// <summary>
    /// Тесты на <see cref="LocalizedStringListener"/>.
    /// </summary>
    [TestFixture]
    internal class LocalizedStringListenerTests : ListenerTestFixture<LocalizedStringListener>
    {
        private static IEnumerable<TestCaseData> GetTestCases()
        {
            var input = "{1, 1, { \"ru\", \"Текст\" }}";
            var expected = new LocalizedString
            {
                ["ru"] = "Текст",
            };

            yield return
                new TestCaseData(input, expected)
                    .SetArgDisplayNames("Один элемент");

            input = "{1, 2, { \"ru\", \"Русский текст\" }, { \"en\", \"English text\" }}";
            expected = new LocalizedString
            {
                ["ru"] = "Русский текст",
                ["en"] = "English text",
            };

            yield return
                new TestCaseData(input, expected)
                    .SetArgDisplayNames("Несколько элементов");

            input = "{1, 2, { \"ru\", \"Русский текст\" }, { \"en\", \"English text\" }, { \"unknown\", \"Неизвестный элемент\" }}";
            expected = new LocalizedString
            {
                ["ru"] = "Русский текст",
                ["en"] = "English text",
            };

            yield return
                new TestCaseData(input, expected)
                    .SetArgDisplayNames("Количество элементов, меньше чем элементов на самом деле");
        }

        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void LocalizedStringListener_Get_ShouldContainParsedValue(string input, LocalizedString expected)
        {
            // Given.
            var parser = CreateParser(input);
            var tree = parser.localizedString();
            WalkParseTree(tree);

            // When.
            var result = TestSubject.Get(tree);

            // Then.
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void LocalizedStringListener_Get_ThrowsWhenTreeDoesntHaveLocalizedString()
        {
            // Given.
            var parser = CreateParser("{}");
            var tree = parser.emptyBlock();
            WalkParseTree(tree);

            // When.
            Action action =
                () => TestSubject.Get(tree);

            // Then.
            action.Should().Throw<InvalidOperationException>();
        }
    }
}
