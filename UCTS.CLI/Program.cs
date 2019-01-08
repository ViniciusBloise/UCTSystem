using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using UCTS.Entities;
using UCTS.Manager.BL;
using UCTS.Simulator;

namespace UCTS.CLI
{
    class Program
    {
        static IClientSimulator _clientSim;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var user = Guid.NewGuid().ToString();
            _clientSim = new ClientSimulator(configuration);
            _clientSim.Initialize();
            var task = Task.Run(() => _clientSim.BindReceivers());
            task.Wait();
            //_clientSim.SendMessage(user, "Test");

            Console.WriteLine("Hello World!");

            IGetOperations getOperations = _clientSim as IGetOperations;
            ICarOperations operations = getOperations.Operations;
            IGetParser getParser = _clientSim as IGetParser;
            ICommandParser parser = getParser.GetParser;

            while (true)
            {
                string msg = Console.ReadLine();
                //_clientSim.SendMessage(user, msg);
                //var report = await operations.ReportAsync("nome");
                //operations.NewCarAsync("Mini", "NewCar1");
                //operations.SetAsync("NewCar1", "Cost_per_km", "0.6");
                //operations.RemoveCarAsync("NewCar1");
                //Console.WriteLine(report);
                if (msg.Equals("quit"))
                    break;
                parser.Parse(msg);
            }
        }

        static void GenerateTravels()
        {
            ITravel travel= TravelFactory.Instance.GetTravel(CarType.Private);
            string json = JsonConvert.SerializeObject(travel);
            Console.WriteLine($"Travel ({CarType.Private}) = {json} //");
        }
    }
}
