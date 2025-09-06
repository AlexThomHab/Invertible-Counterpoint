namespace Invertible_Counterpoint
{
    public class Interval
    {
        public int Number { get; }
        public string Name { get; }
        public bool IsConsonant { get; }
        public Interval(int number, string name, bool isConsonant)
        {
            Number = number;
            Name = name;
            IsConsonant = isConsonant;
        }
    }
}
