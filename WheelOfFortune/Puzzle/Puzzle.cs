namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="Puzzle" />.
    /// </summary>
    public class Puzzle
    {
        /// <summary>
        /// The IsSolved.
        /// </summary>
        /// <returns><c>true</c> if the puzzle is solved; otherwise, <c>false</c>.</returns>
        public bool IsSolved() => _isSolved;
        /// <summary>
        /// Defines the PuzzlePhrase.
        /// </summary>
        private string PuzzlePhrase;

        /// <summary>
        /// Defines the GuessedLetters.
        /// </summary>
        private Dictionary<char, bool> GuessedLetters;

        /// <summary>
        /// Defines the _isSolved.
        /// </summary>
        private bool _isSolved;

        /// <summary>
        /// Initializes a new instance of the <see cref="Puzzle"/> class.
        /// </summary>
        /// <param name="phraseGenerator">The phraseGenerator<see cref="IPhraseGenerator"/>.</param>
        public Puzzle(IPhraseGenerator phraseGenerator)
        {
            GuessedLetters = new Dictionary<char, bool>();
            GeneratePuzzle(phraseGenerator);
            GenerateGuessedLetters();
        }

        /// <summary>
        /// The GeneratePuzzle.
        /// </summary>
        /// <param name="phraseGenerator">The phraseGenerator<see cref="IPhraseGenerator"/>.</param>
        private void GeneratePuzzle(IPhraseGenerator phraseGenerator)
        {
            PuzzlePhrase = phraseGenerator.Generate();
        }

        /// <summary>
        /// Generates dictionary with every letter in the puzzle phrase as a key and sets their value to false (hidden).
        /// </summary>
        private void GenerateGuessedLetters()
        {
            foreach (char c in PuzzlePhrase)
                GuessedLetters[c] = false;
        }

        /// <summary>
        /// The DisplayPhrase.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string DisplayPhrase()
        {
            string output = "";
            foreach (char c in PuzzlePhrase)
            {
                if (GuessedLetters[c] || !char.IsLetter(c))
                {
                    output += c;
                }
                else
                {
                    output += "-";
                }
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
            bool success = PuzzlePhrase == guess.ToUpper();

            if (success)
            {
                foreach (var key in GuessedLetters.Keys)
                {
                    GuessedLetters[key] = true;
                }

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

            foreach (char c in PuzzlePhrase)
            {
                if (c == guess && char.IsLetter(guess) && !GuessedLetters[guess])
                {
                    count++;
                }
            }

            if (count > 0)
            {
                GuessedLetters[guess] = true;
            }


            return count;
        }
    }
}
