namespace Invertible_Counterpoint;
using System;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Enter the jv value: ");
            var jv = Console.ReadLine();

            if (jv == "")
            {
                continue;
            }

            var invertedIntervalsCalculator = new InvertedIntervalsCalculator();
            var invertedIntervals = invertedIntervalsCalculator.Calculate(int.Parse(jv));

            Console.WriteLine("\nResults:");
            Console.WriteLine($"Fixed Consonances: {string.Join(", ", invertedIntervals.FixedConsonances)}");
            Console.WriteLine($"Fixed Dissonances: {string.Join(", ", invertedIntervals.FixedDissonances)}");
            Console.WriteLine($"Variable Consonances: {string.Join(", ", invertedIntervals.VariableConsances)}");
            Console.WriteLine($"Variable Dissonances: {string.Join(", ", invertedIntervals.VariableDissonances)} \n");

        }
    }
}