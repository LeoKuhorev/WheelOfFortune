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
        public Game()
        {
            _welcomeMessage = "Welcome to Wheel of Fortune!";
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

        private void AddPlayer()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine().Trim();

            Player newPlayer = new Player(name);
            _players.Add(newPlayer);
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
            GetWelcomeMessage();
            AddPlayer();
            Console.WriteLine($"Hello {GetPlayerNames()}");
            var puzzle = new Puzzle();
            Console.WriteLine("Here's your puzzle:");
            Console.WriteLine(puzzle.DisplayPhrase());
            while (!puzzle.IsSolved())
            {
                foreach (Player player in _players)
                {
                    Turn.HandleTurn(player, puzzle);
                }
            }
        }

    }
}