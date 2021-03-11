using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WheelOfFortune.UnitTests
{
    [TestClass]
    public class PlayerTests
    {
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

        [TestMethod]
        public void Player_JohnDoeInput_JohnDoePlayerName()
        {
            var player = new Player("John Doe");

            var playerName = player.Name;

            Assert.AreEqual(playerName, "John Doe");
        }


    }
}