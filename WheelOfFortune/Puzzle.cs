using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WheelOfFortune
{
    /// <summary>Handles generation of puzzle phrase and puzzle actions</summary>
    public class Puzzle
    {
        private string _puzzlePhrase;
        private Dictionary<char, bool> _guessedLetters;
        private bool _isSolved;

        public Puzzle()
        {
            _guessedLetters = new Dictionary<char, bool>();
            _isSolved = false;
            GeneratePuzzle();
            GenerateGuessedLetters();
        }

        /// <summary>Generates the puzzle</summary>
        private void GeneratePuzzle()
        {
            _puzzlePhrase = "Microsoft Leap".ToUpper();
        }

        /// <summary>
        /// Generates dictionary with every letter in the puzzle phrase as a key and sets their value to false (hidden)
        /// </summary>
        private void GenerateGuessedLetters()
        {
            foreach (char c in _puzzlePhrase)
                _guessedLetters[c] = false;
        }

        /// <summary>
        /// Retuns the phrase replacing all letters that were not guessed with dashes
        /// </summary>
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
            return output;
        }

        /// <summary>
        /// Checks user guess against the entire puzzle
        /// </summary>
        /// <param name="guess">The user guess (entire phrase)</param>
        /// <returns>Whether or not the guess is correct</returns>
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
        /// Checks user guess for individual letters in the entire puzzle
        /// </summary>
        /// <param name="guess">The user guess (letter)</param>
        /// <returns>Number of letters found in the puzzle that were not previously guessed</returns>
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
        /// Determines whether the puzzle is solved
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the puzzle is solved; otherwise, <c>false</c>
        /// </returns>
        public bool IsSolved() => _isSolved;
    }
}