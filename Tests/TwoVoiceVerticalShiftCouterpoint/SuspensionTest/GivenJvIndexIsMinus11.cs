using Invertible_Counterpoint.Models;
using Invertible_Counterpoint.Services;
using Invertible_Counterpoint.Utility;

namespace Tests.TwoVoiceVerticalShiftCouterpoint.SuspensionTest
{
    [TestFixture]
    internal class GivenJvIndexIsMinus11
    {
        private TwoVoiceShiftedIntervalsGivenJvIndexCalculator _calculator;
        private InvertedIntervals _result;
        private Dictionary<int, Interval> _intervals;

        [OneTimeSetUp]
        public void WhenCalculatingSuspensionTreatment()
        {
            _calculator = new TwoVoiceShiftedIntervalsGivenJvIndexCalculator();
            _result = _calculator.Calculate(-11);
        }

        [Test]
        public void ThenTheCorrectSuspensionTreatmentIsReturned()
        {
            var returnedIntervals = new List<Interval>();
            _result.FixedConsonances.ForEach(returnedIntervals.Add);
            _result.FixedDissonances.ForEach(returnedIntervals.Add);
            _result.VariableConsonances.ForEach(returnedIntervals.Add);
            _result.VariableDissonances.ForEach(returnedIntervals.Add);

            var upperSuspensionCannotForm = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.CannotFormSuspension).Select(x => x.Number).ToList();
            var upperSuspensionNoteOfResolutionIsDissonant = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant).Select(x => x.Number).ToList();
            var upperSuspensionIfOnDownbeatMustFormSuspension = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension).Select(x => x.Number).ToList();
            var upperSuspensionNoteOfResolutionIsFree = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsFree).Select(x => x.Number).ToList();
            var upperSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant = returnedIntervals.Where(x => x.UpperSuspensionTreatmentEnum == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant).Select(x => x.Number).ToList();

            var lowerSuspensionCannotForm = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.CannotFormSuspension).Select(x => x.Number).ToList();
            var lowerSuspensionNoteOfResolutionIsDissonant = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsDissonant).Select(x => x.Number).ToList();
            var lowerSuspensionIfOnDownbeatMustFormSuspension = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspension).Select(x => x.Number).ToList();
            var lowerSuspensionNoteOfResolutionIsFree = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.NoteOfResolutionIsFree).Select(x => x.Number).ToList();
            var lowerSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant = returnedIntervals.Where(x => x.LowerSuspensionTreatmentEnum == SuspensionTreatmentEnum.IfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant).Select(x => x.Number).ToList();

            Assert.That(upperSuspensionCannotForm, Is.EquivalentTo(new[] { 1, 5 }));
            Assert.That(upperSuspensionNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] { 0, 2, 4, 7 }));
            Assert.That(upperSuspensionIfOnDownbeatMustFormSuspension, Is.EquivalentTo(new[] { 3 }));
            Assert.That(upperSuspensionNoteOfResolutionIsFree, Is.Empty);
            Assert.That(upperSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] { 6 }));

            Assert.That(lowerSuspensionCannotForm, Is.EquivalentTo(new[] { 6 }));
            Assert.That(lowerSuspensionNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] { 0, 2, 4, 7 }));
            Assert.That(lowerSuspensionIfOnDownbeatMustFormSuspension, Is.EquivalentTo(new[] { 1, 3 }));
            Assert.That(lowerSuspensionNoteOfResolutionIsFree, Is.Empty);
            Assert.That(lowerSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] { 5 }));

        }
    }
}
