using Invertible_Counterpoint.Services;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint
{
    public class GivenJvPrimeAndJvDoublePrimeIs0
    {
        private InvertedIntervalsCalculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            var jvCalculator = new JvCalculator();
            var jvPrime = -7;
            var jvDoublePrime = -7;
            var jvSigmaGivenJvPrimeAndJvDoublePrime = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(jvPrime, jvDoublePrime);
            _calculator = new InvertedIntervalsCalculator();
        }
        [Test]
        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned()
        {
            var result = _calculator.Calculate(jvIndex);

            Assert.That(result.FixedConsonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedFixedCons));
            Assert.That(result.FixedDissonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedFixedDis));
            Assert.That(result.VariableConsances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedVarCons));
            Assert.That(result.VariableDissonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedVarDis));
        }
    }
}
