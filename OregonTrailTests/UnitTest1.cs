using NSubstitute;
using OregonTrailDotNet.Entity;
using OregonTrailDotNet.Entity.Person;
using OregonTrailDotNet.Entity.Vehicle;

namespace OregonTrailTests
{
    public class UnitTest1
    {
        
        public class Person_Tests
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

            [Fact] public void Test_Health()
            {
                Person p = new Person(Profession.Banker, "try", false);
        
                //p.Infect();
                //p.Injure();

                // assures player starts with good health
                Assert.Equal(HealthStatus.Good, p.HealthStatus);

            }
        }
        
        public class Vehicle_Tests
        {
            [Fact] public void Test_Vehicle()
            {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            var result = vehicle.PassengerHealthStatus;
            //Assert
            Assert.Equal(HealthStatus.Dead, result);
            }

            [Fact] public void Vehicle_Stop_Test()
            {
                
                //assure vehicle is stopped upon getting it
                Vehicle vehicle = new Vehicle();
                
                Assert.Equal(VehicleStatus.Stopped, vehicle.Status);
                
            }
        }
    }
}