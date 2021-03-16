namespace WheelOfFortune.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="PuzzleTests" />.
    /// </summary>
    [TestClass]
    public class PuzzleTests
    {
        /// <summary>
        /// The DisplayPhrase_NoGuessedLetters_DisplaysDashes.
        /// </summary>
        [TestMethod]
        // MethodName_Scenario_ExpectedBehavior (ex. CanBeCancelledBy_UserIsAdmin_ReturnsTrue)
        public void DisplayPhrase_NoGuessedLetters_DisplaysDashes()
        {
            // Arrange
            var puzzle = new Puzzle();
            // Act
            var outputString = puzzle.DisplayPhrase();
            // Assert
            Assert.AreEqual(outputString, "--------- ----");
        }

        /// <summary>
        /// The DisplayPhrase_TwoGuessedLetters_DisplaysDashesAndLetters.
        /// </summary>
        [TestMethod]
        public void DisplayPhrase_TwoGuessedLetters_DisplaysDashesAndLetters()
        {
            var puzzle = new Puzzle();

            puzzle.GetNumberOfMatches('O');
            var outputString = puzzle.DisplayPhrase();

            Assert.AreEqual(outputString, "----O-O-- ----");
        }

        /// <summary>
        /// The DisplayPhrase_AllLettersGuessed_DisplaysAllLetters.
        /// </summary>
        [TestMethod]
        public void DisplayPhrase_AllLettersGuessed_DisplaysAllLetters()
        {
            var puzzle = new Puzzle();

            puzzle.PhraseMatches("microsoft lEAp");
            var outputString = puzzle.DisplayPhrase();

            Assert.AreEqual(outputString, "MICROSOFT LEAP");
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingMatchingLettersUppercase_ReturnsTwo.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingMatchingLettersUppercase_ReturnsTwo()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches('O');

            Assert.AreEqual(actualOutput, 2);
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingMatchingLettersLowercase_ReturnsTwo.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingMatchingLettersLowercase_ReturnsTwo()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches('s');

            Assert.AreEqual(actualOutput, 1);
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingNonMatchingLetters_ReturnsZero.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingNonMatchingLetters_ReturnsZero()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches('d');

            Assert.AreEqual(actualOutput, 0);
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingSpace_ReturnsZero.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingSpace_ReturnsZero()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches(' ');

            Assert.AreEqual(actualOutput, 0);
        }

        /// <summary>
        /// The PhraseMatches_PassingCorrectPhraseUppercase_ReturnsTrue.
        /// </summary>
        [TestMethod]
        public void PhraseMatches_PassingCorrectPhraseUppercase_ReturnsTrue()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.PhraseMatches("MICROSOFT LEAP");

            Assert.AreEqual(actualOutput, true);
        }

        /// <summary>
        /// The PhraseMatches_PassingCorrectPhraseLowercase_ReturnsTrue.
        /// </summary>
        [TestMethod]
        public void PhraseMatches_PassingCorrectPhraseLowercase_ReturnsTrue()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.PhraseMatches("microsoft leap");

            Assert.AreEqual(actualOutput, true);
        }

        /// <summary>
        /// The PhraseMatches_PassingIncorrectPhraseLowercase_ReturnsFalse.
        /// </summary>
        [TestMethod]
        public void PhraseMatches_PassingIncorrectPhraseLowercase_ReturnsFalse()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.PhraseMatches("microsoft_leap");

            Assert.AreEqual(actualOutput, false);
        }
    }
}
