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
            //_radioHubContext.Clients.All.SendAsync("carAdded", sender, value.CarName);
            //_radioHub?.AddCar("sender", value.CarName);
            Console.WriteLine(value);
        }
    }
}
