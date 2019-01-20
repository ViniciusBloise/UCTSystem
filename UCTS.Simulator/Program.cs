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
                    switch (parts[0].ToLower())
                    {
                        case "remove":
                            carOps.RemoveCar(parts[1]);
                            break;
                        case "report":
                            var report = await carOps.Report(parts[1]);
                            Console.WriteLine($"Report: {report}");
                            break;
                        case "newcar":
                            var type = (parts.Length > 2) ? parts[2] : "Private";
                            carOps.NewCar(type, parts[1]);
                            break;
                        case "set":
                            if (parts.Length >= 3)
                                carOps.SetAttribute(parts[1], parts[2], parts[3]);
                            break;
                    }
                }
                clientSim.SendMessage(user, msg);
            }
        }
    }
}

