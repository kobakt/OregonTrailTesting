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
        public void BearBuffaloDuckGooseRabbitSqurrel_ReturnsExpectedSimItem()
        {
            // Arrange
            SimItem expectedBear = new SimItem(Entities.Food, "Bear", "pounds", "pound", 2000, 0);
            SimItem expectedDeer = new SimItem(Entities.Food, "Deer", "pounds", "pound", 2000, 0, 50);
            SimItem expectedDuck = new SimItem(Entities.Food, "Duck", "pounds", "pound", 2000, 0);
            SimItem expectedGoose = new SimItem(Entities.Food, "Goose", "pounds", "pound", 2000, 0, 2);
            SimItem expectedRabbit = new SimItem(Entities.Food, "Rabbit", "pounds", "pound", 2000, 0, 2);
            SimItem expectedSquirrel = new SimItem(Entities.Food, "Squirrel", "pounds", "pound", 2000, 0);
            
            // Act
            SimItem actualBear = Animals.Bear;
            SimItem actualDeer = Animals.Deer;
            SimItem actualDuck = Animals.Duck;
            SimItem actualGoose = Animals.Goose;
            SimItem actualRabbit = Animals.Rabbit;
            SimItem actualSquirrel = Animals.Squirrel;

            // Assert
            Assert.Equal(expectedBear, actualBear);
            Assert.Equal(expectedDeer, actualDeer);
            Assert.Equal(expectedDuck, actualDuck);
            Assert.Equal(expectedGoose, actualGoose);
            Assert.Equal(expectedRabbit, actualRabbit);
            Assert.Equal(expectedSquirrel, actualSquirrel);
        }
       
        [Fact]
        public void BuffaloCaribou_ReturnsExpectedSimItem()
        {
            
            if (GameSimulationApp.Instance == null)
            {
                GameSimulationApp.Create(); 
            }
            // Arrange
            int randomValue = GameSimulationApp.Instance?.Random?.Next(350, 500) ?? 0;
            SimItem expectedBuffalo = new SimItem(Entities.Food, "Buffalo", "pounds", "pound", 2000, 0, randomValue);
            SimItem expectedCaribou = new SimItem (Entities.Food, "Caribou", "pounds", "pound", 2000, 0, randomValue);
            // Act
            SimItem actualBuffalo = Animals.Buffalo;
            SimItem actualCaribou = Animals.Caribou;
            // Assert
            Assert.Equal(expectedBuffalo, actualBuffalo);
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