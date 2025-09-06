using Invertible_Counterpoint;
using NUnit.Framework;

namespace Tests.JvIndexCalculation
{
    public class GivenAJvIndex
    {
        [TestCase(0, "Unison")]
        [TestCase(1, "Second")]
        [TestCase(2, "Third")]
        [TestCase(3, "Fourth")]
        [TestCase(4, "Fifth")]
        [TestCase(5, "Sixth")]
        [TestCase(6, "Seventh")]
        [TestCase(7, "Octave")]
        [TestCase(8, "Ninth")]
        [TestCase(9, "Tenth")]
        [TestCase(10, "Eleventh")]
        [TestCase(11, "Twelfth")]
        [TestCase(12, "Thirteenth")]
        [TestCase(13, "Fourteenth")]
        [TestCase(14, "Fifteenth")]
        [TestCase(15, "Sixteenth")]
        [TestCase(16, "Seventeenth")]
        [TestCase(17, "Eighteenth")]
        [TestCase(18, "Nineteenth")]
        public void JvToScaleDegreeShouldReturnCorrectName(int jvIndex, string expectedName)
        {
            var jvCalculator = new JvCalculator();
            var result = jvCalculator.JvToScaleDegree(jvIndex);

            Assert.That(result, Is.EqualTo(expectedName));
        }
    }
}