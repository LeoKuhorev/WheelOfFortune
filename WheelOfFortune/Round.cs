namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// Gets or sets the RoundNumber.
        /// </summary>
        private int RoundNumber { get; set; }

        /// <summary>
        /// Defines the Players.
        /// </summary>
        private List<Player> Players;

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

        /// <summary>
        /// The SetNumberOfRounds.
        /// </summary>
        /// <param name="maxNumberOfRounds">The maxNumberOfRounds<see cref="int"/>.</param>
        private void SetNumberOfRounds(int maxNumberOfRounds)
        {
            if (maxNumberOfRounds == 1)
            {
                NumberOfRounds = maxNumberOfRounds;

            }
            while (NumberOfRounds == 0)
            {
                Console.WriteLine($"Please enter the number of rounds (between 1 and {maxNumberOfRounds})");
                var userResponse = this.CaptureInput.CaptureInput();
                Int32.TryParse(userResponse, out NumberOfRounds);

                if (NumberOfRounds < 1 || NumberOfRounds > maxNumberOfRounds)
                {
                    Console.WriteLine("Sorry, incorrect input");
                    NumberOfRounds = 0;
                }
                else
                {
                    break;
                }

            }

            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
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
        /// <param name="maxNumberOfRounds">The maxNumberOfRounds<see cref="int"/>.</param>
        public void RoundFlow(IWheel wheel, int maxNumberOfRounds)
        {
            this.SetNumberOfRounds(maxNumberOfRounds);
            while (this.RoundNumber != this.NumberOfRounds)
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.Clear();
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nPlayers! Get ready for round {this.RoundNumber + 1}\n");
                Console.ResetColor();

                var puzzle = new Puzzle(this.PhraseGenerator);
                Players.ForEach(player => player.RoundScore.Reset());
                Console.WriteLine("GAME SCORE:");
                Players.ForEach(player => Console.Write($"{player.Name}: ${player.GameScore.GetBalance()}     |     "));
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Here's your puzzle:");
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

            Console.WriteLine("GAME SCORE");
            Players.ForEach(player => Console.Write($"{player.Name}: ${player.GameScore.GetBalance()}     |     "));
            Console.WriteLine("\n");

            Player winner = Players.Aggregate((p1, p2) => p1.GameScore.GetBalance() > p2.GameScore.GetBalance() ? p1 : p2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Congrats {winner.Name}, you won the game with ${winner.GameScore.GetBalance()}!");

            throw new ApplicationException();
        }
    }
}
