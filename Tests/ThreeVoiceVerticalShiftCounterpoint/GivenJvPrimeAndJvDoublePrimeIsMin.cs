using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Services;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint
{
    public class GivenJvPrimeAndJvDoublePrimeIsMin
    {
        private TwoVoiceShiftedIntervalsGivenJvIndexCalculator _calculator;
        private InvertedIntervals _invertedIntervals;

        [OneTimeSetUp]
        public void Setup()
        {
            var jvCalculator = new JvCalculator();
            var jvPrime = -7;
            var jvDoublePrime = -7;
            var jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(jvPrime, jvDoublePrime);
            var threeVoiceCalculator = new ThreeVoiceGivenJvIndexValuesCalculator();
            _invertedIntervals = threeVoiceCalculator.Calculate(jvPrime, jvDoublePrime, jvSigma);
        }
        [Test]
        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned()
        {

            Assert.That(_invertedIntervals.FixedDissonances, Is.EquivalentTo(null));
        }
    }
}
