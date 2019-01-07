using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace UCTS.Simulator
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
            _clientSim.BindReceivers();
            _clientSim.SendMessage(user, "Test");


            Console.WriteLine("Hello World!");

            while(true)
            {
                string msg = Console.ReadLine();
                _clientSim.SendMessage(user, msg);
                if (msg.Equals("quit"))
                    break;
            }
        }
    }
}
