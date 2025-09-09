using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Utility;

namespace Invertible_Counterpoint.Services
{
    public class ThreeVoiceShiftedIntervalsGivenJvIndexValuesCalculator
    {
        public InvertedIntervals Calculate(int jvPrime, int jvDoublePrime, int jvSigma)
        {
            var twoVoiceJvCalculator = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();

            var voiceOneAndTwo = twoVoiceJvCalculator.Calculate(jvPrime);
            var voiceTwoAndThree = twoVoiceJvCalculator.Calculate(jvDoublePrime);
            var voiceOneAndThree = twoVoiceJvCalculator.Calculate(jvSigma);
        }
        private static Interval CopyInterval(Interval sourceInterval) =>
            new Interval(sourceInterval.Number, sourceInterval.Name, sourceInterval.IsConsonant, sourceInterval.UpperSuspensionTreatmentEnum, sourceInterval.LowerSuspensionTreatmentEnum);

    }
}
