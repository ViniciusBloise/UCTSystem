using System;
namespace UCTS.Entities
{
    public interface IConsolidatedRidesReport : ICar
    {
        string TimeFromStart { get; set; }
        string PercTimeWastedOnWaiting { get; set; }
        int TotalNumberOfTravels { get; set; }
        ///Total income: sum of(passengers num * travel distance * cost per km) for all travels
        decimal TotalIncome { get; set; }
    }

    public interface IFullConsolidatedRidesReport : IConsolidatedRidesReport
    {
        ///average capacity, which is the ratio between actual number of passengers and number of seats, per KM
        double AverageCapacity { get; set; }
    }
}
