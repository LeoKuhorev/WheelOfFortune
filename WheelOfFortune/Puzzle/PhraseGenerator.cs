namespace WheelOfFortune
{
    /// <summary>
    /// Defines the <see cref="PhraseGenerator" />.
    /// </summary>
    public class PhraseGenerator : IPhraseGenerator
    {
        /// <summary>
        /// The Generate.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string Generate()
        {
            // TODO: Make it return a random phrase
            return "Microsoft Leap Rules!".ToUpper();
        }
    }
}
