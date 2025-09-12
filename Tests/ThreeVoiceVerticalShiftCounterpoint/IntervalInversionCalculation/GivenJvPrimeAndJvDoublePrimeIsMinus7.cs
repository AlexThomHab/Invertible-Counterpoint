using System.Linq;
using System.Collections.Generic;
using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Services;
using NUnit.Framework;
using static Tests.InvertedIntervalsTestHelpers;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint.IntervalInversionCalculation
{
    public class GivenJvPrimeAndJvDoublePrimeIsMinus7
    {
        private List<InvertedIntervals> _rows;
        private int _jvPrime, _jvDoublePrime, _jvSigma;

        [OneTimeSetUp]
        public void WhenCalculatingInvertedIntervals()
        {
            var jvCalculator = new JvCalculator();
            _jvPrime = -7;
            _jvDoublePrime = -7;
            _jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(_jvPrime, _jvDoublePrime);

            var threeVoiceCalculator = new ThreeVoiceGivenJvIndexValuesCalculator();
            _rows = threeVoiceCalculator.Calculate(_jvPrime, _jvDoublePrime, _jvSigma);
        }

        [Test]
        public void ThenThreeRowsAreReturned()
        {
            Assert.That(_rows, Is.Not.Null);
            Assert.That(_rows.Count, Is.EqualTo(3));
        }

        [Test]
        public void EachRowMatchesTwoVoiceCalculator()
        {
            var two = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();

            var expected0 = two.Calculate(_jvPrime);
            var expected1 = two.Calculate(_jvDoublePrime);
            var expected2 = two.Calculate(_jvSigma);

            AssertIntervalsEqual(_rows[0], expected0);
            AssertIntervalsEqual(_rows[1], expected1);
            AssertIntervalsEqual(_rows[2], expected2);
        }
    }
}