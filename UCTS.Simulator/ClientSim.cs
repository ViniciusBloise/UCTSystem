using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace UCTS.Simulator
{
    public class ClientSim
    {
        const string URL_MANAGER_SERVER_CONNSTR = "UrlManagerServer";
        const string URL_CLIENT_SERVICE_CONNSTR = "UrlClientService";

        private IConfigurationRoot _configuration;
        private HubConnection _connection;
        private ICarOperations _carOperations;

        public ICarOperations Operations => _carOperations;

        public ClientSim(IConfigurationRoot config)
        {
            _configuration = config;
        }

        public void Initialize()
        {
            var strconn = _configuration.GetConnectionString(URL_MANAGER_SERVER_CONNSTR);
            var cliconn = _configuration.GetConnectionString(URL_CLIENT_SERVICE_CONNSTR);

            _connection = new HubConnectionBuilder()
            .WithUrl(strconn)
            .Build();

            _carOperations = new CarOperations(cliconn);

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
        }

        public async Task BindReceivers()
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
