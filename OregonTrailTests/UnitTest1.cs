using NSubstitute;
using OregonTrailDotNet.Entity;
using OregonTrailDotNet.Entity.Person;
using OregonTrailDotNet.Entity.Vehicle;

namespace OregonTrailTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Person p = new Person(Profession.Banker, "test", true);
            //Act
            //Assert
            Assert.Equal("test", p.Name);
            Assert.True(p.Leader);
            Assert.Equal(Profession.Banker, p.Profession);
        }
        [Fact] public void Test_Vehicle()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            var result = vehicle.PassengerHealthStatus;
            //Assert
            Assert.Equal(HealthStatus.Dead, result);
        }
    }
}