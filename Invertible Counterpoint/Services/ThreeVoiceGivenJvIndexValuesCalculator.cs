using Invertible_Counterpoint.Models;

namespace Invertible_Counterpoint.Services
{
    public class ThreeVoiceGivenJvIndexValuesCalculator
    {
        public List<InvertedIntervals> Calculate(int jvPrime, int jvDoublePrime, int jvSigma)
        {
            var twoVoiceJvCalculator = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();

            var intervalsWithRulesForVoiceOneAndTwo = twoVoiceJvCalculator.Calculate(jvPrime);
            var intervalsWithRulesForVoiceTwoAndThree = twoVoiceJvCalculator.Calculate(jvDoublePrime);
            var intervalsWithRulesForVoiceOneAndThree = twoVoiceJvCalculator.Calculate(jvSigma);

            var intervalsList = new List<InvertedIntervals>()
            {
                intervalsWithRulesForVoiceOneAndTwo,
                intervalsWithRulesForVoiceTwoAndThree,
                intervalsWithRulesForVoiceOneAndThree
            };
            return intervalsList;
        }
    }
}
