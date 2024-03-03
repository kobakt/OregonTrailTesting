using OregonTrailDotNet.Entity.Item;
using OregonTrailDotNet.Entity.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrailDotNet.Entity.Vehicle
{
    public interface IVehicle : IEntity
    {
        public bool PassengersDead { get; }
        public IDictionary<Entities, SimItem> Inventory { get; }
        public ReadOnlyCollection<IPerson> Passengers { get; }
        public RationLevel Ration { get; }
        public TravelPace Pace { get; }
        public int Odometer { get; }
        public int Mileage { get; }
        public VehicleStatus Status { get; set; }
        public float Balance { get; }
        public SimItem BrokenPart { get; }
        public IPerson PassengerLeader { get; }
        public HealthStatus PassengerHealthStatus { get; }
        public int PassengerLivingCount {  get; }
        public bool TryUseSparePart();
        public void BreakRandomPart();
        public void ChangePace(TravelPace castedSpeed);
        public void AddPerson(IPerson person);
        public void Purchase(SimItem transaction);
        public void ResetVehicle(int startingMonies = 0);
        public void ChangeRations(RationLevel ration);
        public IDictionary<Entities, int> CreateRandomItems();
        public IDictionary<Entities, int> DestroyRandomItems();
        public bool ContainsItem(SimItem wantedItem);
        public void CheckStatus();
        public void ReduceMileage(int amount);
    }
}
