using System;
namespace UCTS.Simulator
{
    public interface IClientSimulator
    {
        void Initialize();
        void BindReceiver();
        void SendMessage(string user, string message);
    }
}
