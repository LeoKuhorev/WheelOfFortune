using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Turn
    {
        private static string GetPlayerSelection(Player player)
        {
            Console.WriteLine($"{player.Name}, do you want to guess a [L]etter or [S]olve the puzzle? (L / S)");
            string playerInput = Console.ReadLine().ToUpper();
            if (playerInput == "QUIT")
                throw new ApplicationException();

            while (!string.Equals("L", playerInput) && !string.Equals("S", playerInput))
            {
                Console.WriteLine("Sorry, not a valid option. Please enter [L] for letter guess or [S] to solve the puzzle.");
                playerInput = Console.ReadLine().ToUpper().Trim();
            }

            return playerInput;
        }

        private static bool HandleGuess(Player player, Puzzle puzzle)
        {
            Console.WriteLine("Please enter a letter:");
            string playerInput = Console.ReadLine().ToUpper().Trim();

            if (playerInput == "QUIT")
                throw new ApplicationException();

            while (playerInput.Length > 1 || string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = Console.ReadLine().ToUpper().Trim();
            }

            int result = puzzle.GetNumberOfMatches(char.Parse(playerInput));

            if (result > 0)
            {
                Console.WriteLine($"There are {result} matches.");
            }
            else
            {
                Console.WriteLine("Sorry, there were no matches.");
            }

            Console.WriteLine(puzzle.DisplayPhrase());

            return result > 0;
        }

        private static bool HandleSolve(Player player, Puzzle puzzle)
        {
            Console.WriteLine("Please enter a word/phrase:");
            string playerInput = Console.ReadLine().ToUpper().Trim();

            if (playerInput == "QUIT")
                throw new ApplicationException();

            while (string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = Console.ReadLine().ToUpper().Trim();
            }

            bool result = puzzle.PhraseMatches(playerInput);

            if (result)
            {
                Console.WriteLine($"Congrats {player.Name}, you won!\n");
                throw new ApplicationException();
            }
            else
            {
                Console.WriteLine("Sorry, try again.");
            }

            Console.WriteLine(puzzle.DisplayPhrase());

            return result;
        }

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
