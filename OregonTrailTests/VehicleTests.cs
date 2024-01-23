using NSubstitute;
using OregonTrailDotNet.Entity.Item;
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

        [Fact]
        public void PassengersDead_ReportsFalse_WhenThereAreNoPassengers()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            //Assert
            Assert.False(vehicle.PassengersDead);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void PassengersDead_ReportsTrue_WhenThereAreMultipleDeadPassengers(int numOfDeadPassengers)
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            for (int i = 0; i < numOfDeadPassengers; i++)
            {
                IPerson person = Substitute.For<IPerson>();
                person.HealthStatus.Returns(HealthStatus.Dead);
                vehicle.AddPerson(person);
            }
            //Assert
            Assert.True(vehicle.PassengersDead);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void PassengersDead_ReportsFalse_WhenThereIsOneAlivePassenger(int numOfDeadPassengers)
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            IPerson alivePerson = Substitute.For<IPerson>();
            alivePerson.HealthStatus.Returns(HealthStatus.Good);
            vehicle.AddPerson(alivePerson);
            //Act
            for (int i = 0; i < numOfDeadPassengers; i++)
            {
                IPerson deadPerson = Substitute.For<IPerson>();
                deadPerson.HealthStatus.Returns(HealthStatus.Dead);
                vehicle.AddPerson(deadPerson);
            }
            //Assert
            Assert.False(vehicle.PassengersDead);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void PassengersDead_ReportsFalse_WhenThereArePassengersInPoorHealth(int numOfDeadPassengers)
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            for (int i = 0; i < numOfDeadPassengers; i++)
            {
                IPerson person = Substitute.For<IPerson>();
                person.HealthStatus.Returns(HealthStatus.Poor);
                vehicle.AddPerson(person);
            }
            //Assert
            Assert.False(vehicle.PassengersDead);
        }

        [Fact]
        public void Ration_IsFilling_ByDefault()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            //Assert
            Assert.Equal(RationLevel.Filling, vehicle.Ration);
        }

        [Fact]
        public void Pace_IsSteady_ByDefault()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            //Assert
            Assert.Equal(TravelPace.Steady, vehicle.Pace);
        }

        [Fact]
        public void Odometer_IsZero_ByDefault()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            //Assert
            Assert.Equal(0, vehicle.Odometer);
        }

        [Fact]
        public void Status_IsStopped_ByDefault()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            //Assert
            Assert.Equal(VehicleStatus.Stopped, vehicle.Status);
        }

        [Fact]
        public void Balance_IsZero_ByDefault()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            //Assert
            Assert.Equal(0, vehicle.Balance);
        }

        [Fact]
        public void PassengerLeader_IsNull_ByDefault()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            //Assert
            Assert.Null(vehicle.PassengerLeader);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void PassengerLeader_IsNull_WithNonLeaderPassengers(int numOfPassengers)
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            for (int i = 0; i < numOfPassengers; i++)
            {
                IPerson person = Substitute.For<IPerson>();
                person.Leader.Returns(false);
                vehicle.AddPerson(person);
            }
            //Assert
            Assert.Null(vehicle.PassengerLeader);
        }
    }
}
