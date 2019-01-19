using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UCTS.ManagerService.Hubs;
using UCTS.ManagerService.Models;
using UCTS.ManagerService.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UCTS.ManagerService.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IHubContext<RadioHub> _radioHubContext;
        private readonly ICarsRepository _carsRepository;
        //private readonly IRadioHub _radioHub;

        public CarsController(ICarsRepository carsRepository, IHubContext<RadioHub> hubContext)
        {
            this._radioHubContext = hubContext;
            this._carsRepository = carsRepository;
            //this._radioHub = hubContext as IRadioHub;
        }

        // POST api/cars
        [HttpPost]
        public void Post([FromBody] NewCarModel value)
        {
            //if (value == null)
            //    return BadRequest();
            //if (!ModelState.IsValid)
            //return BadRequest(ModelState);
            _radioHubContext.Clients.All.SendAsync("carAdded", "Server", value.CarName);
            
            Console.WriteLine(value);
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
            Console.WriteLine($"car_name = {car_name}, value={value}");
        }

        // DELETE api/cars/car_name
        [HttpDelete("{car_name}")]
        public void Delete(string car_name)
        {
            Console.WriteLine(car_name);
        }
    }
}
