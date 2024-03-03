using OregonTrailDotNet.Event.Wild;
using System.Reflection;
using OregonTrailDotNet.Entity;

namespace OregonTrailTests
{
    public class BanditsAttack_Test
    {
        [Fact]
        public void OnPreDestroyItems_ReturnsExpectedString()
        {
            // Arrange
            var banditsAttack = new BanditsAttack();
            string expected = "Bandits attack!\r\nResulting in ";

            // Act
            string result = GetProtectedMethodResult(banditsAttack, "OnPreDestroyItems");

            // Assert
            Assert.Equal(expected, result);
        }

        private string GetProtectedMethodResult(object obj, string methodName)
        {
            var methodInfo = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            return (string)methodInfo.Invoke(obj, null);
        }
    }
}
