using System;
using Newtonsoft.Json;
using UCTS.Entities;
using UCTS.Manager.BL;

namespace UCTS.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitialConfiguration.GetCarConfigs();
            GenerateTravels();
        }

        static void GenerateTravels()
        {
            ITravel travel= TravelFactory.Instance.GetTravel(CarType.Private);
            string json = JsonConvert.SerializeObject(travel);
            Console.WriteLine($"Travel ({CarType.Private}) = {json} //");
        }
    }
}
