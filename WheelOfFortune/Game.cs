﻿namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;
    using WheelOfFortune.Utils;

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
        /// Gets or sets the MaxNumberOfPlayers.
        /// </summary>
        public int MaxNumberOfPlayers { get; set; } = 5;

        /// <summary>
        /// Defines the PhraseGenerator.
        /// </summary>
        private readonly IPhraseGenerator PhraseGenerator;

        /// <summary>
        /// Defines the CaptureInput.
        /// </summary>
        private readonly ICaptureInput CaptureInput;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="phraseGenerator">The phraseGenerator<see cref="IPhraseGenerator"/>.</param>
        /// <param name="captureInput">The captureInput<see cref="ICaptureInput"/>.</param>
        public Game(IPhraseGenerator phraseGenerator, ICaptureInput captureInput)
        {
            WelcomeMessage =
                "\n =========== Welcome to Wheel of Fortune! =========== \n" +
                "\n                  << LEAP EDITION >>                  \n" +
                "\n        Learn to spell your cohortmates' names!       \n" +
                "\n (You can type \'quit\' at any time to exit the game) \n" +
                "\n ==================================================== \n";
            Players = new List<Player>();
            PhraseGenerator = phraseGenerator;
            CaptureInput = captureInput;
        }

        /// <summary>
        /// The GetWelcomeMessage.
        /// </summary>
        private void GetWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(WelcomeMessage);
            Console.ResetColor();
        }

        /// <summary>
        /// The GetNumberOfPlayers.
        /// </summary>
        private void SetNumberOfPlayers()
        {
            while (NumberOfPlayers == 0)
            {
                if (MaxNumberOfPlayers > 1)
                {
                    Console.WriteLine($"Please enter the number of players (between 1 and {MaxNumberOfPlayers})");
                    var userResponse = this.CaptureInput.CaptureInput();
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
            Console.WriteLine($"\nHello {GetPlayerNames()}! Let's play Wheel of Fortune!\n");
        }

        /// <summary>
        /// The AddPlayer.
        /// </summary>
        /// <param name="playerNumber">The playerNumber<see cref="int"/>.</param>
        private void AddPlayer(int playerNumber)
        {
            Console.Write($"Player {playerNumber}, enter your name: ");

            string name = this.CaptureInput.CaptureInput();
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
                this.SetNumberOfPlayers();
                this.AddPlayers();
                var wheel = new Wheel();
                Round round = new Round(Players, this.PhraseGenerator, this.CaptureInput);
                round.RoundFlow(wheel);
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Game Over!\nThank you for playing!\nPress ENTER to end the game.");
                Console.ReadLine();
            }
        }
    }
}
