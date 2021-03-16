namespace WheelOfFortune
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Puzzle" />.
    /// </summary>
    public class Puzzle
    {
        /// <summary>
        /// Defines the _puzzlePhrase.
        /// </summary>
        private string _puzzlePhrase;

        /// <summary>
        /// Defines the _guessedLetters.
        /// </summary>
        private Dictionary<char, bool> _guessedLetters;

        /// <summary>
        /// Defines the _isSolved.
        /// </summary>
        private bool _isSolved;

        /// <summary>
        /// Initializes a new instance of the <see cref="Puzzle"/> class.
        /// </summary>
        public Puzzle()
        {
            _guessedLetters = new Dictionary<char, bool>();
            _isSolved = false;
            GeneratePuzzle();
            GenerateGuessedLetters();
        }

        /// <summary>
        /// The GeneratePuzzle.
        /// </summary>
        private void GeneratePuzzle()
        {
            _puzzlePhrase = "Microsoft Leap".ToUpper();
        }

        /// <summary>
        /// Generates dictionary with every letter in the puzzle phrase as a key and sets their value to false (hidden).
        /// </summary>
        private void GenerateGuessedLetters()
        {
            foreach (char c in _puzzlePhrase)
                _guessedLetters[c] = false;
        }

        /// <summary>
        /// The DisplayPhrase.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string DisplayPhrase()
        {
            string output = "";
            foreach (char c in _puzzlePhrase)
            {
                if (_guessedLetters[c] || !char.IsLetter(c))
                    output += c;
                else
                    output += "-";
            }
            return $"\n{output}\n";
        }

        /// <summary>
        /// The PhraseMatches.
        /// </summary>
        /// <param name="guess">The user guess (entire phrase).</param>
        /// <returns>Whether or not the guess is correct.</returns>
        public bool PhraseMatches(string guess)
        {
            bool success = _puzzlePhrase == guess.ToUpper();

            if (success)
            {
                foreach (var key in _guessedLetters.Keys)
                    _guessedLetters[key] = true;

                _isSolved = true;
            }

            return success;
        }

        /// <summary>
        /// The GetNumberOfMatches.
        /// </summary>
        /// <param name="guess">The user guess (letter).</param>
        /// <returns>Number of letters found in the puzzle that were not previously guessed.</returns>
        public int GetNumberOfMatches(char guess)
        {
            guess = char.ToUpper(guess);
            var count = 0;

            foreach (char c in _puzzlePhrase)
            {
                if (c == guess && char.IsLetter(guess) && !_guessedLetters[guess])
                    count++;
            }

            if (count > 0)
                _guessedLetters[guess] = true;


            return count;
        }

        /// <summary>
        /// The IsSolved.
        /// </summary>
        /// <returns><c>true</c> if the puzzle is solved; otherwise, <c>false</c>.</returns>
        public bool IsSolved() => _isSolved;
    }
}
