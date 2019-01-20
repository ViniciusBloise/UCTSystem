using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UCTS.Entities;

namespace UCTS.Manager.BL
{
    public class CarOperation : ICarOperation
    {
        private readonly ITravelFactory _travelFactory;
        private RideStatistics _rideStatistics;
        private CarStatistics _carStatistics;
        private volatile bool _toBeFinished = false;

        private int WaitingTimeGeneration() => new Random(Guid.NewGuid().GetHashCode()).Next(5, 60);
        private decimal CalculateRideIncome(double distance, int noOfPassengers, double costPerKm) => Convert.ToDecimal(noOfPassengers * distance * costPerKm);
        private TimeSpan CalculateTime(double distance, double averageVelocity) => new TimeSpan(0, 0, Convert.ToInt32(distance / averageVelocity * 3600)); //km, km/h
        private Dictionary<string, string> _propertiesToUpdate = new Dictionary<string, string>();


        private ITravel _travel;
        private volatile ICar _car;
        private volatile int _currentRide = 0;

        public CarOperation(ITravelFactory travelFactory, ICar car)
        {
            _travelFactory = travelFactory;
            _car = car;
            _carStatistics = new CarStatistics()
            {
                CarName = _car.CarName,
                CarType = _car.CarType.ToString("d"),

                TotalIncome = 0.0M,
                TotalNumberOfTravels = 0,
                TimeFromStart = new TimeSpan(),
                TimeWaiting = new TimeSpan()
            };
        }

        public ITravel AskForTravel()
        {
            var travel = _travelFactory.GetTravel( _car.CarType );

            _rideStatistics = new RideStatistics()
            {
                CarName = _car.CarName,
                CarType = _car.CarType.ToString("d"),
                CostPerKm = (_car as ICarBaseAttribs).Cost_per_km,
                NumberOfPassengers = travel.NumberOfPassengers,
                TravelDistance = travel.TravelingDistance,
                TimeFromStart = CalculateTime(travel.TravelingDistance, travel.AverageSpeed),
                RideNumber = _currentRide + 1,
            };
            return travel;
        }

        public void SetAttribute(string property, string value)
        {
            if (_propertiesToUpdate.ContainsKey(property))
                _propertiesToUpdate[property] = value;
            else
                _propertiesToUpdate.Add(property, value);
        }

        public void StartRunning()
        {
            AskForTravel();
            _currentRide++;
            Trace.WriteLine($"Car {_car.CarName} started running. Ride #{_currentRide}");
            Thread.Sleep(2000);
            Task.Run(() => StopRunning());
        }

        public void StopRunning()
        {
            Trace.WriteLine($"Car {_car.CarName} stopped running. Ride # {_currentRide}");
            if (!_toBeFinished)
            {
                var timeWaiting = new TimeSpan(0, this.WaitingTimeGeneration(), 0);
                _rideStatistics.TimeWaiting = timeWaiting;
                _rideStatistics.TimeFromStart.Add(timeWaiting); //Add timewaiting to get totalTime
            }
            UpdateProperties();
            UpdateStatistics();

            if (!_toBeFinished)
                Task.Run(() => StartRunning());
        }

        private void UpdateStatistics()
        {
            CarStatistics newCarStats = _carStatistics.Clone() as CarStatistics;
            newCarStats.TimeWaiting += _rideStatistics.TimeWaiting;
            newCarStats.TimeFromStart += _rideStatistics.TimeFromStart;
            newCarStats.TotalIncome += CalculateRideIncome(_rideStatistics.TravelDistance, _rideStatistics.NumberOfPassengers, _rideStatistics.CostPerKm);
            newCarStats.TotalNumberOfTravels++;
            newCarStats.TotalDistance += _rideStatistics.TravelDistance;

            double travelDistanceSoFar = _carStatistics.TotalDistance;
            double averageCapacitySoFar = _carStatistics.AverageCapacity;

            newCarStats.AverageCapacity = (travelDistanceSoFar * averageCapacitySoFar + _rideStatistics.TravelDistance * _rideStatistics.NumberOfPassengers) / newCarStats.TotalDistance;

            _carStatistics = newCarStats;
        }

        private void UpdateProperties()
        {
            var carType = typeof(Car);
            foreach (var key in _propertiesToUpdate.Keys)
            {
                var member = carType.GetProperty(key);
                if (member != null)
                    member.SetValue(_car, _propertiesToUpdate[key]);
            }
        }

        public void FinishOperation()
        {
            _toBeFinished = true;
        }

        public CarStatistics GetStatitics()
        {
            return _carStatistics;
        }
    }
}
