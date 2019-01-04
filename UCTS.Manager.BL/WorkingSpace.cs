using System;
using System.Collections.Concurrent;
using UCTS.Entities;

namespace UCTS.Manager.BL
{
    public sealed class WorkingSpace : IWorkingSpace
    {
        static readonly Lazy<WorkingSpace> lazy = new Lazy<WorkingSpace>(() => new WorkingSpace());
        private WorkingSpace() { }

        public ConcurrentDictionary<String, ICar> CarPool { get; private set; }
        public ConcurrentBag<ITravel> TravelPool { get; private set; }
        public ConcurrentBag<IAssignedTravel> AssignedTravels { get; private set; }

        public static WorkingSpace Instance => lazy.Value;

        public void Initialize()
        {
            //Initialize CarPool and TravelPool
            CarPool = new ConcurrentDictionary<string, ICar>();
            TravelPool = new ConcurrentBag<ITravel>();
            AssignedTravels = new ConcurrentBag<IAssignedTravel>();
        }
    }
}
