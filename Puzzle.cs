using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WheelOfFortune
{
    public class Puzzle
    {
        private string _puzzlePhrase;
        private Dictionary<char, bool> _guessedLetters;
        public Puzzle()
        {
            _guessedLetters = new Dictionary<char, bool>();
            GeneratePuzzle();
            GenerateGuessedLetters();
        }
        private void GeneratePuzzle()
        {
            _puzzlePhrase = "Microsoft Leap".ToUpper();
        }
        private void GenerateGuessedLetters()
        {
            foreach (char c in _puzzlePhrase)
            {
                if (!_guessedLetters.ContainsKey(c))
                {
                    _guessedLetters[c] = false;
                }
            }
        }
        public string DisplayPhrase()
        {
            string output = "";
            foreach (char c in _puzzlePhrase)
            {
                if (_guessedLetters[c] || c == ' ')
                {
                    output += c;
                }
                else
                {
                    output += "-";
                }
            }
            return output;
        }
        public bool PhraseMatches(string guess)
        {
            var success = _puzzlePhrase == guess.ToUpper();

            if (success)
            {
                foreach (var key in _guessedLetters.Keys)
                    _guessedLetters[key] = true;
            }

            return success;
        }
        public int GetNumberOfMatches(char guess)
        {
            guess = char.ToUpper(guess);
            var count = 0;

            foreach (char c in _puzzlePhrase)
            {
                if (c == guess && c != ' ')
                    count++;
            }

            if (count > 0)
                _guessedLetters[guess] = true;


            return count;
        }
    }
}