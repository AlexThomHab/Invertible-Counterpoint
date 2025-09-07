using Invertible_Counterpoint;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests.SuspensionTest
{
    [TestFixture]
    internal class GivenJvIndexIsMinus11
    {
        private InvertedIntervalsCalculator _calculator;
        private InvertedIntervals _result;
        private Dictionary<int, Interval> _intervals;

        [OneTimeSetUp]
        public void WhenCalculatingSuspensionTreatment()
        {
            _calculator = new InvertedIntervalsCalculator();
            _result = _calculator.Calculate(-11);
        }

        [Test]
        public void ThenTheCorrectSuspensionTreatmentIsReturned()
        {
            var returnedIntervals = new List<Interval>();
            _result.FixedConsonances.ForEach(returnedIntervals.Add);
            _result.FixedDissonances.ForEach(returnedIntervals.Add);
            _result.VariableConsances.ForEach(returnedIntervals.Add);
            _result.VariableDissonance.ForEach(returnedIntervals.Add);

            var upperSuspensionCannotForm = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.CannotFormSuspension);
            var upperSuspensionNoteOfResolutionIsDissonant = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant);
            var upperSuspensionIfOnDownbeatMustFormSuspension = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension);
            var upperSuspensionNoteOfResolutionIsFree = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsFree);

            var lowerSuspensionCannotForm = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.CannotFormSuspension);
            var lowerSuspensionNoteOfResolutionIsDissonant = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant);
            var lowerSuspensionIfOnDownbeatMustFormSuspension = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension);
            var lowerSuspensionNoteOfResolutionIsFree = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsFree);

            Assert.That(upperSuspensionCannotForm, Is.EqualTo(null));
            Assert.That(upperSuspensionNoteOfResolutionIsDissonant, Is.EqualTo(null));
            Assert.That(upperSuspensionIfOnDownbeatMustFormSuspension, Is.EqualTo(null));
            Assert.That(upperSuspensionNoteOfResolutionIsFree, Is.EqualTo(null));

            Assert.That(lowerSuspensionCannotForm, Is.EqualTo(null));
            Assert.That(lowerSuspensionNoteOfResolutionIsDissonant, Is.EqualTo(null));
            Assert.That(lowerSuspensionIfOnDownbeatMustFormSuspension, Is.EqualTo(null));
            Assert.That(lowerSuspensionNoteOfResolutionIsFree, Is.EqualTo(null));
        }
    }
}
