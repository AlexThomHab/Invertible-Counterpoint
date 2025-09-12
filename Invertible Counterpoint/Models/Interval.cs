using Invertible_Counterpoint.Utility;

namespace Invertible_Counterpoint.Models
{
    public class Interval
    {
        public int Number { get; set; }
        public string Name { get; }
        public bool IsConsonant { get; }
        public bool IsImperfectBecomesPerfect { get; set; }
        public SuspensionTreatmentEnum UpperSuspensionTreatmentEnum { get; set; }
        public SuspensionTreatmentEnum LowerSuspensionTreatmentEnum { get; set; }
        public Interval(int number, string name, bool isConsonant, SuspensionTreatmentEnum upperSuspensionTreatmentEnum, SuspensionTreatmentEnum lowerSuspensionTreatmentEnum)
        {
            Number = number;
            Name = name;
            IsConsonant = isConsonant;
            UpperSuspensionTreatmentEnum = upperSuspensionTreatmentEnum;
            LowerSuspensionTreatmentEnum = lowerSuspensionTreatmentEnum;
        }
    }
}
