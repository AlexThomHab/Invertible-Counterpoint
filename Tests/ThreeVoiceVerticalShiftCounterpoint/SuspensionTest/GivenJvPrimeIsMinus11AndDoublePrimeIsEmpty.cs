using System.Collections.Generic;
using Invertible_Counterpoint.Services;
using Invertible_Counterpoint.Models;
using NUnit.Framework;
using static InvertedIntervalsTestHelpers;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint.SuspensionTest
{
    internal class GivenJvPrimeIsMinus11AndDoublePrimeIsEmpty
    {
        private List<InvertedIntervals> _rows;
        private int _jvPrime, _jvDoublePrime, _jvSigma;

        [OneTimeSetUp]
        public void WhenWorkingOutIntervalSuspensions()
        {
            var jvCalculator = new JvCalculator();
            _jvPrime = -11;
            _jvDoublePrime = 0;
            _jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(_jvPrime, _jvDoublePrime);

            var threeVoiceCalculator = new ThreeVoiceGivenJvIndexValuesCalculator();
            _rows = threeVoiceCalculator.Calculate(_jvPrime, _jvDoublePrime, _jvSigma);
        }

        [Test]
        public void EachRowSuspensionsMatchTwoVoice()
        {
            var two = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();

            AssertIntervalsEqual(_rows[0], two.Calculate(_jvPrime));
            AssertIntervalsEqual(_rows[1], two.Calculate(_jvDoublePrime));
            AssertIntervalsEqual(_rows[2], two.Calculate(_jvSigma));
        }
    }
}