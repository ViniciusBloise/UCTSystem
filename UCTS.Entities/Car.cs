using System;
namespace UCTS.Entities
{
    public abstract class Car : ICar, ICarBaseAttribs, IMapOperations
    {
        public virtual CarType CarType { get; protected set; }
        public virtual string CarName { get; set; }

        public virtual double Cost_per_km { get; set; }
        public virtual int Allowed_num_passengers { get; set; }
        public virtual double Allowed_max_speed { get; set; }

        public virtual ICarOperation Operation { get; set; }

    }

    public interface IMapOperations
    {
        ICarOperation Operation { get; set; }
    }
}
