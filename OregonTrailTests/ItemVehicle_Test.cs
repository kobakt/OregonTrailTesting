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
        [Fact]
        public void Wheel_Should_Have_Correct_Quantity()
        {
            // Arrange
            var defaultParts = new List<SimItem>
            {
                Parts.Wheel,
                Parts.Axle,
                Parts.Tongue
            };

            // Act
            foreach (var part in defaultParts)
            {
                switch (part.Category)
                {
                    case Entities.Wheel:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(3);
                        break;
                    case Entities.Axle:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(1);
                        break;
                    case Entities.Tongue:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(1);
                        break;
                }
            }

            // Assert
            var wheelItem = defaultParts.FirstOrDefault(part => part.Category == Entities.Wheel);
            Assert.NotNull(wheelItem);
            Assert.Equal(3, wheelItem.Quantity);
        }

        [Fact]
        public void Axle_Should_Have_Correct_Quantity()
        {
            // Arrange
            var defaultParts = new List<SimItem>
            {
                Parts.Wheel,
                Parts.Axle,
                Parts.Tongue
            };

            // Act
            foreach (var part in defaultParts)
            {
                switch (part.Category)
                {
                    case Entities.Wheel:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(3);
                        break;
                    case Entities.Axle:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(1);
                        break;
                    case Entities.Tongue:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(1);
                        break;
                }
            }

            // Assert
            var axleItem = defaultParts.FirstOrDefault(part => part.Category == Entities.Axle);
            Assert.NotNull(axleItem);
            Assert.Equal(1, axleItem.Quantity);
        }

        [Fact]
        public void Tongue_Should_Have_Correct_Quantity()
        {
            // Arrange
            var defaultParts = new List<SimItem>
            {
                Parts.Wheel,
                Parts.Axle,
                Parts.Tongue
            };

            // Act
            foreach (var part in defaultParts)
            {
                switch (part.Category)
                {
                    case Entities.Wheel:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(3);
                        break;
                    case Entities.Axle:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(1);
                        break;
                    case Entities.Tongue:
                        part.ReduceQuantity(part.MaxQuantity);
                        part.AddQuantity(1);
                        break;
                }
            }

            // Assert
            var tongueItem = defaultParts.FirstOrDefault(part => part.Category == Entities.Tongue);
            Assert.NotNull(tongueItem);
            Assert.Equal(1, tongueItem.Quantity);
        }
    }
}