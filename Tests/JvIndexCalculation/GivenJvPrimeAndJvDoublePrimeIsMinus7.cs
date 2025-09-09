using Invertible_Counterpoint.Services;

namespace Tests.JvIndexCalculation
{
    public class GivenJvPrimeAndJvDoublePrimeIsMinus7
    {
        private int _jvSigma;

        [OneTimeSetUp]
        public void Setup()
        {
            var jvCalculator = new JvCalculator();
            var jvPrime = -7;
            var jvDoublePrime = -7;
            _jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(jvPrime, jvDoublePrime);
        }
        [Test]
        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned()
        {

            Assert.That(_jvSigma, Is.EqualTo(-14));
        }
    }
}
