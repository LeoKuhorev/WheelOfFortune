namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Handles Wheel.
    /// </summary>
    public class Wheel : IWheel
    {
        /// <summary>
        /// Defines the _pool. '-1' is Bankrupt, and '0' is Lose A Turn. 
        /// '5000' and '0' are included just once to decrease probability...
        /// </summary>
        private List<int> _pool;

        /// <summary>
        /// Initializes a new instance of the <see cref="Wheel"/> class.
        /// </summary>
        public Wheel()
        {
            _pool = new List<int>
            {
                -1, 0, 300, 350, 400, 450, 500, 550, 600, 700, 800, 900, 5000,
                -1, 300, 350, 400, 450, 500, 550, 600, 700, 800, 900
            };
        }

        /// <summary>
        /// The Spin will return a random value from the pool of wheel values.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int Spin()
        {
            var random = new Random();
            int index = random.Next(_pool.Count);
            return _pool[index];
        }
    }
}
