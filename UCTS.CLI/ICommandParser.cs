using System;
namespace UCTS.CLI
{
    public interface ICommandParser
    {
        void Parse(String line);
    }

    public interface IGetParser
    {
        ICommandParser GetParser { get; }
    }
}
