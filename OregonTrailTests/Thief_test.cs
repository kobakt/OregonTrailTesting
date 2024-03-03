using OregonTrailDotNet.Event.Wild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrailTests
{
    public class Thief_test
    {
        [Fact]
        public void OnPreDestroyItems_ReturnsExpectedString()
        {
            // Arrange
            var banditsAttack = new Thief();
            string expected = "Thief comes in the\r\nnight resulting in ";

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
