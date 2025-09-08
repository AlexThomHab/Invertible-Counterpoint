namespace Invertible_Counterpoint
{
    public class InvertedIntervalsCalculator
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
                        var jv0Interval = _intervals[i];
                        var shiftedIntervalToCompare = _intervalsInverted[(int.Abs(jvIndex + i) % 7)];
                        jv0Interval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.UpperSuspensionTreatmentEnum, shiftedIntervalToCompare.UpperSuspensionTreatmentEnum);
                        jv0Interval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.LowerSuspensionTreatmentEnum, shiftedIntervalToCompare.LowerSuspensionTreatmentEnum);
                        invertedIntervals.FixedConsonances.Add(jv0Interval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        invertedIntervals.FixedConsonances.Add(selectedInterval);
                        continue;
                    }
                }

                if (!_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var jv0Interval = _intervals[i];
                        var shiftedIntervalToCompare = _intervalsInverted[(int.Abs(jvIndex + i) % 7)];

                        if (int.Abs(jvIndex + i) > 7 && shiftedIntervalToCompare.Name == "Second")
                        {
                            shiftedIntervalToCompare.LowerSuspensionTreatmentEnum =
                                SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension;
                        }

                        jv0Interval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.UpperSuspensionTreatmentEnum, shiftedIntervalToCompare.UpperSuspensionTreatmentEnum);
                        jv0Interval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.LowerSuspensionTreatmentEnum, shiftedIntervalToCompare.LowerSuspensionTreatmentEnum);
                        invertedIntervals.FixedDissonances.Add(jv0Interval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        invertedIntervals.FixedDissonances.Add(selectedInterval);
                        continue;
                    }
                }

                if (_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var jv0Interval = _intervals[i];
                        var shiftedIntervalToCompare = _intervalsInverted[(int.Abs(jvIndex + i) % 7)];
                        jv0Interval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.UpperSuspensionTreatmentEnum, shiftedIntervalToCompare.UpperSuspensionTreatmentEnum);
                        jv0Interval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.LowerSuspensionTreatmentEnum, shiftedIntervalToCompare.LowerSuspensionTreatmentEnum);
                        invertedIntervals.VariableConsances.Add(jv0Interval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        invertedIntervals.VariableConsances.Add(selectedInterval);
                        continue;
                    }
                }

                if (!_intervals[i].IsConsonant && _intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var jv0Interval = _intervals[i];
                        var shiftedIntervalToCompare = _intervalsInverted[(int.Abs(jvIndex + i) % 7)];
                        jv0Interval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.UpperSuspensionTreatmentEnum, shiftedIntervalToCompare.UpperSuspensionTreatmentEnum);
                        jv0Interval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(jv0Interval.LowerSuspensionTreatmentEnum, shiftedIntervalToCompare.LowerSuspensionTreatmentEnum);
                        invertedIntervals.VariableDissonances.Add(jv0Interval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        invertedIntervals.VariableDissonances.Add(selectedInterval);
                        continue;
                    }
                }
            }
            return invertedIntervals;
        }

        public SuspensionTreatmentEnum StrictMostSuspensionTreatmentEnum(
            SuspensionTreatmentEnum originalIntervalSuspension,
            SuspensionTreatmentEnum newIntervalSuspension)
        {
            var validTreatments = new[]
            {
                SuspensionTreatmentEnum.CannotFormSuspension,
                SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension,
                SuspensionTreatmentEnum.NoteOfResolutionIsDissonant,
                SuspensionTreatmentEnum.NoteOfResolutionIsFree
            };
            if (originalIntervalSuspension == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension &&
                newIntervalSuspension == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant
                || originalIntervalSuspension == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant &&
                newIntervalSuspension == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)
            {
                return SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant;
            }

            return (SuspensionTreatmentEnum)Math.Min((int)originalIntervalSuspension, (int)newIntervalSuspension);
        }

    }
}
