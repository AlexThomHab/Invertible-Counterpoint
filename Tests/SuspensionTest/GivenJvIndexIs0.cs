using Invertible_Counterpoint;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests.SuspensionTest
{
    [TestFixture]
    internal class GivenJvIndexIs0
    {
        private InvertedIntervalsCalculator _calculator;
        private InvertedIntervals _result;
        private Dictionary<int, Interval> _intervals;

        [OneTimeSetUp]
        public void WhenCalculatingSuspensionTreatment()
        {
            _intervals = new Dictionary<int, Interval>() {
                {0, new Interval(0, "Unison",  true,  SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
                {1, new Interval(1, "Second",  false, SuspensionTreatmentEnum.CannotFormSuspension,        SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)},
                {2, new Interval(2, "Third",   true,  SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
                {3, new Interval(3, "Fourth",  false, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension)},
                {4, new Interval(4, "Fifth",   true,  SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsFree)},
                {5, new Interval(5, "Sixth",   true,  SuspensionTreatmentEnum.NoteOfResolutionIsFree,      SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
                {6, new Interval(6, "Seventh", false, SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension, SuspensionTreatmentEnum.CannotFormSuspension)},
                {7, new Interval(7, "Octave",  true,  SuspensionTreatmentEnum.NoteOfResolutionIsDissonant, SuspensionTreatmentEnum.NoteOfResolutionIsDissonant)},
            };

            _calculator = new InvertedIntervalsCalculator();
            _result = _calculator.Calculate(0);
        }

        [Test]
        public void ThenTheCorrectSuspensionTreatmentIsReturned()
        {
            var expectedConsonances = _intervals.Values.Where(i => i.IsConsonant).OrderBy(i => i.Number).ToList();
            var expectedDissonances = _intervals.Values.Where(i => !i.IsConsonant).OrderBy(i => i.Number).ToList();

            var actualConsonances = _result.FixedConsonances.OrderBy(i => i.Number).ToList(); //not done yet
            var actualDissonances = _result.FixedDissonances.OrderBy(i => i.Number).ToList();

            Assert.That(actualConsonances.Count, Is.EqualTo(expectedConsonances.Count));
            Assert.That(actualDissonances.Count, Is.EqualTo(expectedDissonances.Count));

            for (int i = 0; i < expectedConsonances.Count; i++)
            {
                Assert.That(actualConsonances[i].Number, Is.EqualTo(expectedConsonances[i].Number));
                Assert.That(actualConsonances[i].Name, Is.EqualTo(expectedConsonances[i].Name));
                Assert.That(actualConsonances[i].IsConsonant, Is.EqualTo(expectedConsonances[i].IsConsonant));
                Assert.That(actualConsonances[i].UpperSuspensionTreatmentEnum, Is.EqualTo(expectedConsonances[i].UpperSuspensionTreatmentEnum));
                Assert.That(actualConsonances[i].LowerSuspensionTreatmentEnum, Is.EqualTo(expectedConsonances[i].LowerSuspensionTreatmentEnum));
            }

            for (int i = 0; i < expectedDissonances.Count; i++)
            {
                Assert.That(actualDissonances[i].Number, Is.EqualTo(expectedDissonances[i].Number));
                Assert.That(actualDissonances[i].Name, Is.EqualTo(expectedDissonances[i].Name));
                Assert.That(actualDissonances[i].IsConsonant, Is.EqualTo(expectedDissonances[i].IsConsonant));
                Assert.That(actualDissonances[i].UpperSuspensionTreatmentEnum, Is.EqualTo(expectedDissonances[i].UpperSuspensionTreatmentEnum));
                Assert.That(actualDissonances[i].LowerSuspensionTreatmentEnum, Is.EqualTo(expectedDissonances[i].LowerSuspensionTreatmentEnum));
            }
        }
    }
}
