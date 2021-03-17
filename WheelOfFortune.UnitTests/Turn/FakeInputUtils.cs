namespace WheelOfFortune.UnitTests
{
    using System.Collections.Generic;
    using WheelOfFortune.Utils;

    /// <summary>
    /// Defines the <see cref="FakeInputUtils" />.
    /// </summary>
    public class FakeInputUtils : ICaptureInput
    {
        /// <summary>
        /// Defines the Input.
        /// </summary>
        private Queue<string> Input;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeInputUtils"/> class.
        /// </summary>
        public FakeInputUtils()
        {
            Input = new Queue<string>();
        }

        /// <summary>
        /// The CaptureInput.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string CaptureInput()
        {
            return Input.Dequeue();
        }

        /// <summary>
        /// The AddInput.
        /// </summary>
        /// <param name="input">The input<see cref="List{string}"/>.</param>
        public void AddInput(List<string> input)
        {
            foreach (var inputItem in input)
            {
                Input.Enqueue(inputItem);
            }
        }
    }
}
