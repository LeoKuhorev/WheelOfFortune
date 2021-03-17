namespace WheelOfFortune
{
    /// <summary>
    /// Defines the <see cref="Player" />.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The name.....
        /// </summary>
        public string Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player()
        {
            Name = "Anon";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">.</param>
        public Player(string name)
        {
            Name = name;
        }
    }
}
