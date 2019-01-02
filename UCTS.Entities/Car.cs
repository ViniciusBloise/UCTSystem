using System;
namespace UCTS.Entities
{
    public abstract class Car : ICar, ICarBaseAttribs, ICarOperation
    {
        public virtual CarType CarType { get; protected set; }
        public virtual string CarName { get; set; }

        public virtual double Cost_per_km { get; set; }
        public virtual int Allowed_num_passengers { get; set; }
        public virtual double Allowed_max_speed { get; set; }

        public virtual ITravel AskForTravel()
        {
            throw new NotImplementedException();
        }

        public virtual void SetAttribute(string property, string value)
        {
            throw new NotImplementedException();
        }

        public virtual void StartRunning()
        {
            throw new NotImplementedException();
        }

        public virtual void StopRunning()
        {
            throw new NotImplementedException();
        }
    }
}
