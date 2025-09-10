using System.Linq;
using Invertible_Counterpoint.Models;

static class InvertedIntervalsTestHelpers
{
    public static void AssertIntervalsEqual(InvertedIntervals actual, InvertedIntervals expected)
    {
        AssertListEqual(actual.FixedConsonances, expected.FixedConsonances);
        AssertListEqual(actual.FixedDissonances, expected.FixedDissonances);
        AssertListEqual(actual.VariableConsonances, expected.VariableConsonances);
        AssertListEqual(actual.VariableDissonances, expected.VariableDissonances);
    }

    private static void AssertListEqual(System.Collections.Generic.List<Interval> a, System.Collections.Generic.List<Interval> b)
    {
        var ax = a.OrderBy(x => x.Number).ToArray();
        var bx = b.OrderBy(x => x.Number).ToArray();

        Assert.That(ax.Length, Is.EqualTo(bx.Length), "Length mismatch");

        for (int i = 0; i < ax.Length; i++)
        {
            Assert.That(ax[i].Number, Is.EqualTo(bx[i].Number), "Number mismatch");
            Assert.That(ax[i].IsConsonant, Is.EqualTo(bx[i].IsConsonant), "Consonance flag mismatch");
            Assert.That(ax[i].UpperSuspensionTreatmentEnum, Is.EqualTo(bx[i].UpperSuspensionTreatmentEnum), "Upper suspension mismatch");
            Assert.That(ax[i].LowerSuspensionTreatmentEnum, Is.EqualTo(bx[i].LowerSuspensionTreatmentEnum), "Lower suspension mismatch");
        }
    }
}