using System;
using Antlr4.Runtime.Tree;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using OFP.Parser;
using Token = OFP.Parser.Generated.OrdinaryFormLexer;

namespace OFP.Library.Tests.Parser
{
    [TestFixture]
    public class TokenListenerTests
    {
        [Test]
        [TestCase("\"normal text\"", "normal text")]
        [TestCase("\"text with \"\"escaped\"\" quotes\"", "text with \"escaped\" quotes")]
        public void TokenListener_VisitTerminal_ParsesString(string text, string expectedValue)
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal(Token.STRING, text);

            // When.
            listener.VisitTerminal(node);
            var result = listener.GetString(node);

            // Then.
            result.Should().Be(expectedValue);
        }

        [Test]
        [TestCase("123", 123)]
        [TestCase("-123", -123)]
        [TestCase("1.1e1", 11)]
        [TestCase("-1.1e1", -11)]
        [TestCase("1e1", 10)]
        public void TokenListener_VisitTerminal_ParsesNumber(string text, long expectedValue)
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal(Token.NUMBER, text);

            // When.
            listener.VisitTerminal(node);
            var result = listener.GetNumber(node);

            // Then.
            result.Should().Be(expectedValue);
        }

        [Test]
        [TestCase("0.1")]
        [TestCase("1.2")]
        [TestCase("1e1.1")]
        [TestCase(" 123 ")]
        [TestCase("0x20")]
        public void TokenListener_VisitTerminal_ThrowsOnNumberParsingError(string text)
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal(Token.NUMBER, text);

            // When.
            Action action =
                () => listener.VisitTerminal(node);

            // Then.
            action.Should().Throw<SystemException>()
                .Where(ex => ex is OverflowException || ex is FormatException);
        }

        [Test]
        public void TokenListener_VisitTerminal_ParsesGuid()
        {
            // Given.
            var listener = CreateListener();

            var guid = Guid.NewGuid();
            var node = CreateTerminal(Token.GUID, guid.ToString());

            // When.
            listener.VisitTerminal(node);
            var result = listener.GetGuid(node);

            // Then.
            result.Should().Be(guid);
        }

        [Test]
        public void TokenListener_VisitTerminal_ParsesBase64()
        {
            // Given.
            var listener = CreateListener();

            var expectedData = CreateRandomBytes(5, 10);
            var text = "#base64:" + Convert.ToBase64String(expectedData);

            var node = CreateTerminal(Token.BASE64, text);

            // When.
            listener.VisitTerminal(node);
            var result = listener.GetBase64(node);

            // Then.
            result.ToArray().Should().BeEquivalentTo(expectedData);
        }

        [Test]
        public void TokenListener_GetNumber_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = Substitute.For<ITerminalNode>();

            // When.
            Action action =
                () => listener.GetNumber(node);

            // Then.
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void TokenListener_GetString_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal();

            // When.
            Action action =
                () => listener.GetString(node);

            // Then.
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void TokenListener_GetGuid_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal();

            // When.
            Action action =
                () => listener.GetGuid(node);

            // Then.
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void TokenListener_GetBase64_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal();

            // When.
            Action action =
                () => listener.GetBase64(node);

            // Then.
            action.Should().Throw<InvalidOperationException>();
        }

        private static TokenListener CreateListener()
        {
            return new TokenListener();
        }

        private static ITerminalNode CreateTerminal()
        {
            return Substitute.For<ITerminalNode>();
        }

        private static ITerminalNode CreateTerminal(int token, string text)
        {
            var node = Substitute.For<ITerminalNode>();
            node.Symbol.Type.Returns(token);
            node.GetText().Returns(text);

            return node;
        }

        private static byte[] CreateRandomBytes(int minSize, int maxSize)
        {
            var random = TestContext.CurrentContext.Random;

            var size = random.Next(minSize, maxSize);

            var data = new byte[size];
            random.NextBytes(data);

            return data;
        }
    }
}
