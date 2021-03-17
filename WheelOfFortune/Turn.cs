namespace WheelOfFortune
{
    using System;
    using WheelOfFortune.Utils;

    /// <summary>
    /// Defines the <see cref="Turn" />.
    /// </summary>
    public class Turn
    {
        /// <summary>
        /// Gets the player selection.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        /// <returns><c>"L"</c> if the user wants to guess a letter; <c>"S"</c> if the user wants to solve the puzzle.</returns>
        private static string GetPlayerSelection(Player player, ICaptureInput captureInput)
        {
            Console.WriteLine($"{player.Name}, do you want to guess a [L]etter or [S]olve the puzzle? (L/S):");
            string playerInput = captureInput.CaptureInput();

            while (!string.Equals("L", playerInput) && !string.Equals("S", playerInput))
            {
                Console.WriteLine("Sorry, not a valid option. Please enter [L] to guess a letter or [S] to solve the puzzle.");
                playerInput = captureInput.CaptureInput();
            }

            return playerInput;
        }

        /// <summary>
        /// Handles the guess.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool HandleGuess(Player player, Puzzle puzzle, ICaptureInput captureInput)
        {
            Console.WriteLine("Please enter a letter:");
            string playerInput = captureInput.CaptureInput();

            while (playerInput.Length > 1 || string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = captureInput.CaptureInput();
            }

            int result = puzzle.GetNumberOfMatches(char.Parse(playerInput));

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (result == 1)
                {
                    Console.WriteLine($"There is 1 {playerInput}.");
                }
                else
                {
                    Console.WriteLine($"There are {result} {playerInput}s.");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (puzzle.DisplayPhrase().Contains(playerInput))
                {
                    Console.WriteLine($"Sorry, {playerInput} is already on the board.");
                }
                else
                {
                    Console.WriteLine($"Sorry, there are no {playerInput}s.");
                }
                Console.ResetColor();
            }

            Console.WriteLine(puzzle.DisplayPhrase());

            return result > 0;
        }

        /// <summary>
        /// Handles the solve.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        /// <returns><c>true</c> if the guess was successful; otherwise, <c>false</c>.</returns>
        private static bool HandleSolve(Player player, Puzzle puzzle, ICaptureInput captureInput)
        {
            Console.WriteLine("Please enter a word/phrase:");
            string playerInput = captureInput.CaptureInput();

            while (string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = captureInput.CaptureInput();
            }

            bool result = puzzle.PhraseMatches(playerInput);

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congrats {player.Name}, you solved the puzzle!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(puzzle.DisplayPhrase());
                Console.ResetColor();
                throw new ApplicationException();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, that's incorrect.");
                Console.ResetColor();
            }

            Console.WriteLine(puzzle.DisplayPhrase());

            return result;
        }

        /// <summary>
        /// The HandleTurn.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        /// <returns><c>true</c> if the turn resulted in a successful guess; otherwise, <c>false</c>.</returns>
        public static bool HandleTurn(Player player, Puzzle puzzle, ICaptureInput captureInput)
        {
            bool successfulGuess;
            string playerSelection = GetPlayerSelection(player, captureInput);

            if (playerSelection == "L")
            {
                successfulGuess = HandleGuess(player, puzzle, captureInput);
            }
            else
            {
                successfulGuess = HandleSolve(player, puzzle, captureInput);
            }

            return successfulGuess;
        }
    }
}
