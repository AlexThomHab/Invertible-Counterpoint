using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Utility;

namespace Invertible_Counterpoint.Services
{
    public class TwoVoiceShiftedIntervalsGivenJvIndexCalculator
    {
        private Dictionary<int, Interval> _intervals = new()
        {
            {0, new Interval(0, "Unison", true, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
            {1, new Interval(1, "Second", false, SuspensionTreatmentEnum.CannotFormSuspension, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)},
            {2, new Interval(2, "Third", true, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
            {3, new Interval(3, "Fourth", false, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)},
            {4, new Interval(4, "Fifth", true, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsFree)},
            {5, new Interval(5, "Sixth", true, SuspensionTreatmentEnum.NoteOfResolutionIsFree, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
            {6, new Interval(6, "Seventh", false, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension, SuspensionTreatmentEnum.CannotFormSuspension)},
            {7, new Interval(7, "Octave", true,SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
        };
        private Dictionary<int, Interval> _intervalsInverted = new()
        {
            {0, new Interval(0, "Unison", true, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
            {1, new Interval(-1, "Second", false, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension, SuspensionTreatmentEnum.CannotFormSuspension)},
            {2, new Interval(-2, "Third", true, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
            {3, new Interval(-3, "Fourth", false, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)},
            {4, new Interval(-4, "Fifth", true, SuspensionTreatmentEnum.NoteOfResolutionIsFree, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
            {5, new Interval(-5, "Sixth", true, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsFree)},
            {6, new Interval(-6, "Seventh", false, SuspensionTreatmentEnum.CannotFormSuspension, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)},
            {7, new Interval(-7, "Octave", true, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
        };

        public InvertedIntervals Calculate(int jvIndex)
        {
            var invertedIntervals = new InvertedIntervals();
            int maxIndex = _intervals.Count - 1;
            for (int i = 0; i <= 7; i++)
            {
                int targetIndex = int.Abs((i + jvIndex) % maxIndex);

                if (_intervals[i].IsConsonant && _intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervalsInverted[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = true;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        combineTwoIntervalsSuspensionsResult.IsImperfectBecomesPerfect = IsImperfectBecomesPerfect(jv0Interval, shiftedIntervalToCompare);
                        invertedIntervals.FixedConsonances.Add(combineTwoIntervalsSuspensionsResult);
                        continue;
                    }
                    else
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervals[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = false;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        combineTwoIntervalsSuspensionsResult.IsImperfectBecomesPerfect = IsImperfectBecomesPerfect(jv0Interval, shiftedIntervalToCompare);
                        invertedIntervals.FixedConsonances.Add(combineTwoIntervalsSuspensionsResult);
                        continue;
                    }
                }

                if (!_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervalsInverted[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = true;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        invertedIntervals.FixedDissonances.Add(combineTwoIntervalsSuspensionsResult);
                        continue;
                    }
                    else
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervals[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = false;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        invertedIntervals.FixedDissonances.Add(combineTwoIntervalsSuspensionsResult);
                        continue;
                    }
                }

                if (_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervalsInverted[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = true;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        invertedIntervals.VariableConsonances.Add(combineTwoIntervalsSuspensionsResult);
                        continue;
                    }
                    else
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervals[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = false;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        invertedIntervals.VariableConsonances.Add(combineTwoIntervalsSuspensionsResult);
                        continue;
                    }
                }

                if (!_intervals[i].IsConsonant && _intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervalsInverted[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = true;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        invertedIntervals.VariableDissonances.Add(combineTwoIntervalsSuspensionsResult);
                    }
                    else
                    {
                        var jv0Interval = CopyInterval(_intervals[i]);
                        var shiftedIntervalToCompare = CopyInterval(_intervals[int.Abs(jvIndex + i) % 7]);
                        var jvIsNegative = false;
                        var combineTwoIntervalsSuspensionsResult = SuspensionService.CombineTwoIntervals(jv0Interval, shiftedIntervalToCompare, jvIndex, i, jvIsNegative);
                        invertedIntervals.VariableDissonances.Add(combineTwoIntervalsSuspensionsResult);
                    }
                }
            }
            return invertedIntervals;
        }

        private bool IsImperfectBecomesPerfect(Interval jv0Interval, Interval shiftedIntervalToCompare)
        {
            var perfectIntervals = new HashSet<int> { 0, 4, 7 };
            var imperfectIntervals = new HashSet<int> { 2, 5};

            return imperfectIntervals.Contains(jv0Interval.Number)
                   && perfectIntervals.Contains(Math.Abs(shiftedIntervalToCompare.Number));
        }


        private static Interval CopyInterval(Interval sourceInterval) =>
            new Interval(sourceInterval.Number, sourceInterval.Name, sourceInterval.IsConsonant, sourceInterval.UpperSuspensionTreatmentEnum, sourceInterval.LowerSuspensionTreatmentEnum);

    }
}
