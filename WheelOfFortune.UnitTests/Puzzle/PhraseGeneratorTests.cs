namespace WheelOfFortune.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="PhraseGeneratorTests" />.
    /// </summary>
    [TestClass]
    public class PhraseGeneratorTests
    {
        /// <summary>
        /// Defines the phraseGenerator.
        /// </summary>
        private PhraseGenerator phraseGenerator;

        /// <summary>
        /// The SetUp.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            phraseGenerator = new PhraseGenerator();
        }

        /// <summary>
        /// The DisplayPhrase_NoGuessedLetters_DisplaysDashes.
        /// </summary>
        [TestMethod]
        // MethodName_Scenario_ExpectedBehavior (ex. CanBeCancelledBy_UserIsAdmin_ReturnsTrue)
        public void PhraseGenerator_InvokeGenerateMethod_DoesNotReturnNullOrEmptyString()
        {
            // Arrange
            bool isEmpty = false;
            // Act
            for (int i = 0; i < 1000; i++)
            {
                if (string.IsNullOrWhiteSpace(phraseGenerator.Generate()))
                {
                    isEmpty = true;
                }
            }

            // Assert
            Assert.IsFalse(isEmpty);
        }
    }
}
