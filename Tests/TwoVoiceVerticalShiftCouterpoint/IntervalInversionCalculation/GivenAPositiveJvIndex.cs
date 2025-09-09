using Invertible_Counterpoint.Services;
using NUnit.Framework;

namespace Tests.TwoVoiceVerticalShiftCouterpoint.IntervalInversionCalculation
{
    public class GivenAPositiveJvIndex
    {
        private TwoVoiceShiftedIntervalsGivenJvIndexCalculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();
        }

        [TestCase(0, new[] { 0, 2, 4, 5, 7 }, new[] { 1, 3, 6 }, new int[0], new int[0])]
        [TestCase(1, new[] { 4 }, new int[0], new[] { 0, 2, 5, 7 }, new[] { 1, 3, 6 })]
        [TestCase(2, new[] { 0, 2, 5, 7 }, new[] { 1, 6 }, new[] { 4 }, new[] { 3 })]
        [TestCase(3, new[] { 2, 4 }, new[] { 3 }, new[] { 0, 5, 7 }, new[] { 1, 6 })]
        [TestCase(4, new[] { 0, 5, 7 }, new[] { 6 }, new[] { 2, 4 }, new[] { 1, 3 })]
        [TestCase(5, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 })]
        [TestCase(6, new[] { 5 }, new int[0], new[] { 0, 2, 4, 7 }, new[] { 1, 3, 6 })]
        [TestCase(7, new[] { 0, 2, 4, 5, 7 }, new[] { 1, 3, 6 }, new int[0], new int[0])]

        [TestCase(8, new[] { 4 }, new int[0], new[] { 0, 2, 5, 7 }, new[] { 1, 3, 6 })]
        [TestCase(9, new[] { 0, 2, 5, 7 }, new[] { 1, 6 }, new[] { 4 }, new[] { 3 })]
        [TestCase(10, new[] { 2, 4 }, new[] { 3 }, new[] { 0, 5, 7 }, new[] { 1, 6 })]
        [TestCase(11, new[] { 0, 5, 7 }, new[] { 6 }, new[] { 2, 4 }, new[] { 1, 3 })]
        [TestCase(12, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 })]
        [TestCase(13, new[] { 5 }, new int[0], new[] { 0, 2, 4, 7 }, new[] { 1, 3, 6 })]
        [TestCase(14, new[] { 0, 2, 4, 5, 7 }, new[] { 1, 3, 6 }, new int[0], new int[0])]
        [TestCase(15, new[] { 4 }, new int[0], new[] { 0, 2, 5, 7 }, new[] { 1, 3, 6 })]

        [TestCase(16, new[] { 0, 2, 5, 7 }, new[] { 1, 6 }, new[] { 4 }, new[] { 3 })]
        [TestCase(17, new[] { 2, 4 }, new[] { 3 }, new[] { 0, 5, 7 }, new[] { 1, 6 })]
        [TestCase(18, new[] { 0, 5, 7 }, new[] { 6 }, new[] { 2, 4 }, new[] { 1, 3 })]
        [TestCase(19, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 })]
        [TestCase(20, new[] { 5 }, new int[0], new[] { 0, 2, 4, 7 }, new[] { 1, 3, 6 })]

        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned(
            int jvIndex,
            int[] expectedFixedCons,
            int[] expectedFixedDis,
            int[] expectedVarCons,
            int[] expectedVarDis)
        {
            var result = _calculator.Calculate(jvIndex);

            Assert.That(result.FixedConsonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedFixedCons));
            Assert.That(result.FixedDissonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedFixedDis));
            Assert.That(result.VariableConsances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedVarCons));
            Assert.That(result.VariableDissonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedVarDis));
        }
    }
}
