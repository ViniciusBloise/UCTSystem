using System;
namespace UCTS.Entities
{
    public class Travel : ITravel
    {
        public Travel()
        {
        }

        public int NumberOfPassengers { get; set; }
        public double TravelingDistance { get; set; }
        public double AverageSpeed { get; set; }
    }
}
