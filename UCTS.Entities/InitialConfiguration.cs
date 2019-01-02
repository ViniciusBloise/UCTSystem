using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UCTS.Entities
{
    public class InitialConfiguration
    {
        public InitialConfiguration()
        {
        }

        public static Dictionary<CarType, CarConstraints> GetCarConfigs()
        {
            var json = "[{ \"carType\":\"Private\", \"numberOfSeats\":4, \"costPerKm\":1.5, \"maximalSpeed\":100.0 },\n           { \"carType\":\"Minibus\", \"numberOfSeats\":10, \"costPerKm\":0.8, \"maximalSpeed\":100.0 },\n           { \"carType\":\"Bus\", \"numberOfSeats\":40, \"costPerKm\":0.8, \"maximalSpeed\":100.0 }]";

            var carConstraints = JsonConvert.DeserializeObject<List<CarConstraints>>(json);

            var dictCarConstraints = new Dictionary<CarType, CarConstraints>();
            foreach(var item in carConstraints)
            {
                dictCarConstraints.Add(item.CarType, item);
            }
            return dictCarConstraints;
        }
    }
}
