namespace Invertible_Counterpoint
{
    public class InvertedIntervals
    {
        public List<Interval> FixedConsonances;
        public List<Interval> FixedDissonances;
        public List<Interval> VariableConsances;
        public List<Interval> VariableDissonance;

        public InvertedIntervals()
        {
            FixedConsonances = new List<Interval>();
            FixedDissonances = new List<Interval>();
            VariableConsances = new List<Interval>();
            VariableDissonance = new List<Interval>();
        }
        
    }
}
