using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    /// <summary>Contains common methods used in the application</summary>
    class Utils
    {
        /// <summary>
        /// Captures the user input, brings it to uppercase and trims extra whitespace
        /// </summary>
        /// <returns>Formatted user input</returns>
        public static string CaptureUserInput()
        {
            string playerInput = Console.ReadLine().ToUpper().Trim();
            HandleQuit(playerInput);

            return playerInput;
        }

        /// <summary>
        /// Handles the game quit
        /// </summary>
        /// <param name="playerInput">The player input</param>
        /// <exception cref="ApplicationException">Raised when the player types 'quit'</exception>
        public static void HandleQuit(string playerInput)
        {
            if (playerInput == "QUIT")
                throw new ApplicationException();
        }
    }
}
