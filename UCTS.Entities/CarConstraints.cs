using System;
namespace UCTS.Entities
{
    public class CarConstraints
    {
        public CarType CarType { get; set; }
        public int NumberOfSeats { get; set; }
        public double CostPerKm { get; set; }
        public double MaximalSpeed { get; set; }
    }
}
