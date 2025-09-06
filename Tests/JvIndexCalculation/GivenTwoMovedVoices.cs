using Invertible_Counterpoint;

namespace Tests.JvIndexCalculation
{
    public class GivenTwoMovedVoices
    {
        [TestCase(0, 0, 0)]
        [TestCase(1, 3, 4)]
        [TestCase(-1, 10, 9)]
        [TestCase(8, -5, 3)]
        [TestCase(-6, -5, -11)]
        [TestCase(5, -8, -3)]
        [TestCase(-6, 3, -3)]
        public void CalculateShouldReturnExpectedJvWhenVoicesAreShifted(int voiceOneShift, int voiceTwoShift, int expectedAnswer)
        {
            var jvCalculator = new JvCalculator();
            var result = jvCalculator.Calculate(voiceOneShift, voiceTwoShift);
            Assert.That(result, Is.EqualTo(expectedAnswer));
        }
    }
}