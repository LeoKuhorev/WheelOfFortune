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
        /// <returns><c>"W"</c> if the user wants to spin the wheel; <c>"S"</c> if the user wants to solve the puzzle.</returns>
        private static string GetPlayerSelection(Player player, ICaptureInput captureInput)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{player.Name}, ");
            Console.ResetColor();
            Console.WriteLine($"your Round score: ${player.RoundScore.GetBalance()}");
            Console.WriteLine("Do you want to Spin the [W]heel or [S]olve the puzzle? (W/S):");

            string playerInput = captureInput.CaptureInput();

            while (!string.Equals("W", playerInput) && !string.Equals("S", playerInput))
            {
                Console.WriteLine("Sorry, not a valid option. Please enter [W] to spin the wheel or [S] to solve the puzzle.");
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
        /// <param name="spinResult">The $ amount of the spin.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool HandleGuess(Player player, Puzzle puzzle, ICaptureInput captureInput, int spinResult)
        {
            Console.WriteLine("Please enter a letter:");
            string playerInput = captureInput.CaptureInput();

            while (playerInput.Length > 1 || string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = captureInput.CaptureInput();
            }

            int result = puzzle.GetNumberOfMatches(char.Parse(playerInput));
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (result == 1)
                {
                    Console.WriteLine($"There is 1 '{playerInput}'.");
                }
                else
                {
                    Console.WriteLine($"There are {result} '{playerInput}'s.");
                }
                player.RoundScore.AddAmount(result * spinResult);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (puzzle.DisplayPhrase().Contains(playerInput))
                {
                    Console.WriteLine($"Sorry {player.Name}, '{playerInput}' is already on the board, you lose your turn");
                }
                else
                {
                    Console.WriteLine($"Sorry {player.Name}, there are no '{playerInput}'s, you lose your turn");
                }
                Console.ResetColor();
            }

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
            Console.WriteLine("Please enter your guess:");
            string playerInput = captureInput.CaptureInput();

            while (string.IsNullOrEmpty(playerInput))
            {
                Console.WriteLine("Invalid entry, please try again.");
                playerInput = captureInput.CaptureInput();
            }

            bool result = puzzle.PhraseMatches(playerInput);

            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            if (result)
            {
                player.GameScore.AddAmount(player.RoundScore.GetBalance());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congrats {player.Name}, you solved the puzzle!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(puzzle.DisplayPhrase());
                Console.ResetColor();
                Console.WriteLine($"Your total game balance is ${player.GameScore.GetBalance()}");
                Console.WriteLine("Please press enter to continue");
                captureInput.CaptureInput();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Sorry, {player.Name} that's incorrect, you lose your turn");
                Console.ResetColor();
            }
            return result;
        }

        /// <summary>
        /// The HandleTurn.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        /// <param name="wheel">The wheel<see cref="IWheel"/>.</param>
        /// <returns><c>true</c> if the turn resulted in a successful guess; otherwise, <c>false</c>.</returns>
        public static bool HandleTurn(Player player, Puzzle puzzle, ICaptureInput captureInput, IWheel wheel)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(puzzle.DisplayPhrase());
            Console.ResetColor();

            bool successfulGuess;
            string playerSelection = GetPlayerSelection(player, captureInput);

            if (playerSelection == "W")
            {
                successfulGuess = HandleSpin(player, puzzle, captureInput, wheel);
            }
            else
            {
                successfulGuess = HandleSolve(player, puzzle, captureInput);
            }

            return successfulGuess;
        }

        /// <summary>
        /// The HandleSpin.
        /// </summary>
        /// <param name="player">The player<see cref="Player"/>.</param>
        /// <param name="puzzle">The puzzle<see cref="Puzzle"/>.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        /// <param name="wheel">The wheel<see cref="IWheel"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool HandleSpin(Player player, Puzzle puzzle, ICaptureInput captureInput, IWheel wheel)
        {
            int spinResult = wheel.Spin();
            if (spinResult == -1)
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.Clear();
                }

                player.RoundScore.Reset();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{player.Name}, Your spin result: Bankrupt, you lost all your Round money!");
                Console.ResetColor();
                return false;
            }
            else if (spinResult == 0)
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.Clear();
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{player.Name}, Your spin result: Lose A Turn\n");
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Spin result: ${spinResult}");
                Console.ResetColor();
                return HandleGuess(player, puzzle, captureInput, spinResult);
            }
        }
    }
}
