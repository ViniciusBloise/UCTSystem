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
        private IManagerOperations _carOperations;
        private readonly string _sender;

        public IManagerOperations Operations => _carOperations;

        public ClientSim(IConfigurationRoot config, string sender)
        {
            _configuration = config;
            _sender = sender;
        }

        public void Initialize()
        {
            var strconn = _configuration.GetConnectionString(URL_MANAGER_SERVER_CONNSTR);
            var cliconn = _configuration.GetConnectionString(URL_CLIENT_SERVICE_CONNSTR);

            _connection = new HubConnectionBuilder()
            .WithUrl(strconn)
            .Build();

            _carOperations = new ManagerOperations(cliconn, _sender);

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
            _connection.On<string, string>("carAdded", (sender, car_name) =>
            {
                var newMessage = $"{sender}: new car '{car_name}' added.";
                Console.WriteLine(newMessage);
            });
            _connection.On<string, string>("carRemoved", (sender, car_name) =>
            {
                var newMessage = $"{sender}: car '{car_name}' removed.";
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
