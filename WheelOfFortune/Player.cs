namespace WheelOfFortune
{
    /// <summary>
    /// Defines the <see cref="Player" />.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The name......
        /// </summary>
        public string Name;

        /// <summary>
        /// Defines the RoundScore.
        /// </summary>
        public Bank RoundScore;

        /// <summary>
        /// Defines the GameScore.
        /// </summary>
        public Bank GameScore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player()
        {
            Name = "Anon";
            RoundScore = new Bank();
            GameScore = new Bank();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">.</param>
        public Player(string name) : this()
        {
            Name = name;
        }
    }
}
