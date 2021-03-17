namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PhraseGenerator" />.
    /// </summary>
    public class PhraseGenerator : IPhraseGenerator
    {
        /// <summary>
        /// Defines the _puzzles.
        /// </summary>
        private List<string> _puzzles;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhraseGenerator"/> class.
        /// </summary>
        public PhraseGenerator()
        {
            _puzzles = new List<string>();
            this.ParsePuzzleFile();
        }

        /// <summary>
        /// The Generate.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string Generate()
        {
            var random = new Random();
            int index = random.Next(_puzzles.Count);
            return _puzzles[index].ToUpper();
        }

        /// <summary>
        /// The ParsePuzzleFile.
        /// </summary>
        private void ParsePuzzleFile()
        {
            // TODO: Make it return a random phrase
            var textfile = Properties.Resources.puzzles;
            foreach (string puzzle in textfile.Split(new[] { ",\r\n", ",\r", ",\n" }, StringSplitOptions.None))
            {
                _puzzles.Add(puzzle);
            }
        }
    }
}
