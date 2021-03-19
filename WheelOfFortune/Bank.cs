namespace WheelOfFortune
{
    /// <summary>
    /// Defines the <see cref="Bank" />.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Defines the Score.
        /// </summary>
        private int Score;

        /// <summary>
        /// The AddAmount.
        /// </summary>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int AddAmount(int amount)
        {
            if (amount >= 0)
            {
                Score += amount;
            }

            return Score;
        }

        /// <summary>
        /// The GetBalance.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetBalance()
        {
            return Score;
        }

        /// <summary>
        /// The Reset.
        /// </summary>
        public void Reset()
        {
            Score = 0;
        }
    }
}
