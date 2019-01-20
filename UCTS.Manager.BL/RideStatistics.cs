using System;
using System.Collections.Generic;
using System.Text;

namespace UCTS.Manager.BL
{
    public class RideStatistics
    {
        public string CarName { get; set; }
        public string CarType { get; set; }
        public TimeSpan TimeFromStart { get; set; }
        public TimeSpan TimeWaiting { get; set; }
        public double PercTimeWastedOnWaiting => (this.TimeFromStart.TotalSeconds > 0.0) ? TimeWaiting.TotalSeconds / TimeFromStart.TotalSeconds : 0.0;
        public int RideNumber { get; set; }
        public int NumberOfPassengers { get; set; }
        public double TravelDistance { get; set; }
        public double CostPerKm { get; set; }
        ///Total income: sum of(passengers num * travel distance * cost per km) for all travels
        public decimal TotalIncome { get; set; }
    }
}
