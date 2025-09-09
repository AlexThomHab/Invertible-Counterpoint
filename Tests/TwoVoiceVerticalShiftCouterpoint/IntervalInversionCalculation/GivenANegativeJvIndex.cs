using Invertible_Counterpoint.Services;
using NUnit.Framework;
using System.Linq;

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

        [TestCase(-11, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 })]
        [TestCase(-7, new[] { 0, 2, 5, 7 }, new[] { 1, 6 }, new[] { 4 }, new[] { 3 })]
        [TestCase(-6, new[] { 2, 4 }, new[] { 3 }, new[] { 0, 5, 7 }, new[] { 1, 6 })]
        [TestCase(-5, new[] { 0, 5, 7 }, new[] { 6 }, new[] { 2, 4 }, new[] { 1, 3 })]
        [TestCase(-4, new[] { 0, 2, 4 }, new[] { 1, 3 }, new[] { 5, 7 }, new[] { 6 })]
        [TestCase(-3, new[] { 5, 7 }, new[] { 6 }, new[] { 0, 2, 4 }, new[] { 1, 3 })]
        [TestCase(-2, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 })]
        [TestCase(-1, new[] { 5 }, new int[0], new[] { 0, 2, 4, 7 }, new[] { 1, 3, 6 })]
        public void NegativeJV_CasesPass(
            int jvIndex,
            int[] expectedFixedCons,
            int[] expectedFixedDis,
            int[] expectedVarCons,
            int[] expectedVarDis)
        {
            var result = _calculator.Calculate(jvIndex);

            // Compare by Interval.Number
            Assert.That(result.FixedConsonances.Select(i => i.Number), Is.EquivalentTo(expectedFixedCons));
            Assert.That(result.FixedDissonances.Select(i => i.Number), Is.EquivalentTo(expectedFixedDis));
            Assert.That(result.VariableConsonances.Select(i => i.Number), Is.EquivalentTo(expectedVarCons));
            Assert.That(result.VariableDissonances.Select(i => i.Number), Is.EquivalentTo(expectedVarDis));
        }
    }
}