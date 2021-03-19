namespace WheelOfFortune
{
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
            var game = new Game()
            {
                MaxNumberOfPlayers = 6,
                MaxNumberOfRounds = 5
            };


            game.Start();
        }
    }
}
