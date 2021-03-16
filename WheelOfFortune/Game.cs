namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Game orchestrator <br/>.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Defines the WelcomeMessage.
        /// </summary>
        private readonly string WelcomeMessage;

        /// <summary>
        /// Defines the Players.
        /// </summary>
        private readonly List<Player> Players;

        /// <summary>
        /// Defines the NumberOfPlayers.
        /// </summary>
        private int NumberOfPlayers;

        /// <summary>
        /// Gets the MaxNumberOfPlayers.
        /// </summary>
        public int MaxNumberOfPlayers { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            WelcomeMessage = " ===== Welcome to Wheel of Fortune! =====\n\nYou can type \'quit\' any time to exit the game\n";
            Players = new List<Player>();
            MaxNumberOfPlayers = 5;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="maxNumberPlayers">The maximum number players.</param>
        public Game(int maxNumberPlayers) : this()
        {
            if (maxNumberPlayers < 1)
            {
                throw new ArgumentException("Must be greater than or equal to 1", nameof(maxNumberPlayers));
            }
            else
            {
                MaxNumberOfPlayers = maxNumberPlayers;
            }
        }

        /// <summary>
        /// The GetWelcomeMessage.
        /// </summary>
        private void GetWelcomeMessage()
        {
            // TODO: Insert ASCII art here later
            Console.WriteLine(WelcomeMessage);
        }

        /// <summary>
        /// The GetNumberOfRounds.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        private int GetNumberOfRounds() => 1;

        /// <summary>
        /// The GetNumberOfPlayers.
        /// </summary>
        private void GetNumberOfPlayers()
        {
            while (NumberOfPlayers == 0)
            {
                if (MaxNumberOfPlayers > 1)
                {
                    Console.WriteLine($"Please enter the number of players (between 1 and {MaxNumberOfPlayers})");
                    var userResponse = Utils.CaptureUserInput();
                    Int32.TryParse(userResponse, out NumberOfPlayers);

                    if (NumberOfPlayers < 1 || NumberOfPlayers > MaxNumberOfPlayers)
                    {
                        Console.WriteLine("Sorry, incorrect input");
                        NumberOfPlayers = 0;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    NumberOfPlayers = MaxNumberOfPlayers;
                }
            }
        }

        /// <summary>
        /// The AddPlayers.
        /// </summary>
        private void AddPlayers()
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                this.AddPlayer(i + 1);
            }
            Console.WriteLine($"Hello {GetPlayerNames()}\n");
        }

        /// <summary>
        /// The AddPlayer.
        /// </summary>
        /// <param name="playerNumber">The playerNumber<see cref="int"/>.</param>
        private void AddPlayer(int playerNumber)
        {
            Console.Write($"Player {playerNumber}, enter your name: ");

            string name = Utils.CaptureUserInput();
            Player newPlayer = string.IsNullOrWhiteSpace(name) ? new Player() : new Player(name);
            Players.Add(newPlayer);
        }

        /// <summary>
        /// The GetPlayerNames.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        private string GetPlayerNames()
        {
            var output = new List<string>();

            foreach (Player player in Players)
            {
                output.Add(player.Name);
            }

            return (string.Join(", ", output));
        }

        /// <summary>
        /// The Start.
        /// </summary>
        public void Start()
        {
            try
            {
                this.GetWelcomeMessage();
                this.GetNumberOfPlayers();
                this.AddPlayers();

                var puzzle = new Puzzle();
                Console.WriteLine("Here's your puzzle:");
                Console.WriteLine(puzzle.DisplayPhrase());

                while (!puzzle.IsSolved())
                {
                    foreach (Player player in Players)
                    {
                        bool successfulGuess = true;
                        while (successfulGuess)
                        {
                            successfulGuess = Turn.HandleTurn(player, puzzle);
                        }
                    }
                }
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Game Over!\nThank you for playing!\nPress ENTER to end the game.");
                Console.ReadLine();
            }
        }
    }
}
