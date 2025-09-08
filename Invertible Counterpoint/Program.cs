using System;
using System.Collections.Generic;
using System.Linq;
using Invertible_Counterpoint;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Enter the jv value: ");
            var jv = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(jv)) continue;

            var calc = new InvertedIntervalsCalculator();
            var result = calc.Calculate(int.Parse(jv));

            // Print a tidy table for all intervals with upper/lower suspension symbols
            Console.WriteLine("\nSuspension Table (per interval):");
            PrintSuspensionTable(result);
            PrintLegend();
            Console.WriteLine();
        }
    }

    private static void PrintSuspensionTable(InvertedIntervals inv)
    {
        // Label each interval with its bucket so you can see where it came from
        var rows = new List<(Interval iv, string group)>();
        rows.AddRange(inv.FixedConsonances.Select(iv => (iv, "Fixed Consonance")));
        rows.AddRange(inv.FixedDissonances.Select(iv => (iv, "Fixed Dissonance")));
        rows.AddRange(inv.VariableConsances.Select(iv => (iv, "Variable Consonance")));   // note: property name as in your code
        rows.AddRange(inv.VariableDissonances.Select(iv => (iv, "Variable Dissonance")));

        // Sort by interval number for readability
        rows = rows.OrderBy(r => r.iv.Number).ToList();

        Console.WriteLine("Name    No  | Upper  | Lower  | Group");
        Console.WriteLine("-----------------------------------------------");
        foreach (var (iv, group) in rows)
        {
            var upper = Sym(iv.UpperSuspensionTreatmentEnum);
            var lower = Sym(iv.LowerSuspensionTreatmentEnum);
            Console.WriteLine($"{iv.Name,-7} {iv.Number,2}  | {upper,-6} | {lower,-6} | {group}");
        }
    }

    // Map suspension treatments to the symbols shown in your image
    private static string Sym(SuspensionTreatmentEnum t) => t switch
    {
        SuspensionTreatmentEnum.CannotFormSuspension => "(—)", // fallback "( - )" if console can't show em-dash
        SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension => "—",
        SuspensionTreatmentEnum.NoteOfResolutionIsDissonant => "x",
        SuspensionTreatmentEnum.NoteOfResolutionIsFree => "----",
        SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant => "—x",
        _ => "?"
    };

    private static void PrintLegend()
    {
        Console.WriteLine("\nLegend:");
        Console.WriteLine("  (—)   = Cannot form a suspension");
        Console.WriteLine("  —     = If on downbeat, must form suspension");
        Console.WriteLine("  x     = If forming suspension, note of resolution is dissonant");
        Console.WriteLine("  ----  = If forming suspension, note of resolution is free");
        Console.WriteLine("  —x    = Both conditions apply");
    }
}
