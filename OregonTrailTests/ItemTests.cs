using NSubstitute;
using OregonTrailDotNet.Entity.Item;
using OregonTrailDotNet.Entity;
using OregonTrailDotNet.Window;
using OregonTrailDotNet;

namespace OregonTrailTests
{

    public class AnimalsTests
    {
        

        [Fact]
        public void Bear_ReturnsExpectedSimItem()
        {
            // Arrange
            SimItem expectedBear = new SimItem(Entities.Food, "Bear", "pounds", "pound", 2000, 0);
            // Act
            SimItem actualBear = Animals.Bear;
            // Assert
            Assert.Equal(expectedBear, actualBear);
        }

        [Fact]
        public void Deer_ReturnsExpectedSimItem()
        {
            //Arrange
            SimItem expectedDeer = new SimItem(Entities.Food, "Deer", "pounds", "pound", 2000, 0, 50);
            //Act
            SimItem actualDeer = Animals.Deer;
            //Assert
            Assert.Equal(expectedDeer, actualDeer);
        }

        [Fact]
        public void Duck_ReturnsExpectedSimItem()
        {
            //Arrange
            SimItem expectedDuck = new SimItem(Entities.Food, "Duck", "pounds", "pound", 2000, 0);
            //Act
            SimItem actualDuck = Animals.Duck;
            //Assert
            Assert.Equal(expectedDuck, actualDuck);
        }

        [Fact]
        public void Goose_ReturnsExpectedSimItem()
        {
            //Arrange
            SimItem expectedGoose = new SimItem(Entities.Food, "Goose", "pounds", "pound", 2000, 0, 2);
            //Act
            SimItem actualGoose = Animals.Goose;
            //Assert
            Assert.Equal(expectedGoose, actualGoose);
        }

        [Fact]
        public void Rabbit_ReturnsExpectedSimItem()
        {
            //Arrange
            SimItem expectedRabbit = new SimItem(Entities.Food, "Rabbit", "pounds", "pound", 2000, 0, 2);
            //Act
            SimItem actualRabbit = Animals.Rabbit;
            //Assert
            Assert.Equal(expectedRabbit, actualRabbit);
        }

        [Fact]
        public void Squirrel_ReturnsExpectedSimItem()
        {
            //Arrange
            SimItem expectedSquirrel = new SimItem(Entities.Food, "Squirrel", "pounds", "pound", 2000, 0);
            //Act
            SimItem actualSquirrel = Animals.Squirrel;
            //Assert
            Assert.Equal(expectedSquirrel, actualSquirrel);
        }
       
        [Fact]
        public void Buffalo_ReturnsExpectedSimItem()
        {
            
            if (GameSimulationApp.Instance == null)
            {
                GameSimulationApp.Create(); 
            }
            // Arrange
            int randomValue = GameSimulationApp.Instance?.Random?.Next(350, 500) ?? 0;
            SimItem expectedBuffalo = new SimItem(Entities.Food, "Buffalo", "pounds", "pound", 2000, 0, randomValue);
            // Act
            SimItem actualBuffalo = Animals.Buffalo;
            // Assert
            Assert.Equal(expectedBuffalo, actualBuffalo);
            
        }
        [Fact]

        public void Caribou_RetursExpectedSimItem()
        {
            if (GameSimulationApp.Instance == null)
            {
                GameSimulationApp.Create(); 
            }
            // Arrange
            int randomValue = GameSimulationApp.Instance?.Random?.Next(350, 500) ?? 0;
            SimItem expectedCaribou = new SimItem (Entities.Food, "Caribou", "pounds", "pound", 2000, 0, randomValue);
            //Act
            SimItem actualCaribou = Animals.Caribou;
            //Assert
            Assert.Equal(expectedCaribou, actualCaribou);
        }
        
        [Fact]
        public void SimItem_Initialization()
        {
            // Arrange
            Entities category = Entities.Food;
            string name = "TestItem";
            string pluralForm = "TestItems";
            string delineatingUnit = "unit";
            int maxQuantity = 10;
            float cost = 5.0f;
            int weight = 1;
            int minimumQuantity = 1;
            int startingQuantity = 0;
            int pointsAwarded = 1;
            int pointsPerAmount = 1;
            // Act
            var Item = new SimItem(
                category, name, pluralForm, delineatingUnit, maxQuantity, cost, weight,
                minimumQuantity, startingQuantity, pointsAwarded, pointsPerAmount
            );

            // Assert
            Assert.Equal(category, Item.Category);
            Assert.Equal(name, Item.Name);
            Assert.Equal(pluralForm, Item.PluralForm);
            Assert.Equal(delineatingUnit, Item.DelineatingUnit);
            Assert.Equal(maxQuantity, Item.MaxQuantity);
            Assert.Equal(cost, Item.Cost);
            //Assert.Equal(weight, Item.TotalWeight);
            Assert.Equal(minimumQuantity, Item.MinQuantity);
            Assert.Equal(startingQuantity, Item.Quantity);
            Assert.Equal(pointsAwarded, Item.PointsAwarded);
            Assert.Equal(pointsPerAmount, Item.PointsPerAmount);
        }
    }   
}