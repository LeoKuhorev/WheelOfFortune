namespace WheelOfFortune
{
    using WheelOfFortune.Utils;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            var phraseGenerator = new PhraseGenerator();
            var captureConsoleInput = new InputUtils();
            var game = new Game(phraseGenerator, captureConsoleInput)
            {
                MaxNumberOfPlayers = 3
            };

            game.Start();
        }
    }
}
