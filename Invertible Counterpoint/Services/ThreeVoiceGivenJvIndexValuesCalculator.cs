using System.Security.Cryptography.X509Certificates;
using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Utility;

namespace Invertible_Counterpoint.Services
{
    public class ThreeVoiceGivenJvIndexValuesCalculator
    {
        public InvertedIntervals Calculate(int jvPrime, int jvDoublePrime, int jvSigma)
        {
            var twoVoiceJvCalculator = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();

            var intervalsWithRulesForVoiceOneAndTwo = twoVoiceJvCalculator.Calculate(jvPrime);
            var intervalsWithRulesForVoiceTwoAndThree = twoVoiceJvCalculator.Calculate(jvDoublePrime);
            var intervalsWithRulesForVoiceOneAndThree = twoVoiceJvCalculator.Calculate(jvSigma);

            //combining rules

            var result = CombineThreeSetsOfIntervals(intervalsWithRulesForVoiceOneAndTwo, intervalsWithRulesForVoiceTwoAndThree, intervalsWithRulesForVoiceOneAndThree);
            return result;
        }


        private InvertedIntervals CombineThreeSetsOfIntervals(
            InvertedIntervals intervalsWithRulesForVoiceOneAndTwo,
            InvertedIntervals intervalsWithRulesForVoiceTwoAndThree,
            InvertedIntervals intervalsWithRulesForVoiceOneAndThree)
        {
            var fixedConsonances = new List<int>();
            fixedConsonances.AddRange(intervalsWithRulesForVoiceOneAndTwo.FixedConsonances.Select(x => x.Number));
            fixedConsonances.AddRange(intervalsWithRulesForVoiceTwoAndThree.FixedConsonances.Select(x => x.Number));
            fixedConsonances.AddRange(intervalsWithRulesForVoiceOneAndThree.FixedConsonances.Select(x => x.Number));

            var fixedDissonances = new List<int>();
            fixedDissonances.AddRange(intervalsWithRulesForVoiceOneAndTwo.FixedDissonances.Select(x => x.Number));
            fixedDissonances.AddRange(intervalsWithRulesForVoiceTwoAndThree.FixedDissonances.Select(x => x.Number));
            fixedDissonances.AddRange(intervalsWithRulesForVoiceOneAndThree.FixedDissonances.Select(x => x.Number));

            var variableConsonances = new List<int>();
            variableConsonances.AddRange(intervalsWithRulesForVoiceOneAndTwo.VariableConsonances.Select(x => x.Number));
            variableConsonances.AddRange(intervalsWithRulesForVoiceTwoAndThree.VariableConsonances.Select(x => x.Number));
            variableConsonances.AddRange(intervalsWithRulesForVoiceOneAndThree.VariableConsonances.Select(x => x.Number));

            var variableDissonances = new List<int>();
            variableDissonances.AddRange(intervalsWithRulesForVoiceOneAndTwo.VariableDissonances.Select(x => x.Number));
            variableDissonances.AddRange(intervalsWithRulesForVoiceTwoAndThree.VariableDissonances.Select(x => x.Number));
            variableDissonances.AddRange(intervalsWithRulesForVoiceOneAndThree.VariableDissonances.Select(x => x.Number));


            var intervalEnumToListDictionary = new Dictionary<IntervalInStrictOrder, List<int>>()
            {
                { IntervalInStrictOrder.FixedConsonance, fixedConsonances },
                { IntervalInStrictOrder.VariableConsonance, variableConsonances },
                { IntervalInStrictOrder.VariableDissonance, variableDissonances },
                { IntervalInStrictOrder.FixedDissonance, fixedDissonances }

            };

            var strictMostIntervalList = new Dictionary<IntervalInStrictOrder, List<int>>()
            {
                { IntervalInStrictOrder.FixedConsonance, new List<int>()},
               { IntervalInStrictOrder.VariableConsonance, new List<int>()},
               { IntervalInStrictOrder.VariableDissonance, new List<int>()},
               { IntervalInStrictOrder.FixedDissonance, new List<int>()},
            };

            for (int i = 0; i <= 7; i++)
            {
                IntervalInStrictOrder strictMostIntervalType = IntervalInStrictOrder.FixedConsonance;
                foreach (var entry in intervalEnumToListDictionary)
                {
                    if (entry.Value.Contains(i))
                    {
                        strictMostIntervalType = entry.Key;
                    }
                }
                strictMostIntervalList[strictMostIntervalType].Add(i);
            }

            return new InvertedIntervals();
        }

        private enum IntervalInStrictOrder
        {
            // Ordered softest → strictest (so Max() = strict-most)
            FixedConsonance = 0,
            VariableDissonance = 1,
            VariableConsonance = 2,
            FixedDissonance = 3,
        }

        private static Interval CopyInterval(Interval sourceInterval) =>
            new Interval(sourceInterval.Number, sourceInterval.Name, sourceInterval.IsConsonant, sourceInterval.UpperSuspensionTreatmentEnum, sourceInterval.LowerSuspensionTreatmentEnum);

    }
}
