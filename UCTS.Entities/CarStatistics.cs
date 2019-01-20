using System;
using System.Collections.Generic;
using System.Text;

namespace UCTS.Entities
{ 
    public class CarStatistics : ICloneable
    {
        public string CarName { get; set; }
        public string CarType { get; set; }
        public TimeSpan TimeFromStart { get; set; }
        public TimeSpan TimeWaiting { get; set; }
        public double PercTimeWastedOnWaiting { get; set; }

        public double TotalDistance { get; set; }
        public double AverageCapacity { get; set; }
        public int TotalNumberOfTravels { get; set; }
        ///Total income: sum of(passengers num * travel distance * cost per km) for all travels
        public decimal TotalIncome { get; set; }

        public object Clone() => this.MemberwiseClone();
        
    }
}
