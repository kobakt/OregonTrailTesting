using NSubstitute;
using OregonTrailDotNet.Entity.Person;
using OregonTrailDotNet.Entity.Vehicle;

namespace OregonTrailTests
{
    public class VehiclePersonIntegration
    {
        [Fact]
        public void PassengerHealthStatus_isGood_WithDefaultPassengers()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            for (int i = 0; i < 4; i++)
            {
                IPerson person = new Person(Profession.Banker, "test", false);
                vehicle.AddPerson(person);
                //Act
                var result = vehicle.PassengerHealthStatus;
                //Assert
                Assert.Equal(HealthStatus.Good, result);
            }
        }

        [Fact]
        public void PassengerLivingCount_isCorrect_WithDefaultPassengers()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            for (int i = 0; i < 4; i++)
            {
                IPerson person = new Person(Profession.Banker, "test", false);
                vehicle.AddPerson(person);
                //Act
                var result = vehicle.PassengerLivingCount;
                //Assert
                Assert.Equal(i+1, result);
            }
        }

        [Fact]
        public void PassengerHealthStatus_isDead_WithDeadPassengers()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            for (int i = 0; i < 4; i++)
            {
                IPerson person = new Person(Profession.Banker, "test", false);
                person.Kill();
                vehicle.AddPerson(person);
                //Act
                var result = vehicle.PassengerHealthStatus;
                //Assert
                Assert.Equal(HealthStatus.Dead, result);
            }
        }

        [Fact]
        public void PassengerHealthStatus_isGood_WithOneDefaultPassengerAnd3DeadPassengers()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            IPerson person = new Person(Profession.Banker, "test", false);
            vehicle.AddPerson(person);

            for (int i = 0; i < 3; i++)
            {
                IPerson deadPerson = new Person(Profession.Banker, "test", false);
                deadPerson.Kill();
                vehicle.AddPerson(deadPerson);
            }

            //Act
            var result = vehicle.PassengerHealthStatus;
            //Assert
            Assert.Equal(HealthStatus.Good, result);
        }

        [Fact]
        public void te()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            IPerson person = new Person(Profession.Banker, "test", false);
            vehicle.AddPerson(person);

            for (int i = 0; i < 3; i++)
            {
                IPerson deadPerson = new Person(Profession.Banker, "test", false);
                deadPerson.Kill();
                vehicle.AddPerson(deadPerson);
            }

            //Act
            var result = vehicle.PassengerHealthStatus;
            //Assert
            Assert.Equal(HealthStatus.Good, result);
        }

        [Fact]
        public void PassengersDead_isFalse_WithOneDefaultPassengerAnd3DeadPassengers()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            IPerson person = new Person(Profession.Banker, "test", false);
            vehicle.AddPerson(person);

            for (int i = 0; i < 3; i++)
            {
                IPerson deadPerson = new Person(Profession.Banker, "test", false);
                deadPerson.Kill();
                vehicle.AddPerson(deadPerson);
            }

            //Act
            var result = vehicle.PassengersDead;
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void PassengersDead_isTrue_WitAllDeadPassengers()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();

            for (int i = 0; i < 4; i++)
            {
                IPerson deadPerson = new Person(Profession.Banker, "test", false);
                deadPerson.Kill();
                vehicle.AddPerson(deadPerson);
            }

            //Act
            var result = vehicle.PassengersDead;
            //Assert
            Assert.True(result);
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
                IPerson person = new Person(Profession.Banker, "test", false);
                vehicle.AddPerson(person);
            }
            //Assert
            Assert.Null(vehicle.PassengerLeader);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void PassengerLeader_IsLastPerson_WithAllLeaderPassengers(int numOfPassengers)
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            //Act
            for (int i = 0; i < numOfPassengers; i++)
            {
                IPerson person = new Person(Profession.Banker, "test" + i, true);
                vehicle.AddPerson(person);
            }
            //Assert
            Assert.Equal("test" + (numOfPassengers - 1), vehicle.PassengerLeader.Name);
        }
    }
}
