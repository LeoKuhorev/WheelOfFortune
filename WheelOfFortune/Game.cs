using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    /// <summary>
    /// Game orchestrator <br/>
    /// </summary>
    public class Game
    {
        private string _welcomeMessage;
        private List<Player> _players;
        private int _numberOfPlayers;

        public Game()
        {
            _welcomeMessage = " ===== Welcome to Wheel of Fortune! =====\n\nYou can type \'quit\' any time to exit the game\n";
            _players = new List<Player>();
        }

        /// <summary>Displays the welcome message.</summary>
        private void GetWelcomeMessage()
        {
            // Insert ASCII art here later
            Console.WriteLine(_welcomeMessage);
        }

        /// <summary>Gets the number of rounds. (Currently not implemented)</summary>
        private int GetNumberOfRounds() => 1;

        /// <summary> Gets the number of players and assigns the value to _numberOfPlayers.</summary>
        private void GetNumberOfPlayers()
        {
            while (true)
            {
                Console.WriteLine("Please enter the number of players (between 1 and 5)");
                var userResponse = Utils.CaptureUserInput();

                Int32.TryParse(userResponse, out _numberOfPlayers);

                if (_numberOfPlayers < 1 || _numberOfPlayers > 5)
                    Console.WriteLine("Sorry, incorrect input");
                else
                    break;
            }

        }

        /// <summary>Adds players to the _players based on _numberOfPlayers.</summary>
        private void AddPlayers()
        {
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                AddPlayer(i+1);
            }
            Console.WriteLine($"Hello {GetPlayerNames()}\n");
        }

        /// <summary>Prompts user to enter player name and creates new instance of Player</summary>
        private void AddPlayer(int playerNumber)
        {
            Console.Write($"Player {playerNumber}, enter your name: ");

            string name = Utils.CaptureUserInput();
            Player newPlayer = string.IsNullOrWhiteSpace(name) ? new Player() : new Player(name);
            _players.Add(newPlayer);

        }

        /// <summary>Returns the string of all player names separated by comma</summary>
        private string GetPlayerNames()
        {
            var output = new List<string>();

            foreach (Player player in _players)
            {
                output.Add(player.Name);
            }

            return (string.Join(", ", output));
        }

        /// <summary>Starts the game</summary>
        public void Start()
        {
            try
            {
                GetWelcomeMessage();
                GetNumberOfPlayers();
                AddPlayers();

                var puzzle = new Puzzle();
                Console.WriteLine("Here's your puzzle:");
                Console.WriteLine(puzzle.DisplayPhrase());

                while (!puzzle.IsSolved())
                {
                    foreach (Player player in _players)
                    {
                        bool successfulGuess = true;
                        while (successfulGuess)
                            successfulGuess = Turn.HandleTurn(player, puzzle);
                    }
                }
            }
            catch (ApplicationException)
            {
                Console.WriteLine("Game Over!\nThank you for playing!");
                Console.ReadLine();
            }
        }

    }
}