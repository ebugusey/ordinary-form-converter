using System;
using System.Collections.Generic;
using Autofac;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using OFP.ObjectModel.Platform.Fonts;
using OFP.Parser;

namespace OFP.Library.Tests.Parser
{
    /// <summary>
    /// Тесты на <see cref="FontListener"/>.
    /// </summary>
    [TestFixture]
    internal class FontListenerTests : ListenerTestFixture<FontListener>
    {
        [Test]
        public void FontListener_Get_ReturnsParsedAbsoluteFont()
        {
            // Given.
            var input = "{7, 0, 0, 100, 0, 0, 0, 400, 1, 0, 1, 0,0,0,0,0, \"Arial\", 1, 120}";
            var expected = new AbsoluteFont
            {
                FaceName = "Arial",
                Size = 10,
                Bold = false,
                Italic = true,
                Underline = false,
                Strikeout = true,
                Scale = 120,
            };

            var paser = CreateParser(input);
            var tree = paser.font();
            WalkParseTree(tree);

            // When.
            var font = TestSubject.Get(tree);

            // Then.
            font.Should().BeOfType<AbsoluteFont>()
                .And.BeEquivalentTo(expected);
        }

        [Test]
        public void FontListener_Get_ThrowsWhenTreeDoesntHaveAbsoluteFont()
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

        private static IEnumerable<TestCaseData> GetRelativeFontCases()
        {
            string input;
            RelativeFont expected;

            input = "{7, 3, 0, 1, 100}";
            expected = new AutoFont
            {
                Scale = 100,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Без изменений");

            input = "{7, 3, 4, 400, 1, 110}";
            expected = new AutoFont
            {
                Bold = false,
                Scale = 110,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Полужирный");

            input = "{7, 3, 8, 1, 1, 120}";
            expected = new AutoFont
            {
                Italic = true,
                Scale = 120,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Курсив");

            input = "{7, 3, 12, 700, 0, 1, 130}";
            expected = new AutoFont
            {
                Bold = true,
                Italic = false,
                Scale = 130,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Полужирный и курсив");

            input = "{7, 3, 1, \"Times New Roman\", 1, 140}";
            expected = new AutoFont
            {
                FaceName = "Times New Roman",
                Scale = 140,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Имя шрифта");

            input = "{7, 3, 61, 700, 1, 1, 1, \"Arial\", 1, 150}";
            expected = new AutoFont
            {
                Bold = true,
                Italic = true,
                Underline = true,
                Strikeout = true,
                FaceName = "Arial",
                Scale = 150,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Полностью заполнен");

            input = "{7, 1, 61, { 0 }, 700, 1, 1, 1, \"Lucida Console\", 1, 160}";
            expected = new WindowsFont
            {
                Bold = true,
                Italic = true,
                Underline = true,
                Strikeout = true,
                FaceName = "Lucida Console",
                Scale = 160,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames("Полностью заполненный StyleBasedFont");
        }

        [Test]
        [TestCaseSource(nameof(GetRelativeFontCases))]
        public void FontListener_FillRelativeFont_FillsRelativeFontOptionalValues(string input, RelativeFont expected)
        {
            // Given.
            var font = new AutoFont();

            var parser = CreateParser(input);
            var tree = parser.font();
            WalkParseTree(tree);

            // When.
            TestSubject.FillRelativeFont(font, tree.relativeFont());

            // Then.
            font.Should().BeEquivalentTo(expected, opt => opt
                .Excluding(x => x.Type));
        }

        [Test]
        public void FontListener_Get_ReturnsParsedAutoFont()
        {
            // Given.
            var input = "{7, 3, 12, 700, 1, 1, 100}";
            var expected = new AutoFont
            {
                Bold = true,
                Italic = true,
                Scale = 100,
            };

            var parser = CreateParser(input);
            var tree = parser.font();
            WalkParseTree(tree);

            // When.
            var font = TestSubject.Get(tree);

            // Then.
            font.Should().BeOfType<AutoFont>()
                .And.BeEquivalentTo(expected);

            TestSubject.Received(1)
                .FillRelativeFont((RelativeFont)font, tree.relativeFont());
        }

        private static IEnumerable<TestCaseData> GetWindowsFontCases()
        {
            var input = "{7, 1, 0, { 4 }, 1, 100}";
            var expected = new WindowsFont
            {
                Style = WindowsFontStyle.SystemFont,
                Scale = 100,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames(WindowsFontStyle.SystemFont.ToString());

            input = "{7, 1, 4, { 0 }, 400, 1, 110}";
            expected = new WindowsFont
            {
                Style = WindowsFontStyle.DefaultGUIFont,
                Bold = false,
                Scale = 110,
            };

            yield return
                new TestCaseData(input, expected)
                .SetArgDisplayNames(WindowsFontStyle.DefaultGUIFont.ToString());
        }

        [Test]
        [TestCaseSource(nameof(GetWindowsFontCases))]
        public void FontListener_Get_ReturnsParsedWindowsFont(string input, WindowsFont expected)
        {
            // Given.
            var parser = CreateParser(input);
            var tree = parser.font();
            WalkParseTree(tree);

            // When.
            var font = TestSubject.Get(tree);

            // Then.
            font.Should().BeOfType<WindowsFont>()
                .And.BeEquivalentTo(expected);

            TestSubject.Received(1)
                .FillRelativeFont((RelativeFont)font, tree.relativeFont());
        }

        [Test]
        [TestCase(100, (ushort)10)]
        [TestCase(110, (ushort)11)]
        [TestCase(10, (ushort)1)]
        public void FontListener_ParseSize_ParsesFontSize(long value, ushort expected)
        {
            // When.
            var result = FontListener.ParseSize(value);

            // Then.
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(400, false)]
        [TestCase(700, true)]
        public void FontListener_ParseBold_ParsesFontBoldness(long value, bool expected)
        {
            // When.
            var result = FontListener.ParseBold(value);

            // Then.
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void FontListener_ParseBoolean_ParsesBooleanValue(long value, bool expected)
        {
            // When.
            var result = FontListener.ParseBoolean(value);

            // Then.
            result.Should().Be(expected);
        }

        protected override FontListener? SetupTestSubject()
        {
            var tokens = Container.Resolve<ITokenCollector>();
            var testSubject = Substitute.ForPartsOf<FontListener>(tokens);

            return testSubject;
        }
    }
}
