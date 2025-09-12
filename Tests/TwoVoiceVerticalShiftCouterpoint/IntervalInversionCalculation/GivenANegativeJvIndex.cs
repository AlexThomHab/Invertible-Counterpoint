using System.Linq;
using Invertible_Counterpoint.Services;
using NUnit.Framework;

namespace Tests.TwoVoiceVerticalShiftCouterpoint.IntervalInversionCalculation
{
    public class GivenANegativeJvIndex
    {
        private TwoVoiceShiftedIntervalsGivenJvIndexCalculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();
        }

        [TestCase(-11, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 }, new int[0])] // -11 ≡ 3 → none
        [TestCase(-7, new[] { 0, 2, 5, 7 }, new[] { 1, 6 }, new[] { 4 }, new[] { 3 }, new int[0])] // -7  ≡ 0 → none
        [TestCase(-6, new[] { 2, 4 }, new[] { 3 }, new[] { 0, 5, 7 }, new[] { 1, 6 }, new[] { 2 })] // -6 ≡ 1 → none
        [TestCase(-5, new[] { 0, 5, 7 }, new[] { 6 }, new[] { 2, 4 }, new[] { 1, 3 }, new[] { 5 })] // -5 ≡ 2 → {2,5}∩fixed = {5}
        [TestCase(-4, new[] { 0, 2, 4 }, new[] { 1, 3 }, new[] { 5, 7 }, new[] { 6 }, new int[0])] // -4 ≡ 3 → none
        [TestCase(-3, new[] { 5, 7 }, new[] { 6 }, new[] { 0, 2, 4 }, new[] { 1, 3 }, new int[0])] // -3 ≡ 4 → none
        [TestCase(-2, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 }, new[] { 2 })] // -2 ≡ 5 → {2}
        [TestCase(-1, new[] { 5 }, new int[0], new[] { 0, 2, 4, 7 }, new[] { 1, 3, 6 }, new[] { 5 })] // -1 ≡ 6 → {5}
        public void NegativeJV_CasesPass(
            int jvIndex,
            int[] expectedFixedCons,
            int[] expectedFixedDis,
            int[] expectedVarCons,
            int[] expectedVarDis,
            int[] expectedImperfectToPerfect)
        {
            var result = _calculator.Calculate(jvIndex);

            // Category membership checks
            Assert.That(result.FixedConsonances.Select(i => i.Number), Is.EquivalentTo(expectedFixedCons));
            Assert.That(result.FixedDissonances.Select(i => i.Number), Is.EquivalentTo(expectedFixedDis));
            Assert.That(result.VariableConsonances.Select(i => i.Number), Is.EquivalentTo(expectedVarCons));
            Assert.That(result.VariableDissonances.Select(i => i.Number), Is.EquivalentTo(expectedVarDis));

            var flagged = result.FixedConsonances
                .Where(x => x.IsImperfectBecomesPerfect)
                .Select(x => x.Number)
                .ToArray();

            Assert.That(flagged, Is.EquivalentTo(expectedImperfectToPerfect),
                "Only the specified fixed consonances should be flagged as imperfect→perfect.");

            var notFlagged = result.FixedConsonances
                .Where(x => !expectedImperfectToPerfect.Contains(x.Number))
                .ToList();

            Assert.That(notFlagged.All(x => !x.IsImperfectBecomesPerfect), Is.True,
                "No other fixed consonances should be flagged as imperfect→perfect.");
        }
    }
}
