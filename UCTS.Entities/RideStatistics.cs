using System;
using System.Collections.Generic;
using System.Text;

namespace UCTS.Entities
{
    public class RideStatistics
    {
        public string CarName { get; set; }
        public string CarType { get; set; }
        public TimeSpan TimeFromStart { get; set; }
        public TimeSpan TimeWaiting { get; set; }
        public double PercTimeWastedOnWaiting { get; set; }
        public int RideNumber { get; set; }
        public int NumOfPassengers { get; set; }
        public double TravelDistance { get; set; }
        public double CostPerKm { get; set; }
        ///Total income: sum of(passengers num * travel distance * cost per km) for all travels
        public decimal TotalIncome { get; set; }
    }
}
