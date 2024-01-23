using OregonTrailDotNet.Entity.Person;

namespace OregonTrailTests
{
    public class ExampleTest
    {
        [Fact]
        public void ExampleTest1()
        {
            //Arrange
            //Act
            //Assert
            Assert.Equal("test", new Person(Profession.Banker, "test", true).Name);
        }

    }
}