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
                clientSim.SendMessage(user, msg);
                carOps.NewCar("Private", msg);
            }
        }
    }
}
