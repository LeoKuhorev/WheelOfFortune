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
        /// Defines the _puzzle.
        /// </summary>
        private Puzzle _puzzle;

        /// <summary>
        /// The SetUp.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _puzzle = new Puzzle(new FakePhraseGenerator());
        }

        /// <summary>
        /// The DisplayPhrase_NoGuessedLetters_DisplaysDashes.
        /// </summary>
        [TestMethod]
        // MethodName_Scenario_ExpectedBehavior (ex. CanBeCancelledBy_UserIsAdmin_ReturnsTrue)
        public void DisplayPhrase_NoGuessedLetters_DisplaysDashes()
        {
            // Arrange

            // Act
            var outputString = _puzzle.DisplayPhrase();
            // Assert
            Assert.AreEqual(outputString, "\n--------- ----\n");
        }

        /// <summary>
        /// The DisplayPhrase_TwoGuessedLetters_DisplaysDashesAndLetters.
        /// </summary>
        [TestMethod]
        public void DisplayPhrase_TwoGuessedLetters_DisplaysDashesAndLetters()
        {
            _puzzle.GetNumberOfMatches('O');
            var outputString = _puzzle.DisplayPhrase();

            Assert.AreEqual(outputString, "\n----O-O-- ----\n");
        }

        /// <summary>
        /// The DisplayPhrase_AllLettersGuessed_DisplaysAllLetters.
        /// </summary>
        [TestMethod]
        public void DisplayPhrase_AllLettersGuessed_DisplaysAllLetters()
        {
            _puzzle.PhraseMatches("microsoft lEAp");
            var outputString = _puzzle.DisplayPhrase();

            Assert.AreEqual(outputString, "\nMICROSOFT LEAP\n");
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingMatchingLettersUppercase_ReturnsTwo.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingMatchingLettersUppercase_ReturnsTwo()
        {
            var actualOutput = _puzzle.GetNumberOfMatches('O');

            Assert.AreEqual(actualOutput, 2);
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingMatchingLettersLowercase_ReturnsTwo.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingMatchingLettersLowercase_ReturnsTwo()
        {
            var actualOutput = _puzzle.GetNumberOfMatches('s');

            Assert.AreEqual(actualOutput, 1);
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingNonMatchingLetters_ReturnsZero.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingNonMatchingLetters_ReturnsZero()
        {
            var actualOutput = _puzzle.GetNumberOfMatches('d');

            Assert.AreEqual(actualOutput, 0);
        }

        /// <summary>
        /// The GetNumberOfMatches_PassingSpace_ReturnsZero.
        /// </summary>
        [TestMethod]
        public void GetNumberOfMatches_PassingSpace_ReturnsZero()
        {
            var actualOutput = _puzzle.GetNumberOfMatches(' ');

            Assert.AreEqual(actualOutput, 0);
        }

        /// <summary>
        /// The PhraseMatches_PassingCorrectPhraseUppercase_ReturnsTrue.
        /// </summary>
        [TestMethod]
        public void PhraseMatches_PassingCorrectPhraseUppercase_ReturnsTrue()
        {
            var actualOutput = _puzzle.PhraseMatches("MICROSOFT LEAP");

            Assert.AreEqual(actualOutput, true);
        }

        /// <summary>
        /// The PhraseMatches_PassingCorrectPhraseLowercase_ReturnsTrue.
        /// </summary>
        [TestMethod]
        public void PhraseMatches_PassingCorrectPhraseLowercase_ReturnsTrue()
        {
            var actualOutput = _puzzle.PhraseMatches("microsoft leap");

            Assert.AreEqual(actualOutput, true);
        }

        /// <summary>
        /// The PhraseMatches_PassingIncorrectPhraseLowercase_ReturnsFalse.
        /// </summary>
        [TestMethod]
        public void PhraseMatches_PassingIncorrectPhraseLowercase_ReturnsFalse()
        {
            var actualOutput = _puzzle.PhraseMatches("microsoft_leap");

            Assert.AreEqual(actualOutput, false);
        }
    }
}
