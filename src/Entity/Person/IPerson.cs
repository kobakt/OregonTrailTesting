
namespace OregonTrailDotNet.Entity.Person
{
    public interface IPerson : IEntity
    {
        public HealthStatus HealthStatus { get; }
        public Profession Profession { get; }
        public bool Leader { get; }
        public void HealEntirely();
        public void Damage(int amount);
        public void Kill();
        public void Infect();
        public void Injure();
    }
}
