using System;
namespace UCTS.Entities
{
    public interface ICarRide
    {
        ICar Car { get; }
        int RideId { get; set; }
        DateTime Start { get; set; }
        DateTime? End { get; set; }
        DateTimeOffset RunningTime {get; }
        DateTimeOffset WaitingTime { get; set; }
        RideStatus Status { get; set; }
    }

    public interface ICarRideEconomics
    {
        int NumberOfPassengers { get; set; }
        double CostPerKm { get; set; }
        double TotalRunKms { get; set; }
    }

    public enum RideStatus
    {
        Running, 
        //Waiting for next travel
        Waiting,
        //Finished
        Finished,
    }
}
