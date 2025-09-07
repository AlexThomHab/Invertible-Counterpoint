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

        public InvertedIntervals Calculate(int jvIndex)
        {
            var invertedIntervals = new InvertedIntervals();
            int maxIndex = _intervals.Count - 1;
            for (int i = 0; i <= 7; i++)
            {
                int targetIndex = int.Abs((i + jvIndex) % maxIndex);

                if (_intervals[i].IsConsonant && _intervals[targetIndex].IsConsonant)
                {
                    invertedIntervals.FixedConsonances.Add(_intervals[i]);
                    continue;
                }

                if (!_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    invertedIntervals.FixedDissonances.Add(_intervals[i]);
                    continue;
                }

                if (_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    invertedIntervals.VariableConsances.Add(_intervals[i]);
                    continue;
                }

                if (!_intervals[i].IsConsonant && _intervals[targetIndex].IsConsonant)
                {
                    invertedIntervals.VariableDissonance.Add(_intervals[i]);
                }
            }
            return invertedIntervals;
        }
    }
}
