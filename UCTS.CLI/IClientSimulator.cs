using System;
namespace UCTS.Simulator
{
    public interface IClientSimulator
    {
        void Initialize();
        void BindReceivers();
        void SendMessage(string user, string message);
    }
}
