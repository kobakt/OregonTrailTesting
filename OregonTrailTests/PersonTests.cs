using NSubstitute;
using OregonTrailDotNet.Entity;
using OregonTrailDotNet.Entity.Item;
using OregonTrailDotNet.Entity.Person;
using OregonTrailDotNet.Entity.Vehicle;

namespace OregonTrailTests
{
    public class PersonTests
    {
        [Fact]
        public void HealthStatus_isGood_ByDefault()
        {
            Person p = new(Profession.Carpenter, "test", false);
            Assert.Equal(HealthStatus.Good, p.HealthStatus);
        }
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Leader_isInitial_whenCreated(bool isLeader)
        {
            Person p = new(Profession.Carpenter, "test", isLeader);
            Assert.Equal(isLeader, p.Leader);
        }
        [Theory]
        [InlineData("test")]
        [InlineData("Larry")]
        [InlineData("Mariah Montana Montgomery Mona Lisa")]
        public void Name_isInitial_whenCreated(string name)
        {
            Person p = new(Profession.Carpenter, name, false);
            Assert.Equal(name, p.Name);
        }

        [Theory]
        [InlineData(Profession.Carpenter)]
        [InlineData(Profession.Banker)]
        [InlineData(Profession.Farmer)]
        public void Profession_isInitial_whenCreated(Profession prof)
        {
            Person p = new(prof, "test", false);
            Assert.Equal(prof, p.Profession);
        }

        //[Fact]
        //public void ConsumeFood_damages_whenNoFood()
        //{
        //    Person p = new(Profession.Carpenter, "test", false);
        //    IVehicle vehicle = Substitute.For<IVehicle>();
        //    Dictionary<Entities, ISimItem> dic = new();
        //    ISimItem item = Substitute.For<ISimItem>();
        //    dic[Entities.Food] = item;
        //    p.Vehicle = vehicle;
        //    vehicle.Inventory.Returns(dic);

        //    p.ConsumeFood();

        //    Assert.Equal(HealthStatus.Fair, p.HealthStatus);
        //}

        [Fact]
        public void Kill_kills_whenGood()
        {
            Person p = new(Profession.Carpenter, "test", false);
            p.Kill();

            Assert.Equal(HealthStatus.Dead, p.HealthStatus);
        }

        [Fact]
        public void Kill_stillDead_whenDead()
        {
            Person p = new(Profession.Carpenter, "test", false);
            p.Kill();
            p.Kill();

            Assert.Equal(HealthStatus.Dead, p.HealthStatus);
        }

        [Theory]
        [InlineData(500, HealthStatus.Dead)]
        [InlineData(300, HealthStatus.VeryPoor)]
        [InlineData(200, HealthStatus.Poor)]
        [InlineData(100, HealthStatus.Fair)]
        [InlineData(10, HealthStatus.Good)]
        public void HealthStatus_isCorrect_WhenDamagedAmount(int damageAmount, HealthStatus status)
        {
            Person p = new(Profession.Carpenter, "test", false);
            p.Damage(damageAmount);

            Assert.Equal(status, p.HealthStatus);
        }
    }
}
