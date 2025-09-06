using Invertible_Counterpoint;
using NUnit.Framework;

namespace Tests.IntervalInversionCalculation
{
    public class GivenANegativeJvIndex_Param
    {
        private InvertedIntervalsCalculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new InvertedIntervalsCalculator();
        }

        [TestCase(-11, new[] { 0, 2, 4, 7 }, new[] { 1, 3 }, new[] { 5 }, new[] { 6 })]
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

            Assert.That(result.FixedConsonances, Is.EquivalentTo(expectedFixedCons));
            Assert.That(result.FixedDissonances, Is.EquivalentTo(expectedFixedDis));
            Assert.That(result.VariableConsances, Is.EquivalentTo(expectedVarCons));
            Assert.That(result.VariableDissonance, Is.EquivalentTo(expectedVarDis));
        }
    }
}