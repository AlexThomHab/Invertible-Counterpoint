using Invertible_Counterpoint;
using NUnit.Framework;

namespace Tests.IntervalInversionCalculation
{
    public class GivenAPositiveJvIndex
    {
        private InvertedIntervalsCalculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new InvertedIntervalsCalculator();
        }

        [TestCase(0, new[] { 0, 2, 4, 5, 7 }, new[] { 1, 3, 6 }, new int[0], new int[0])]
        [TestCase(1, new[] { 4, 7 }, new int[0], new[] { 0, 2, 5 }, new[] { 1, 3, 6 })]
        [TestCase(2, new[] { 0, 2, 5 }, new[] { 1 }, new[] { 4, 7 }, new[] { 3, 6 })]
        [TestCase(3, new[] { 2, 4, 5, 7 }, new[] { 3, 6 }, new[] { 0 }, new[] { 1 })]
        [TestCase(4, new[] { 0, 4 }, new int[0], new[] { 2, 5, 7 }, new[] { 1, 3, 6 })]
        [TestCase(5, new[] { 0, 2, 5, 7 }, new[] { 1, 6 }, new[] { 4 }, new[] { 3 })]
        [TestCase(6, new[] { 2, 4, 7 }, new[] { 3 }, new[] { 0, 5 }, new[] { 1, 6 })]
        [TestCase(7, new[] { 0, 5 }, new int[0], new[] { 2, 4, 7 }, new[] { 1, 3, 6 })]

        [TestCase(8, new[] { 0, 2, 4, 5, 7 }, new[] { 1, 3, 6 }, new int[0], new int[0])]
        [TestCase(9, new[] { 4, 7 }, new int[0], new[] { 0, 2, 5 }, new[] { 1, 3, 6 })]
        [TestCase(10, new[] { 0, 2, 5 }, new[] { 1 }, new[] { 4, 7 }, new[] { 3, 6 })]
        [TestCase(11, new[] { 2, 4, 5, 7 }, new[] { 3, 6 }, new[] { 0 }, new[] { 1 })]
        [TestCase(12, new[] { 0, 4 }, new int[0], new[] { 2, 5, 7 }, new[] { 1, 3, 6 })]
        [TestCase(13, new[] { 0, 2, 5, 7 }, new[] { 1, 6 }, new[] { 4 }, new[] { 3 })]
        [TestCase(14, new[] { 2, 4, 7 }, new[] { 3 }, new[] { 0, 5 }, new[] { 1, 6 })]
        [TestCase(15, new[] { 0, 5 }, new int[0], new[] { 2, 4, 7 }, new[] { 1, 3, 6 })]

        [TestCase(16, new[] { 0, 2, 4, 5, 7 }, new[] { 1, 3, 6 }, new int[0], new int[0])]
        [TestCase(17, new[] { 4, 7 }, new int[0], new[] { 0, 2, 5 }, new[] { 1, 3, 6 })]
        [TestCase(18, new[] { 0, 2, 5 }, new[] { 1 }, new[] { 4, 7 }, new[] { 3, 6 })]
        [TestCase(19, new[] { 2, 4, 5, 7 }, new[] { 3, 6 }, new[] { 0 }, new[] { 1 })]
        [TestCase(20, new[] { 0, 4 }, new int[0], new[] { 2, 5, 7 }, new[] { 1, 3, 6 })]
        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned(
            int jvIndex,
            int[] expectedFixedCons,
            int[] expectedFixedDis,
            int[] expectedVarCons,
            int[] expectedVarDis)
        {
            var result = _calculator.Calculate(jvIndex);

            Assert.That(result.FixedConsonances, Is.EquivalentTo(expectedFixedCons));
            Assert.That(result.FixedDissonances, Is.EquivalentTo(expectedFixedDis));
            Assert.That(result.VariableConsances, Is.EquivalentTo(expectedVarCons));
            Assert.That(result.VariableDissonance, Is.EquivalentTo(expectedVarDis));
        }
    }
}
