using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace UCTS.Simulator
{
    class Program
    {
        //static IClientSimulator _clientSim;
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var user = Guid.NewGuid().ToString();
            var clientSim = new ClientSim(configuration, user);
            clientSim.Initialize();
            await clientSim.BindReceivers();

            clientSim.SendMessage(user, "Test");


            Console.WriteLine("Hello World!");

            IManagerOperations carOps = clientSim.Operations;
            while (true)
            {
                string msg = Console.ReadLine();
                //_clientSim.SendMessage(user, msg);
                if (msg.Equals("quit"))
                    break;
                var parts = msg.Split(" ");
                if (parts.Length > 1)
                {
                    if (parts[0] == "remove")
                        carOps.RemoveCar(parts[1]);
                    else if (parts[0] == "report")
                    {
                        var report = await carOps.Report(parts[1]);
                        Console.WriteLine($"Report: {report}");
                    }
                    else if (parts[0] == "newcar")
                    {
                        var type = (parts.Length > 2) ? parts[2] : "Private";
                        carOps.NewCar(type, parts[1]);
                    }
                }
                clientSim.SendMessage(user, msg);
            }
        }
    }
}

