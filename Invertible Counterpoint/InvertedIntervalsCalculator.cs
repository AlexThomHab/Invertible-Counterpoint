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
                        var selectedInterval = _intervalsInverted[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].UpperSuspensionTreatmentEnum, _intervalsInverted[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].LowerSuspensionTreatmentEnum, _intervalsInverted[targetIndex].LowerSuspensionTreatmentEnum);
                        invertedIntervals.FixedConsonances.Add(selectedInterval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].UpperSuspensionTreatmentEnum, _intervals[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].LowerSuspensionTreatmentEnum, _intervals[targetIndex].LowerSuspensionTreatmentEnum);
                        invertedIntervals.FixedConsonances.Add(selectedInterval);
                        continue;
                    }
                    
                }

                if (!_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {

                    if (jvIndex < 0)
                    {
                        var selectedInterval = _intervalsInverted[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].UpperSuspensionTreatmentEnum, _intervalsInverted[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].LowerSuspensionTreatmentEnum, _intervalsInverted[targetIndex].LowerSuspensionTreatmentEnum);
                        invertedIntervals.FixedDissonances.Add(selectedInterval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].UpperSuspensionTreatmentEnum, _intervals[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].LowerSuspensionTreatmentEnum, _intervals[targetIndex].LowerSuspensionTreatmentEnum);
                        invertedIntervals.FixedDissonances.Add(selectedInterval);
                        continue;
                    }
                }

                if (_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var selectedInterval = _intervalsInverted[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].UpperSuspensionTreatmentEnum, _intervalsInverted[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].LowerSuspensionTreatmentEnum, _intervalsInverted[targetIndex].LowerSuspensionTreatmentEnum);
                        invertedIntervals.VariableConsances.Add(selectedInterval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].UpperSuspensionTreatmentEnum, _intervals[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].LowerSuspensionTreatmentEnum, _intervals[targetIndex].LowerSuspensionTreatmentEnum);
                        invertedIntervals.VariableConsances.Add(selectedInterval);
                        continue;
                    }
                }

                if (!_intervals[i].IsConsonant && _intervals[targetIndex].IsConsonant)
                {
                    if (jvIndex < 0)
                    {
                        var selectedInterval = _intervalsInverted[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].UpperSuspensionTreatmentEnum, _intervalsInverted[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervalsInverted[i].LowerSuspensionTreatmentEnum, _intervalsInverted[targetIndex].LowerSuspensionTreatmentEnum);
                        invertedIntervals.VariableDissonances.Add(selectedInterval);
                        continue;
                    }
                    else
                    {
                        var selectedInterval = _intervals[i];
                        //selectedInterval.UpperSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].UpperSuspensionTreatmentEnum, _intervals[targetIndex].UpperSuspensionTreatmentEnum);
                        //selectedInterval.LowerSuspensionTreatmentEnum = StrictMostSuspensionTreatmentEnum(_intervals[i].LowerSuspensionTreatmentEnum, _intervals[targetIndex].LowerSuspensionTreatmentEnum);
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


            return (SuspensionTreatmentEnum)Math.Min((int)originalIntervalSuspension, (int)newIntervalSuspension);
        }

    }
}
