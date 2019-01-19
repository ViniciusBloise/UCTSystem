using System;
namespace UCTS.ManagerService.Models
{
    public class PrivateCarReportModel : ICarReport
    {
        public PrivateCarReportModel()
        {
        }

        public string CarName { get; set; }
        public string CarType { get; set; }
        public string TimeFromStart { get; set; }
        public string PercTimeWastedOnWaiting { get; set; }
        public int TotalNumberOfTravels { get; set; }
        ///Total income: sum of(passengers num * travel distance * cost per km) for all travels
        public decimal TotalIncome { get; set; }
    }
}
