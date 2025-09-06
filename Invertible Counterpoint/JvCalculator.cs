namespace Invertible_Counterpoint
{
    public class JvCalculator
    {
        public JvCalculator() { }

        private Dictionary<int, string> _jvToScaleDegreeDictionary
            = new()
            {
                {0, "Unison"},
                {1, "Second"},
                {2, "Third"},
                {3, "Fourth"},
                {4, "Fifth"},
                {5, "Sixth"},
                {6, "Seventh"},
                {7, "Octave"},
                {8, "Ninth"},
                {9, "Tenth"},
                {10, "Eleventh"},
                {11, "Twelfth"},
                {12, "Thirteenth"},
                {13, "Fourteenth"},
                {14, "Fifteenth"},
                {15, "Sixteenth"},
                {16, "Seventeenth"},
                {17, "Eighteenth"},
                {18, "Nineteenth"}
            };

        public int Calculate(int voiceOneShift, int voiceTwoShift)
        {
            return voiceOneShift + voiceTwoShift;
        }
        public string JvToScaleDegree(int jvIndex)
        {
            return _jvToScaleDegreeDictionary[jvIndex];
        }
    }
}
