using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using UCTS.CLI;

namespace UCTS.Simulator
{
    public class ClientSimulator : IClientSimulator, IGetOperations, IGetCommands, IGetParser, IPublisher, IGetPublisher
    {
        private static HubConnection _connection;
        private IConfigurationRoot _configuration;
        private ICarOperations _operations;
        private ICLICommands _commands;
        private ICommandParser _parser;
        private readonly string _user = Guid.NewGuid().ToString();

        public ICarOperations Operations  => _operations; 
        public ICLICommands Commands  => _commands; 
        public IPublisher GetPublisher => this;
        public ICommandParser GetParser => _parser;

        const string URL_MANAGER_SERVER_CONNSTR = "UrlManagerServer";
        const string URL_CLIENT_SERVICE_CONNSTR = "UrlClientService";

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

            _operations = new CarOperations(_configuration.GetConnectionString(URL_CLIENT_SERVICE_CONNSTR));
            _commands = new CommandsExecutor(_operations, this as IPublisher);
            _parser = new CommandParser(_commands);

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
        }

        public async void BindReceivers()
        {
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

        public async void AddCar(string car_name)
        {
            try
            {
                await _connection.InvokeAsync("AddCar", _user, car_name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void RemoveCar(string car_name)
        {
            try
            {
                await _connection.InvokeAsync("RemoveCar", _user, car_name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
