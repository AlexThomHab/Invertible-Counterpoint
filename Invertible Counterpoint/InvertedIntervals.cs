namespace Invertible_Counterpoint
{
    public class InvertedIntervals
    {
        public List<Interval> FixedConsonances;
        public List<Interval> FixedDissonances;
        public List<Interval> VariableConsances;
        public List<Interval> VariableDissonances;

        public InvertedIntervals()
        {
            FixedConsonances = new List<Interval>();
            FixedDissonances = new List<Interval>();
            VariableConsances = new List<Interval>();
            VariableDissonances = new List<Interval>();
        }
        
    }
}
