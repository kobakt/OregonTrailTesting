using NSubstitute;

using OregonTrailDotNet.Entity.Item;
using OregonTrailDotNet.Entity.Vehicle;
using OregonTrailDotNet.Entity;
using OregonTrailDotNet.Event.Animal;
using OregonTrailDotNet;

namespace OregonTrailTests
{
    
    public class CarPartsTest
    {

        [Fact]
        public void Parts_Initialization_Successful()
        {
            // Arrange & Act
            var oxen = Parts.Oxen;
            var axle = Parts.Axle;
            var tongue = Parts.Tongue;
            var wheel = Parts.Wheel;

            // Assert
            Assert.NotNull(oxen);
            Assert.NotNull(axle);
            Assert.NotNull(tongue);
            Assert.NotNull(wheel);

            Assert.Equal("Oxen", oxen.Name);
            Assert.Equal("Vehicle Axle", axle.Name);
            Assert.Equal("Vehicle Tongue", tongue.Name);
            Assert.Equal("Vehicle Wheel", wheel.Name);
        }
       
    }
}