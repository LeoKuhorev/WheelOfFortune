namespace WheelOfFortune.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
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
        /// The SetUp.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _player = new Player();
            _fakeCaptureInput = new FakeInputUtils();
            _puzzle = new Puzzle(new FakePhraseGenerator());
        }

        /// <summary>
        /// The HandleTurn_NoGuessedLetters_DisplaysDashes.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerChoosesToGuessLetterAndEntersCorrect_ReturnsTrue()
        {
            var sequenceOfActions = new List<string>() { "L", "M" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The HandleTurn_PlayerChoosesToGuessLetterAndEntersIncorrect_ReturnsFalse.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerChoosesToGuessLetterAndEntersIncorrect_ReturnsFalse()
        {
            var sequenceOfActions = new List<string>() { "L", "Z" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The HandleTurn_PlayerEnterIncorrectOptionThenChoosesToGuessLetterAndEntersCorrect_ReturnsTrue.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerEnterIncorrectOptionThenChoosesToGuessLetterAndEntersCorrect_ReturnsTrue()
        {
            var sequenceOfActions = new List<string>() { "Z", "L", "M" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The HandleTurn_PlayerChoosesToSolvePuzzleAndEntersCorrect_ThrowsException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void HandleTurn_PlayerChoosesToSolvePuzzleAndEntersCorrect_ThrowsException()
        {
            var sequenceOfActions = new List<string>() { "S", "Microsoft Leap" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput);
        }

        /// <summary>
        /// The HandleTurn_PlayerChoosesToSolvePuzzleAndEntersIncorrect_ReturnsFalse.
        /// </summary>
        [TestMethod]
        public void HandleTurn_PlayerChoosesToSolvePuzzleAndEntersIncorrect_ReturnsFalse()
        {
            var sequenceOfActions = new List<string>() { "S", "Microsoft" };
            _fakeCaptureInput.AddInput(sequenceOfActions);

            bool result = Turn.HandleTurn(_player, _puzzle, _fakeCaptureInput);

            Assert.IsFalse(result);
        }
    }
}
