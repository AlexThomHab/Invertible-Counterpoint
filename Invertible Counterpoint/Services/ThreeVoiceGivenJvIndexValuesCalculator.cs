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
            // 1) Build the “strict-most” interval-class buckets by number, as you already did.
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
                        // because the enum is ordered strict->soft (0..3), later hits overwrite
                        // leaving the softest class seen so far — i.e., "strict-most" semantics you intended
                        strictMostIntervalType = entry.Key;
                    }
                }
                strictMostIntervalList[strictMostIntervalType].Add(i);
            }

            // 2) Helper to get strict-most suspensions for a given interval number across the three 2-voice results
            (SuspensionTreatmentEnum upper, SuspensionTreatmentEnum lower) GetStrictMostSuspensions(int n)
            {
                // Gather the three sets’ intervals that match this number (across all four categories)
                IEnumerable<Interval> collect(InvertedIntervals ii) =>
                    ii.FixedConsonances
                      .Concat(ii.FixedDissonances)
                      .Concat(ii.VariableConsonances)
                      .Concat(ii.VariableDissonances)
                      .Where(x => x.Number == n);

                var all = collect(intervalsWithRulesForVoiceOneAndTwo)
                         .Concat(collect(intervalsWithRulesForVoiceTwoAndThree))
                         .Concat(collect(intervalsWithRulesForVoiceOneAndThree))
                         .ToList();

                // If for any reason none are present, default to the softest per your aggregator’s seed.
                var uppers = all.Select(x => x.UpperSuspensionTreatmentEnum).ToArray();
                var lowers = all.Select(x => x.LowerSuspensionTreatmentEnum).ToArray();

                var upper = SuspensionService.StrictMost(uppers.Length > 0
                    ? uppers
                    : new[] { SuspensionTreatmentEnum.NoteOfResolutionIsFree });

                var lower = SuspensionService.StrictMost(lowers.Length > 0
                    ? lowers
                    : new[] { SuspensionTreatmentEnum.NoteOfResolutionIsFree });

                return (upper, lower);
            }

            // 3) Build the final InvertedIntervals using the strict-most *suspension* for each interval number.
            return new InvertedIntervals
            {
                FixedConsonances = strictMostIntervalList[IntervalInStrictOrder.FixedConsonance]
                    .Select(n =>
                    {
                        var (upper, lower) = GetStrictMostSuspensions(n);
                        return new Interval(n, GetIntervalName(n), true, upper, lower);
                    }).ToList(),

                FixedDissonances = strictMostIntervalList[IntervalInStrictOrder.FixedDissonance]
                    .Select(n =>
                    {
                        var (upper, lower) = GetStrictMostSuspensions(n);
                        return new Interval(n, GetIntervalName(n), false, upper, lower);
                    }).ToList(),

                VariableConsonances = strictMostIntervalList[IntervalInStrictOrder.VariableConsonance]
                    .Select(n =>
                    {
                        var (upper, lower) = GetStrictMostSuspensions(n);
                        return new Interval(n, GetIntervalName(n), true, upper, lower);
                    }).ToList(),

                VariableDissonances = strictMostIntervalList[IntervalInStrictOrder.VariableDissonance]
                    .Select(n =>
                    {
                        var (upper, lower) = GetStrictMostSuspensions(n);
                        return new Interval(n, GetIntervalName(n), false, upper, lower);
                    }).ToList()
            };
        }


        private enum IntervalInStrictOrder
        {
            FixedConsonance = 0,
            VariableDissonance = 1,
            VariableConsonance = 2,
            FixedDissonance = 3,
        }

        private static string GetIntervalName(int number) => number switch
        {
            0 => "Unison",
            1 => "Second",
            2 => "Third",
            3 => "Fourth",
            4 => "Fifth",
            5 => "Sixth",
            6 => "Seventh",
            7 => "Octave",
            _ => $"Interval {number}"
        };


        private static Interval CopyInterval(Interval sourceInterval) =>
            new Interval(sourceInterval.Number, sourceInterval.Name, sourceInterval.IsConsonant, sourceInterval.UpperSuspensionTreatmentEnum, sourceInterval.LowerSuspensionTreatmentEnum);

    }
}
