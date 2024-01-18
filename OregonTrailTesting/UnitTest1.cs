using OregonTrailDotNet.Entity.Person;

namespace OregonTrailTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Person p = new Person(Profession.Carpenter, "test", true);
            Assert.AreEqual("test", p.Name);
        }
    }
}