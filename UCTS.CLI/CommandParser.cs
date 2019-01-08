using System;
using System.Linq;
using UCTS.Simulator;

namespace UCTS.CLI
{
    public class CommandParser : ICommandParser
    {
        private readonly string RESERVED_WORDS = "newcar,removecar,report,set";
        private ICLICommands _commands;
        private IPublisher _publisher;
        public CommandParser(ICLICommands iCLICommands)
        {
            _commands = iCLICommands;
        }

        //Parse for the accepted commands
        public void Parse(String line)
        {
            if (!String.IsNullOrEmpty(line))
            {
                var cmdParts = line.Split(" ");
                string cmd = cmdParts[0];
                if(!RESERVED_WORDS.Split(",").Any(q => q.Equals(cmd)))
                    throw new Exception($"Unrecognized command: {cmd} ");

                switch (cmd)
                {
                    case "newcar":
                        _commands.NewCar(cmdParts[1], cmdParts[2]);
                        break;
                    case "removecar":
                        _commands.RemoveCar(cmdParts[1]);
                        break;
                    case "report":
                        _commands.Report(cmdParts[1]);
                        break;
                    case "set":
                        _commands.Set(cmdParts[1], cmdParts[2], cmdParts[3]);
                        break;
                }
                
            }
        }
    }
}
