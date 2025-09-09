using System.Linq;
using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Services;
using NUnit.Framework;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint
{
    public class GivenJvPrimeIsMinus11AndJvDoublePrimeIs3
    {
        private InvertedIntervals _invertedIntervals;

        [OneTimeSetUp]
        public void Setup()
        {
            var jvCalculator = new JvCalculator();
            var jvPrime = -11;
            var jvDoublePrime = 3;
            var jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(jvPrime, jvDoublePrime);

            var threeVoiceCalculator = new ThreeVoiceGivenJvIndexValuesCalculator();
            _invertedIntervals = threeVoiceCalculator.Calculate(jvPrime, jvDoublePrime, jvSigma);
        }

        [Test]
        public void WhenCalculatingInvertedIntervals_ThenExpectedResultReturned()
        {
            var fixedConsonance = _invertedIntervals.FixedConsonances.Select(interval => interval.Number).OrderBy(x => x).ToArray();
            var fixedDissonance = _invertedIntervals.FixedDissonances.Select(interval => interval.Number).OrderBy(x => x).ToArray();
            var variableConsonance = _invertedIntervals.VariableConsonances.Select(interval => interval.Number).OrderBy(x => x).ToArray();
            var variableDissonance = _invertedIntervals.VariableDissonances.Select(interval => interval.Number).OrderBy(x => x).ToArray();

            Assert.That(fixedConsonance, Is.EquivalentTo(new[] { 4 }));
            Assert.That(fixedDissonance, Is.EquivalentTo(new[] { 1, 3 }));
            Assert.That(variableConsonance, Is.EquivalentTo(new[] { 0, 2, 5, 7 }));
            Assert.That(variableDissonance, Is.EquivalentTo(new[] { 6 }));
        }
    }
}