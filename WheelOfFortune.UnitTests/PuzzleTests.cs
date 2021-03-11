using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WheelOfFortune.UnitTests
{
    [TestClass]
    public class PuzzleTests
    {
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

        [TestMethod]
        public void DisplayPhrase_TwoGuessedLetters_DisplaysDashesAndLetters()
        {
            var puzzle = new Puzzle();

            puzzle.GetNumberOfMatches('O');
            var outputString = puzzle.DisplayPhrase();

            Assert.AreEqual(outputString, "----O-O-- ----");
        }

        [TestMethod]
        public void DisplayPhrase_AllLettersGuessed_DisplaysAllLetters()
        {
            var puzzle = new Puzzle();

            puzzle.PhraseMatches("microsoft lEAp");
            var outputString = puzzle.DisplayPhrase();

            Assert.AreEqual(outputString, "MICROSOFT LEAP");
        }

        [TestMethod]
        public void GetNumberOfMatches_PassingMatchingLettersUppercase_ReturnsTwo()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches('O');

            Assert.AreEqual(actualOutput, 2);
        }

        [TestMethod]
        public void GetNumberOfMatches_PassingMatchingLettersLowercase_ReturnsTwo()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches('s');

            Assert.AreEqual(actualOutput, 1);
        }

        [TestMethod]
        public void GetNumberOfMatches_PassingNonMatchingLetters_ReturnsZero()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches('d');

            Assert.AreEqual(actualOutput, 0);
        }

        [TestMethod]
        public void GetNumberOfMatches_PassingSpace_ReturnsZero()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.GetNumberOfMatches(' ');

            Assert.AreEqual(actualOutput, 0);
        }

        [TestMethod]
        public void PhraseMatches_PassingCorrectPhraseUppercase_ReturnsTrue()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.PhraseMatches("MICROSOFT LEAP");

            Assert.AreEqual(actualOutput, true);
        }

        [TestMethod]
        public void PhraseMatches_PassingCorrectPhraseLowercase_ReturnsTrue()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.PhraseMatches("microsoft leap");

            Assert.AreEqual(actualOutput, true);

        }

        [TestMethod]
        public void PhraseMatches_PassingIncorrectPhraseLowercase_ReturnsFalse()
        {
            var puzzle = new Puzzle();

            var actualOutput = puzzle.PhraseMatches("microsoft_leap");

            Assert.AreEqual(actualOutput, false);
        }
    }
}