using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace UCTS.Simulator
{
    public class ClientSimulator : IClientSimulator
    {
        private static HubConnection _connection;
        private IConfigurationRoot _configuration;
        const string URL_MANAGER_SERVER_CONNSTR = "UrlManagerServer";

        public ClientSimulator()
        {
        }
        public ClientSimulator(IConfigurationRoot config)
        {
            _configuration = config;
        }

        public void Initialize()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(_configuration.GetConnectionString(URL_MANAGER_SERVER_CONNSTR))
                .Build();

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
        }

        public async void BindReceiver()
        {
            _connection.On<string, string>("messageReceived", (user, message) =>
            {
                var newMessage = $"{user}: {message}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void SendMessage(string user, string message)
        {
            try
            {
                await _connection.InvokeAsync("NewMessage",
                    user, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
