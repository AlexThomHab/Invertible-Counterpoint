using Invertible_Counterpoint.Services;
using Invertible_Counterpoint.Utility;
using Invertible_Counterpoint.Models;

namespace Tests.ThreeVoiceVerticalShiftCounterpoint.SuspensionTest
{
    internal class GivenJvPrimeIsMinus11AndDoublePrimeThree{

        private InvertedIntervals _result;

        [OneTimeSetUp]
        public void WhenWorkingOutIntervalSuspensions()
        {
            var jvCalculator = new JvCalculator();
            var jvPrime = -11;
            var jvDoublePrime = 3;
            var jvSigma = jvCalculator.JvSigmaGivenJvPrimeAndJvDoublePrime(jvPrime, jvDoublePrime);

            var threeVoiceCalculator = new ThreeVoiceGivenJvIndexValuesCalculator();
            _result = threeVoiceCalculator.Calculate(jvPrime, jvDoublePrime, jvSigma);
        }

        [Test]
        public void ThenTheCorrectResultIsReturned()
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

            Assert.That(upperSuspensionCannotForm, Is.EquivalentTo(new[] { 1, 2, 5 }));
            Assert.That(upperSuspensionNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] {4 }));
            Assert.That(upperSuspensionIfOnDownbeatMustFormSuspension, Is.Empty);
            Assert.That(upperSuspensionNoteOfResolutionIsFree, Is.Empty);
            Assert.That(upperSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] { 0, 6, 7, 3 }));

            Assert.That(lowerSuspensionCannotForm, Is.EquivalentTo(new[] { 3, 6, 7 }));
            Assert.That(lowerSuspensionNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] {  4 }));
            Assert.That(lowerSuspensionIfOnDownbeatMustFormSuspension, Is.Empty);
            Assert.That(lowerSuspensionNoteOfResolutionIsFree, Is.Empty);
            Assert.That(lowerSuspensionIfOnDownbeatMustFormSuspensionAndNoteOfResolutionIsDissonant, Is.EquivalentTo(new[] { 0, 5, 1, 2 }));
        }
    }
}
