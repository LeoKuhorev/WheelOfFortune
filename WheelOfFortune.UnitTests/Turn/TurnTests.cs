namespace WheelOfFortune.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="TurnTests" />.
    /// </summary>
    [TestClass]
    public class TurnTests
    {
        /// <summary>
        /// Defines the _fakeCaptureInput.
        /// </summary>
        private FakeInputUtils _fakeCaptureInput;

        /// <summary>
        /// Defines the _player.
        /// </summary>
        private Player _player;

        /// <summary>
        /// Defines the _puzzle.
        /// </summary>
        private Puzzle _puzzle;

        /// <summary>
        /// Defines the _wheel.
        /// </summary>
        private Wheel _wheel;

        /// <summary>
        /// The SetUp.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _player = new Player();
            _fakeCaptureInput = new FakeInputUtils();
            _puzzle = new Puzzle(new FakePhraseGenerator());
            _wheel = new Wheel();
        }

        /// <summary>
        /// The HandleTurn_NoGuessedLetters_DisplaysDashes.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerChoosesToGuessLetterAndEntersCorrect_ReturnsTrue()
        {
            var sequenceOfActions = new List<string>() { "W", "M" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput, _wheel);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The HandleTurn_PlayerChoosesToGuessLetterAndEntersIncorrect_ReturnsFalse.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerChoosesToGuessLetterAndEntersIncorrect_ReturnsFalse()
        {
            var sequenceOfActions = new List<string>() { "W", "Z" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput, _wheel);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The HandleTurn_PlayerEnterIncorrectOptionThenChoosesToGuessLetterAndEntersCorrect_ReturnsTrue.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerEnterIncorrectOptionThenChoosesToGuessLetterAndEntersCorrect_ReturnsTrue()
        {
            var sequenceOfActions = new List<string>() { "Z", "W", "M" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput, _wheel);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The HandleTurn_PlayerChoosesToSolvePuzzleAndEntersCorrect_ThrowsException.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerChoosesToSolvePuzzleAndEntersCorrect_ReturnsTrue()
        {
            var sequenceOfActions = new List<string>() { "S", "Microsoft Leap" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput, _wheel);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The HandleTurn_PlayerChoosesToSolvePuzzleAndEntersIncorrect_ReturnsFalse.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerChoosesToSolvePuzzleAndEntersIncorrect_ReturnsFalse()
        {
            var sequenceOfActions = new List<string>() { "S", "Microsoft" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput, _wheel);

            Assert.IsFalse(result);
        }
    }
}
