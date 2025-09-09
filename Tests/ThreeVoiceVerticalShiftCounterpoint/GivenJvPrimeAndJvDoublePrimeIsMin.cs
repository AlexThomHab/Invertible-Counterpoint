using System.Linq;
using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Services;
using NUnit.Framework;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint
{
    public class GivenJvPrimeAndJvDoublePrimeIsMin
    {
        private InvertedIntervals _invertedIntervals;

        [OneTimeSetUp]
        public void Setup()
        {
            var jvCalculator = new JvCalculator();
            var jvPrime = -7;
            var jvDoublePrime = -7;
            var jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(jvPrime, jvDoublePrime); // should be -14 (≡ 0)

            var threeVoiceCalculator = new ThreeVoiceGivenJvIndexValuesCalculator();
            _invertedIntervals = threeVoiceCalculator.Calculate(jvPrime, jvDoublePrime, jvSigma);
        }

        [Test]
        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned()
        {
            // Project to numbers for simpler assertions
            var fc = _invertedIntervals.FixedConsonances.Select(iv => iv.Number).OrderBy(x => x).ToArray();
            var fd = _invertedIntervals.FixedDissonances.Select(iv => iv.Number).OrderBy(x => x).ToArray();
            var vc = _invertedIntervals.VariableConsonances.Select(iv => iv.Number).OrderBy(x => x).ToArray();
            var vd = _invertedIntervals.VariableDissonances.Select(iv => iv.Number).OrderBy(x => x).ToArray();

            Assert.That(fc, Is.EquivalentTo(new[] { 0, 2, 5, 7 }));
            //Assert.That(fd, Is.EquivalentTo(new[] { 1, 3, 6 }));
            Assert.That(vc, Is.EquivalentTo(new[] { 4 }));
            //Assert.That(vd, Is.Empty);
        }
    }
}