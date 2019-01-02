using System;
namespace UCTS.Entities
{
    public interface ITravel
    {
        int NumberOfPassengers { get; set; }
        double TravelingDistance { get; set; }
        double AverageSpeed { get; set; } //Expected average speed

    }
}
