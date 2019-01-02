using System;
using System.Diagnostics;
using Newtonsoft.Json;
using UCTS.Entities;
using UCTS.Manager.BL;
using Xunit;

namespace UCTS.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void TestCarFactory()
        {
            var carName = "First Car";
            var carType = CarType.Private;
            ICar car = CarFactory.Instance.GetCar(carName, carType);
            Console.WriteLine("Creating a Private Car");
            Assert.Equal(carName, car.CarName);
            Assert.Equal( carType, car.CarType);

        }

        [Fact]
        public void TestTravelFactory()
        {
            ITravel travel = TravelFactory.Instance.GetTravel(CarType.Private);
            string json = JsonConvert.SerializeObject(travel);

            Console.WriteLine($"Travel ({CarType.Private}) = {json} //");
        }

        [Fact]
        public void TestTravelGeneration()
        {
            const int MAX_TRAVEL_GENERATION = 15;
            for(var i=0; i< MAX_TRAVEL_GENERATION; i++)
            {
                ITravel travel = TravelFactory.Instance.GetTravel();
                string json = JsonConvert.SerializeObject(travel);

                Trace.WriteLine($"Travel no {i} = {json} //");

            }
        }
    }
}
