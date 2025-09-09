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

        public List<Interval> GetAllIntervals()
        {
            var result = new List<Interval>(8);

            var lists = new List<List<Interval>?> {
                FixedConsonances,
                FixedDissonances,
                VariableConsonances,
                VariableDissonances
            };

            for (int i = 0; i < 8; i++)
            {
                Interval? found = null;

                foreach (var list in lists)
                {
                    if (list == null) continue;
                    found = list.FirstOrDefault(iv => iv.Number == i);
                    if (found != null) break;
                }

                if (found != null)
                    result.Add(found);
            }

            return result;
        }

    }
}
