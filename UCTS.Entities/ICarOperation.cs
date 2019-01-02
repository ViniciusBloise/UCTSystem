using System;
namespace UCTS.Entities
{
    public interface ICarOperation
    {
        void StartRunning();
        void StopRunning();
        ITravel AskForTravel();
        void SetAttribute(String property, String value);
    }
}
