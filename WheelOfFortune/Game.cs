using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Game
    {
        private string _welcomeMessage;
        private List<Player> _players;
        private int _numberOfPlayers;
        public Game()
        {
            _welcomeMessage = "Welcome to Wheel of Fortune!\nYou can type \'quit\' any time to exit the game";
            _players = new List<Player>();
        }

        private void GetWelcomeMessage()
        {
            // Insert ASCII art here later
            Console.WriteLine(_welcomeMessage);
        }

        private int GetNumberOfRounds()
        {
            return 1;
        }

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

        private void AddPlayers()
        {
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                AddPlayer();
            }
        }

        private void AddPlayer()
        {
            Console.Write("Enter your name: ");

            string name = Utils.CaptureUserInput();
            Player newPlayer = string.IsNullOrWhiteSpace(name) ? new Player() : new Player(name);
            _players.Add(newPlayer);

            Console.WriteLine($"Hello {GetPlayerNames()}\n");
        }

        private string GetPlayerNames()
        {
            var output = new List<string>();

            foreach (Player player in _players)
            {
                output.Add(player.Name);
            }

            return (string.Join(", ", output));
        }

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
                        {
                            successfulGuess = Turn.HandleTurn(player, puzzle);
                        }
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