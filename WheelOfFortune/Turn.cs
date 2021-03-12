using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    /// <summary>Handles what the user wants to do on a particular turn</summary>
    public class Turn
    {
        /// <summary>
        /// Gets the player selection
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns><c>"L"</c> if the user wants to guess a letter; <c>"S"</c> if the user wants to solve the puzzle</returns>
        private static string GetPlayerSelection(Player player)
        {
            Console.WriteLine($"{player.Name}, do you want to guess a [L]etter or [S]olve the puzzle? (L/S):");
            string playerInput = Utils.CaptureUserInput();

            while (!string.Equals("L", playerInput) && !string.Equals("S", playerInput))
            {
                Console.WriteLine("Sorry, not a valid option. Please enter [L] to guess a letter or [S] to solve the puzzle.");
                playerInput = Utils.CaptureUserInput();
            }

            return playerInput;
        }

        /// <summary>
        /// Handles the guess
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="puzzle">The puzzle</param>
        /// <returns>
        ///<c>true</c> if the letter was present in the puzzle; otherwise, <c>false</c>
        /// </returns>
        private static bool HandleGuess(Player player, Puzzle puzzle)
        {
            Console.WriteLine("Please enter a letter:");
            string playerInput = Utils.CaptureUserInput();

            while (playerInput.Length > 1 || string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = Utils.CaptureUserInput();
            }

            int result = puzzle.GetNumberOfMatches(char.Parse(playerInput));

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"There are {result} matches.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, there were no matches.");
                Console.ResetColor();
            }

            Console.WriteLine(puzzle.DisplayPhrase());

            return result > 0;
        }

        /// <summary>
        /// Handles the solve
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="puzzle">The puzzle</param>
        /// <returns><c>true</c> if the guess was successful; otherwise, <c>false</c></returns>
        /// <exception cref="ApplicationException">Raised when the game is over</exception>
        private static bool HandleSolve(Player player, Puzzle puzzle)
        {
            Console.WriteLine("Please enter a word/phrase:");
            string playerInput = Utils.CaptureUserInput();

            while (string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = Utils.CaptureUserInput();
            }

            bool result = puzzle.PhraseMatches(playerInput);

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congrats {player.Name}, you won!\n");
                Console.ResetColor();
                throw new ApplicationException();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, try again.");
                Console.ResetColor();
            }

            Console.WriteLine(puzzle.DisplayPhrase());

            return result;
        }

        /// <summary>Turn orchestrator</summary>
        /// <param name="player">The player</param>
        /// <param name="puzzle">The puzzle</param>
        /// <returns><c>true</c> if the turn resulted in a successful guess; otherwise, <c>false</c></returns>
        public static bool HandleTurn(Player player, Puzzle puzzle)
        {
            bool successfulGuess;
            string playerSelection = GetPlayerSelection(player);

            if (playerSelection == "L")
            {
                successfulGuess = HandleGuess(player, puzzle);
            }
            else
            {
                successfulGuess = HandleSolve(player, puzzle);
            }

            return successfulGuess;
        }
    }
}
