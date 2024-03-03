using OregonTrailDotNet.Event.Wild;
using System.Reflection;
using OregonTrailDotNet.Entity;

namespace OregonTrailTests
{
    public class AbandonedVehicleTests
    {
        [Fact]
        public void OnPreCreateItems_ReturnsExpectedString()
        {
            // Arrange
            var abandonedVehicle = new AbandonedVehicle();
            string expected = "You find an abandoned wagon,\r\n";

            // Act
            string result = GetProtectedMethodResult(abandonedVehicle, "OnPreCreateItems");

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OnPostCreateItems_EmptyDictionary_ReturnsEmptyString()
        {
            // Arrange
            var abandonedVehicle = new AbandonedVehicle();

            // Act
            string result = GetProtectedMethodResult(abandonedVehicle, "OnPostCreateItems");

            // Assert
            Assert.Equal("but it is empty", result);
        }

        private string GetProtectedMethodResult(object obj, string methodName)
        {
            var methodInfo = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            var emptyDictionary = new Dictionary<Entities, int>();

            if (methodName == "OnPostCreateItems")
                return (string)methodInfo.Invoke(emptyDictionary, null);

            return (string)methodInfo.Invoke(obj, null);
        }

    }
}
