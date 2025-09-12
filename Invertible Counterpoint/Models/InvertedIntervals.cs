using System.Security.Cryptography.X509Certificates;

namespace Invertible_Counterpoint.Models
{
    public class InvertedIntervals
    {
        public List<Interval> FixedConsonances;
        public List<Interval> FixedDissonances;
        public List<Interval> VariableConsonances;
        public List<Interval> VariableDissonances;

        public InvertedIntervals()
        {
            FixedConsonances = new List<Interval>();
            FixedDissonances = new List<Interval>();
            VariableConsonances = new List<Interval>();
            VariableDissonances = new List<Interval>();
        }
    }
}
