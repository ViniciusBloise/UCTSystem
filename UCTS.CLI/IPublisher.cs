using System;
namespace UCTS.CLI
{
    public interface IPublisher
    {
        void SendMessage(string user, string message);
        void AddCar(string car_name);
        void RemoveCar(string car_name);
    }

    public interface IGetPublisher
    {
        IPublisher GetPublisher { get; }
    }
}
