using System;
namespace UCTS.ManagerService.Models
{
    public class CarAttribsModel
    {
        public double? Cost_per_km {get; set;}
        public int? Allowed_num_passengers { get; set; }
        public int? Allowed_max_speed { get; set; }
    }
}
