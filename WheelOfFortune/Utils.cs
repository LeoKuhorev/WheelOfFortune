namespace WheelOfFortune
{
    using System;

    /// <summary>
    /// Defines the <see cref="Utils" />.
    /// </summary>
    internal class Utils
    {
        /// <summary>
        /// Captures the user input, brings it to uppercase and trims extra whitespace.
        /// </summary>
        /// <returns>Formatted user input.</returns>
        public static string CaptureUserInput()
        {
            string playerInput = Console.ReadLine().ToUpper().Trim();
            HandleQuit(playerInput);

            return playerInput;
        }

        /// <summary>
        /// Handles the game quit.
        /// </summary>
        /// <param name="playerInput">The player input.</param>
        public static void HandleQuit(string playerInput)
        {
            if (playerInput == "QUIT")
                throw new ApplicationException();
        }
    }
}
