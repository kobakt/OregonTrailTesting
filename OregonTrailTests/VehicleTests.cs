using NSubstitute;
using OregonTrailDotNet.Entity.Person;
using OregonTrailDotNet.Entity.Vehicle;

namespace OregonTrailTests
{
    public class VehicleTests
    {
        [Fact]
        public void PassengerHealthStatus_isDead_WithNoPassengers()
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

        [Theory]
        [InlineData(HealthStatus.Dead)]
        [InlineData(HealthStatus.VeryPoor)]
        [InlineData(HealthStatus.Poor)]
        [InlineData(HealthStatus.Fair)]
        [InlineData(HealthStatus.Good)]
        public void PassengerHealthStatus_isTheSameAsPassengers_WithVariableNumberOfPassengersWithSameHealthStatus(HealthStatus healthStatus)
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            for (int i = 0; i < 4; i++)
            {
                IPerson person = Substitute.For<IPerson>();
                person.HealthStatus.Returns(healthStatus);
                vehicle.AddPerson(person);
                //Act
                var result = vehicle.PassengerHealthStatus;
                //Assert
                Assert.Equal(healthStatus, result);
            }

        }

        [Fact]
        public void AddPerson_ShouldFail_WhenAddingFifthPassenger()
        {
            //Arrange
            var vehicle = new Vehicle();
            //Act
            vehicle.AddPerson(Substitute.For<IPerson>());
            vehicle.AddPerson(Substitute.For<IPerson>());
            vehicle.AddPerson(Substitute.For<IPerson>());
            vehicle.AddPerson(Substitute.For<IPerson>());
            vehicle.AddPerson(Substitute.For<IPerson>());
            //Assert
            Assert.Equal(4, vehicle.Passengers.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void AddPerson_HasCorrectNumberOfPeople_WhenAddingPerson(int numOfPeople)
        {
            //Arrange
            var vehicle = new Vehicle();
            //Act
            for (int i =0; i < numOfPeople; i++)
            {
                IPerson person = Substitute.For<IPerson>();
                vehicle.AddPerson(person);
            }
            //Assert
            Assert.Equal(numOfPeople, vehicle.Passengers.Count);
        }

        [Fact]
        public void AddPerson_DoesntAddSamePerson_WhenAddingSamePersonObject()
        {
            //Arrange
            var vehicle = new Vehicle();
            IPerson person = Substitute.For<IPerson>();
            //Act
            vehicle.AddPerson(person);
            vehicle.AddPerson(person);
            //Assert
            Assert.Single(vehicle.Passengers);
        }
    }
}
