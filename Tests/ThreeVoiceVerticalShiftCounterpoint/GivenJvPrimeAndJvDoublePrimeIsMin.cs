using Invertible_Counterpoint.Services;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint
{
    public class GivenJvPrimeAndJvDoublePrimeIsMin
    {
        private TwoVoiceShiftedIntervalsGivenJvIndexCalculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            var jvCalculator = new JvCalculator();
            var jvPrime = -7;
            var jvDoublePrime = -7;
            var jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(jvPrime, jvDoublePrime);
            var threeVoiceCalculator = new ThreeVoiceGivenJvIndexValuesCalculator();
            threeVoiceCalculator.Calculate(jvPrime, jvDoublePrime, jvSigma);
        }
        [Test]
        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned()
        {

            Assert.That(result.FixedConsonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedFixedCons));
            Assert.That(result.FixedDissonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedFixedDis));
            Assert.That(result.VariableConsances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedVarCons));
            Assert.That(result.VariableDissonances.Select(x => x.Number).ToArray(), Is.EquivalentTo(expectedVarDis));
        }
    }
}
