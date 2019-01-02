using System;
using System.Collections.Generic;
using UCTS.Entities;

namespace UCTS.Manager.BL
{
    public class TravelFactory : ITravelFactory
    {
        public TravelFactory() { }
        static readonly Lazy<TravelFactory> lazy = new Lazy<TravelFactory>(() => new TravelFactory());
        public static TravelFactory Instance => lazy.Value;

        private readonly static Dictionary<CarType, CarConstraints> dictCarConstraints = InitialConfiguration.GetCarConfigs();

        public ITravel GetTravel(CarType carType)
             => CreateRandomTravel(carType);

        private ITravel CreateRandomTravel(CarType carType)
        {
            var rndGen = new Random(DateTime.Now.Millisecond);
            var carConstraints = dictCarConstraints[carType];
            int numberOfPassengers = 1 + rndGen.Next(carConstraints.NumberOfSeats);
            double travelingDistance = Math.Round(1.0 + rndGen.NextDouble() * (50.0 - 1.0),1); //from 1.0 to <50
            double averageSpeed =  Math.Round((0.5 + rndGen.NextDouble() * 0.5) * carConstraints.MaximalSpeed, 2); //from 50 to <100

            var travel = new Travel()
            {
                NumberOfPassengers = numberOfPassengers,
                AverageSpeed = averageSpeed,
                TravelingDistance = travelingDistance
            };
            return travel;
        }
    }
}
