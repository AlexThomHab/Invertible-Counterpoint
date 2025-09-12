using Invertible_Counterpoint.Models;

namespace Tests;

static class InvertedIntervalsTestHelpers
{
    public static void AssertIntervalsEqual(InvertedIntervals actual, InvertedIntervals expected)
    {
        AssertListEqual(actual.FixedConsonances, expected.FixedConsonances);
        AssertListEqual(actual.FixedDissonances, expected.FixedDissonances);
        AssertListEqual(actual.VariableConsonances, expected.VariableConsonances);
        AssertListEqual(actual.VariableDissonances, expected.VariableDissonances);
    }

    private static void AssertListEqual(List<Interval> actualRowList, System.Collections.Generic.List<Interval> expectedRow)
    {
        var actualRowListOrdered = actualRowList.OrderBy(x => x.Number).ToArray();
        var expectedRowOrdered = expectedRow.OrderBy(x => x.Number).ToArray();

        Assert.That(actualRowListOrdered.Length, Is.EqualTo(expectedRowOrdered.Length), "Length mismatch");

        for (int i = 0; i < actualRowListOrdered.Length; i++)
        {
            Assert.That(actualRowListOrdered[i].Number, Is.EqualTo(expectedRowOrdered[i].Number), "Number mismatch");
            Assert.That(actualRowListOrdered[i].IsConsonant, Is.EqualTo(expectedRowOrdered[i].IsConsonant), "Consonance flag mismatch");
            Assert.That(actualRowListOrdered[i].UpperSuspensionTreatmentEnum, Is.EqualTo(expectedRowOrdered[i].UpperSuspensionTreatmentEnum), "Upper suspension mismatch");
            Assert.That(actualRowListOrdered[i].LowerSuspensionTreatmentEnum, Is.EqualTo(expectedRowOrdered[i].LowerSuspensionTreatmentEnum), "Lower suspension mismatch");
        }
    }
}