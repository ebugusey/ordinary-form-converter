using System;
using FluentAssertions;
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
    }
}
