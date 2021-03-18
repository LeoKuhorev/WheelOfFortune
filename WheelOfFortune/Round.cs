namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;
    using WheelOfFortune.Utils;

    /// <summary>
    /// Defines the <see cref="Round" />.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Defines the NumberOfRounds.
        /// </summary>
        private int NumberOfRounds;

        /// <summary>
        /// Gets the MaxNumberOfRounds.
        /// </summary>
        private int MaxNumberOfRounds { get; set; } = 3;

        /// <summary>
        /// Gets or sets the RoundNumber.
        /// </summary>
        private int RoundNumber { get; set; } = 0;

        /// <summary>
        /// Defines the Players.
        /// </summary>
        private readonly List<Player> Players;

        /// <summary>
        /// Defines the PhraseGenerator.
        /// </summary>
        private readonly IPhraseGenerator PhraseGenerator;

        /// <summary>
        /// Defines the CaptureInput.
        /// </summary>
        private readonly ICaptureInput CaptureInput;

        /// <summary>
        /// Initializes a new instance of the <see cref="Round"/> class.
        /// </summary>
        /// <param name="players">The players<see cref="List{Player}"/>.</param>
        /// <param name="phraseGenerator">The phraseGenerator<see cref="IPhraseGenerator"/>.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        public Round(List<Player> players, IPhraseGenerator phraseGenerator, ICaptureInput captureInput)
        {
            this.Players = players;
            this.PhraseGenerator = phraseGenerator;
            this.CaptureInput = captureInput;
        }

        private void SetNumberOfRounds()
        {
            while (NumberOfRounds == 0)
            {
                if (MaxNumberOfRounds > 1)
                {
                    Console.WriteLine($"Please enter the number of rounds (between 1 and {MaxNumberOfRounds})");
                    var userResponse = this.CaptureInput.CaptureInput();
                    Int32.TryParse(userResponse, out NumberOfRounds);

                    if (NumberOfRounds < 1 || NumberOfRounds > MaxNumberOfRounds)
                    {
                        Console.WriteLine("Sorry, incorrect input");
                        NumberOfRounds = 0;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    NumberOfRounds = MaxNumberOfRounds;
                }
            }
        }

        /// <summary>
        /// The IncrementRound.
        /// </summary>
        private void IncrementRound()
        {
            RoundNumber += 1;
        }

        /// <summary>
        /// The RoundFlow.
        /// </summary>
        /// <param name="wheel">The wheel<see cref="IWheel"/>.</param>
        public void RoundFlow(IWheel wheel)
        {
            this.SetNumberOfRounds();
            while (this.RoundNumber != this.NumberOfRounds)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nPlayers! Get ready for round {this.RoundNumber + 1}\n");
                Console.ResetColor();

                var puzzle = new Puzzle(this.PhraseGenerator);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Here's your puzzle:");
                Console.WriteLine(puzzle.DisplayPhrase());
                Console.ResetColor();

                bool successfulSolve = puzzle.IsSolved();
                while (!successfulSolve)
                {
                    foreach (Player player in Players)
                    {
                        bool successfulGuess = true;
                        while (successfulGuess && !successfulSolve)
                        {
                            successfulGuess = Turn.HandleTurn(player, puzzle, this.CaptureInput, wheel);
                            successfulSolve = puzzle.IsSolved();
                        };
                    }
                }
                this.IncrementRound();
            }
            throw new ApplicationException();
        }
    }
}
