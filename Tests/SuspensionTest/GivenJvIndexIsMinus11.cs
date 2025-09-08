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

            //Assert.That(upperSuspensionCannotForm, Is.EqualTo(new[] { 1 }));
            Assert.That(upperSuspensionNoteOfResolutionIsDissonant, Is.EqualTo(new[] { 0, 2, 4, 7 }));
            //Assert.That(upperSuspensionIfOnDownbeatMustFormSuspension, Is.EqualTo(new[] { 3 }));
           // Assert.That(upperSuspensionNoteOfResolutionIsFree, Is.EqualTo(Array.Empty<int>()));
            //Assert.That(upperSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant, Is.EqualTo(new [] {6}));

            //Assert.That(lowerSuspensionCannotForm, Is.EqualTo(new[] { 6 }));
            Assert.That(lowerSuspensionNoteOfResolutionIsDissonant, Is.EqualTo(new[] { 0, 2, 4, 7 }));
            Assert.That(lowerSuspensionIfOnDownbeatMustFormSuspension, Is.EqualTo(new[] { 1, 3 }));
            //Assert.That(lowerSuspensionNoteOfResolutionIsFree, Is.EqualTo(Array.Empty<int>()));
            //Assert.That(lowerSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant, Is.EqualTo(new[] { 5 }));
        }
    }
}
