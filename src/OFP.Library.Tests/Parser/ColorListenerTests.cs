using System;
using System.Collections.Generic;
using Autofac;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using OFP.ObjectModel.Platform.Colors;
using OFP.Parser;

namespace OFP.Library.Tests.Parser
{
    /// <summary>
    /// Тесты на <see cref="ColorListener"/>
    /// </summary>
    [TestFixture]
    internal class ColorListenerTests : ListenerTestFixture<ColorListener>
    {
        [Test]
        public void ColorListeber_Get_ReturnsParsedAutoColor()
        {
            // Given
            var input = "{3, 4, {0}}";
            var expected = new AutoColor();

            var parser = CreateParser(input);
            var tree = parser.color();
            WalkParseTree(tree);

            // When
            var color = TestSubject.Get(tree);

            // Then
            color.Should().BeOfType<AutoColor>()
                .And.BeEquivalentTo(expected);

        }
    }
}
