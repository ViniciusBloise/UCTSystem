using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace UCTS.ManagerService.Hubs
{
    public class RadioHub : Hub, IRadioHub
    {
        public async Task AddCar(string sender, string car_name)
        {
            await Clients.All.SendAsync("carAdded", sender, car_name);
        }
        public async Task RemoveCar(string sender, string car_name)
        {
            await Clients.All.SendAsync("carRemoved", sender, car_name);
        }
        public async Task NewMessage(string username, string message)
        {
            await Clients.All.SendAsync("messageReceived", username, message);
        }
    }

    public interface IRadioHub
    {
        Task AddCar(string sender, string car_name);
        Task RemoveCar(string sender, string car_name);
        Task NewMessage(string username, string message);
    }
}
