using System;
using System.Collections.Concurrent;
using UCTS.Manager.BL;

namespace UCTS.Simulator
{
    public class RideManager
    {
        private IWorkingSpace _WorkingSpace { get => WorkingSpace.Instance; }
        private ConcurrentBag<IClientSimulator> _CLISimulators { get; set; }
        const int NUM_MAX_CLIENT_SIMULATORS = 4;


        public RideManager()
        {
        }

        public void Initialize()
        {
            _WorkingSpace.Initialize();
            _CLISimulators = new ConcurrentBag<IClientSimulator>();

        }

       
    }
}
