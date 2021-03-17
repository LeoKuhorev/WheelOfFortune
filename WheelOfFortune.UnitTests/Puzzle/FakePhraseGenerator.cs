namespace WheelOfFortune.UnitTests
{
    /// <summary>
    /// Defines the <see cref="PhraseGenerator" />.
    /// </summary>
    public class FakePhraseGenerator : IPhraseGenerator
    {
        /// <summary>
        /// The Generate.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string Generate()
        {
            return "Microsoft Leap".ToUpper();
        }
    }
}
