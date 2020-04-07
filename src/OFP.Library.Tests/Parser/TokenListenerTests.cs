using System;
using Antlr4.Runtime.Tree;
using FluentAssertions;
using FluentAssertions.Execution;
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
            var resultByTerminal = listener.GetString(node);
            var resultByToken = listener.GetString(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                resultByTerminal.Should().Be(expectedValue);
                resultByToken.Should().Be(expectedValue);
            }
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
            var resultByTerminal = listener.GetNumber(node);
            var resultByToken = listener.GetNumber(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                resultByTerminal.Should().Be(expectedValue);
                resultByToken.Should().Be(expectedValue);
            }
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
            var resultByTerminal = listener.GetGuid(node);
            var resultByToken = listener.GetGuid(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                resultByTerminal.Should().Be(guid);
                resultByToken.Should().Be(guid);
            }
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
            var resultByTerminal = listener.GetBase64(node);
            var resultByToken = listener.GetBase64(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                resultByTerminal.ToArray().Should().BeEquivalentTo(expectedData);
                resultByToken.ToArray().Should().BeEquivalentTo(expectedData);
            }
        }

        [Test]
        public void TokenListener_GetNumber_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal();

            // When.
            Action byTerminal =
                () => listener.GetNumber(node);
            Action byToken =
                () => listener.GetNumber(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                byTerminal.Should().Throw<InvalidOperationException>();
                byToken.Should().Throw<InvalidOperationException>();
            }
        }

        [Test]
        public void TokenListener_GetString_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal();

            // When.
            Action byTerminal =
                () => listener.GetString(node);
            Action byToken =
                () => listener.GetString(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                byTerminal.Should().Throw<InvalidOperationException>();
                byToken.Should().Throw<InvalidOperationException>();
            }
        }

        [Test]
        public void TokenListener_GetGuid_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal();

            // When.
            Action byTerminal =
                () => listener.GetGuid(node);
            Action byToken =
                () => listener.GetGuid(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                byTerminal.Should().Throw<InvalidOperationException>();
                byToken.Should().Throw<InvalidOperationException>();
            }
        }

        [Test]
        public void TokenListener_GetBase64_ThrowsWhenTokenNotParsed()
        {
            // Given.
            var listener = CreateListener();
            var node = CreateTerminal();

            // When.
            Action byTerminal =
                () => listener.GetBase64(node);
            Action byToken =
                () => listener.GetBase64(node.Symbol);

            // Then.
            using (new AssertionScope())
            {
                byTerminal.Should().Throw<InvalidOperationException>();
                byToken.Should().Throw<InvalidOperationException>();
            }
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
