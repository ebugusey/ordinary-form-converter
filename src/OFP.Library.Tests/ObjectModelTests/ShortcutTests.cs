using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using OFP.ObjectModel.Platform;

namespace OFP.Library.Tests.ObjectModelTests
{
    /// <summary>
    /// Тесты на <see cref="Shortcut"/>.
    /// </summary>
    [TestFixture]
    public class ShortcutTests
    {
        private static IEnumerable<TestCaseData> GetEqualValues()
        {
            var left = new Shortcut(Key.M, KeyModifier.Alt);
            var right = new Shortcut(Key.M, KeyModifier.Alt);

            yield return
                new TestCaseData(left, right);

            left = new Shortcut(Key.BackSpace, KeyModifier.None);
            right = new Shortcut(Key.BackSpace, KeyModifier.None);

            yield return
                new TestCaseData(left, right);
        }

        [Test]
        [TestCaseSource(nameof(GetEqualValues))]
        public void Shortcut_Equals_ChecksEquality(object left, object right)
        {
            var result = left.Equals(right);

            result.Should().BeTrue();
        }

        [Test]
        [TestCaseSource(nameof(GetEqualValues))]
        public void Shortcut_OpEquality_ChecksEquality(Shortcut left, Shortcut right)
        {
            var result = left == right;

            result.Should().BeTrue();
        }

        private static IEnumerable<TestCaseData> GetUnequalValues()
        {
            var left = new Shortcut(Key.A, KeyModifier.None);
            var right = new Shortcut(Key.A, KeyModifier.Alt);

            yield return
                new TestCaseData(left, right);

            left = new Shortcut(Key.B, KeyModifier.Alt);
            right = new Shortcut(Key.C, KeyModifier.Alt);

            yield return
                new TestCaseData(left, right);

            left = new Shortcut(Key.M, KeyModifier.Alt | KeyModifier.Shift);
            right = new Shortcut(Key.N, KeyModifier.Ctrl);

            yield return
                new TestCaseData(left, right);
        }

        [Test]
        [TestCaseSource(nameof(GetUnequalValues))]
        public void Shortcut_Equals_ChecksInequality(object left, object right)
        {
            var result = left.Equals(right);

            result.Should().BeFalse();
        }

        [Test]
        [TestCaseSource(nameof(GetUnequalValues))]
        public void Shortcut_OpInequality_ChecksInequality(Shortcut left, Shortcut right)
        {
            var result = left != right;

            result.Should().BeTrue();
        }
    }
}
