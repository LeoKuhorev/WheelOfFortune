namespace WheelOfFortune.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="PlayerTests" />.
    /// </summary>
    [TestClass]
    public class PlayerTests
    {
        /// <summary>
        /// The Player_EmptyInput_AnonPlayerName.
        /// </summary>
        [TestMethod]
        // MethodName_Scenario_ExpectedBehavior (ex. CanBeCancelledBy_UserIsAdmin_ReturnsTrue)
        public void Player_EmptyInput_AnonPlayerName()
        {
            // Arrange
            var player = new Player();
            // Act
            var playerName = player.Name;
            // Assert
            Assert.AreEqual(playerName, "Anon");
        }

        /// <summary>
        /// The Player_JohnDoeInput_JohnDoePlayerName.
        /// </summary>
        [TestMethod]
        public void Player_JohnDoeInput_JohnDoePlayerName()
        {
            var player = new Player("John Doe");

            var playerName = player.Name;

            Assert.AreEqual(playerName, "John Doe");
        }
    }
}
