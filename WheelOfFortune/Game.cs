using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public class Game
    {
        private string _welcomeMessage = "Welcome to Wheel of Fortune!";
        private List<Player> _players = new List<Player>();
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

        public void Start()
        {
            GetWelcomeMessage();
            AddPlayer();
        }

    }
}