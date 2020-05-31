using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using OFP.ObjectModel.Platform;
using OFP.Parser;

namespace OFP.Library.Tests.Parser
{
    /// <summary>
    /// Тесты на <see cref="ShortcutListener"/>.
    /// </summary>
    [TestFixture]
    internal class ShortcutLIstenerTests : ListenerTestFixture<ShortcutListener>
    {
        private static IEnumerable<TestCaseData> GetShortcutCases()
        {
            var input = "{0, 65, 0}";
            var expected = new Shortcut(Key.A);

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("A");

            input = "{0, 67, 8}";
            expected = new Shortcut(Key.C, KeyModifier.Ctrl);

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Ctrl+C");

            input = "{0, 111, 24}";
            expected = new Shortcut(Key.NumDivide, KeyModifier.Ctrl | KeyModifier.Alt);

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Ctrl+Alt+/");

            input = "{0, 32, 28}";
            expected = new Shortcut(Key.Space, KeyModifier.Ctrl | KeyModifier.Alt | KeyModifier.Shift);

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Ctrl+Alt+Shift+Space");
        }

        [Test]
        [TestCaseSource(nameof(GetShortcutCases))]
        public void ShortcutListener_Get_ReturnsParsedShortcut(string input, Shortcut expected)
        {
            var parser = CreateParser(input);
            var tree = parser.shortcut();
            WalkParseTree(tree);

            var result = TestSubject.Get(tree);

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShortcutListener_Get_ThrowsWhenTreeDoesntHaveShortcut()
        {
            var parser = CreateParser("{}");
            var tree = parser.emptyBlock();
            WalkParseTree(tree);

            Action action =
                () => TestSubject.Get(tree);

            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"Для узла дерева не найден элемент с типом {nameof(Shortcut)}.");
        }
    }
}
