namespace WheelOfFortune.Utils
{
    using System;

    /// <summary>
    /// Defines the <see cref="InputUtils" />.
    /// </summary>
    public class InputUtils : ICaptureInput
    {
        /// <summary>
        /// Captures the user input, brings it to uppercase and trims extra whitespace.
        /// </summary>
        /// <returns>Formatted user input.</returns>
        public string CaptureInput()
        {
            string playerInput = Console.ReadLine().ToUpper().Trim();
            this.HandleQuit(playerInput);

            return playerInput;
        }

        /// <summary>
        /// Handles the game quit.
        /// </summary>
        /// <param name="playerInput">The player input.</param>
        private void HandleQuit(string playerInput)
        {
            if (playerInput == "QUIT")
                throw new ApplicationException();
        }
    }
}
