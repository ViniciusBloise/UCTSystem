using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCTS.ClientService.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UCTS.ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        // POST api/cars
        [HttpPost]
        public void Post([FromBody] NewCarModel value)
        {
        }

        // GET api/cars/car_name
        [HttpGet("{car_name}")]
        public ActionResult<ICarReport> Get(string car_name)
        {
            return new BusAndMiniBusCarReportModel()
            {
                CarName = "FirstCar",
                CarType = "MiniBus",
                TimeFromStart = "1h30",
                PercTimeWastedOnWaiting = "3%",
                TotalIncome = 1003.43M,
                TotalNumberOfTravels = 21,
                AverageCapacity = 0.42
            };
        }
        // PATCH api/cars/car_name
        [HttpPatch("{car_name}")]
        public void Patch(string car_name, [FromBody] CarAttribsModel value)
        {

        }

        // DELETE api/cars/car_name
        [HttpDelete("{car_name}")]
        public void Delete(string car_name)
        {

        }
    }
}
