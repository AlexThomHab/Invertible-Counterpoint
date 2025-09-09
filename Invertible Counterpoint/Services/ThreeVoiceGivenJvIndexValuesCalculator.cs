using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Utility;

namespace Invertible_Counterpoint.Services
{
    public class ThreeVoiceGivenJvIndexValuesCalculator
    {
        public InvertedIntervals Calculate(int jvPrime, int jvDoublePrime, int jvSigma)
        {
            var twoVoiceJvCalculator = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();

            var rulesForVoiceOneAndTwo = twoVoiceJvCalculator.Calculate(jvPrime);
            var rulesForVoiceTwoAndThree = twoVoiceJvCalculator.Calculate(jvDoublePrime);
            var rulesForVoiceOneAndThree = twoVoiceJvCalculator.Calculate(jvSigma);

            //combining rules

            var jvPrimeRules = CombineThreeSetsOfIntervals(rulesForVoiceOneAndTwo, rulesForVoiceTwoAndThree, rulesForVoiceOneAndThree);

        }

        private InvertedIntervals CombineThreeSetsOfIntervals(InvertedIntervals rulesForVoiceOneAndTwo, InvertedIntervals rulesForVoiceTwoAndThree, InvertedIntervals rulesForVoiceOneAndThree)
        {
            throw new NotImplementedException();
        }

        private enum IntervalInStrictOrder
        {
            
        }

        private static Interval CopyInterval(Interval sourceInterval) =>
            new Interval(sourceInterval.Number, sourceInterval.Name, sourceInterval.IsConsonant, sourceInterval.UpperSuspensionTreatmentEnum, sourceInterval.LowerSuspensionTreatmentEnum);

    }
}
