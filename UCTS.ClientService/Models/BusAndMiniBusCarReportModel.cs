using System;
namespace UCTS.ClientService.Models
{
    public class BusAndMiniBusCarReportModel : PrivateCarReportModel, ICarReport
    {
        public BusAndMiniBusCarReportModel()
        {
        }
        ///average capacity, which is the ratio between actual number of passengers and number of seats, per KM
        public double AverageCapacity { get; set; }
    }
}
