namespace Invertible_Counterpoint
{
    public class InvertedIntervalsCalculator
    {
        private Dictionary<int, Interval> _intervals = new()
        {
            {0, new Interval(0, "Unison", true)},       
            {1, new Interval(1, "Second", false)},  
            {2, new Interval(2, "Third", true)}, 
            {3, new Interval(3, "Fourth", false)},
            {4, new Interval(4, "Fifth", true)},
            {5, new Interval(5, "Sixth", true)},
            {6, new Interval(6, "Seventh", false)},
            {7, new Interval(7, "Octave", true)},
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
                    invertedIntervals.FixedConsonances.Add(i);
                    continue;
                }

                if (!_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    invertedIntervals.FixedDissonances.Add(i);
                    continue;
                }

                if (_intervals[i].IsConsonant && !_intervals[targetIndex].IsConsonant)
                {
                    invertedIntervals.VariableConsances.Add(i);
                    continue;
                }

                if (!_intervals[i].IsConsonant && _intervals[targetIndex].IsConsonant)
                {
                    invertedIntervals.VariableDissonance.Add(i);
                }
            }
            return invertedIntervals;
        }
    }
}
