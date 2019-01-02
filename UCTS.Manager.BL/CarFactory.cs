using System;
using UCTS.Entities;

namespace UCTS.Manager.BL
{
    public sealed class CarFactory : ICarFactory
    {
        public CarFactory() { }
        static readonly Lazy<CarFactory> lazy = new Lazy<CarFactory>(() => new CarFactory());
        public static CarFactory Instance => lazy.Value;

        public ICar GetCar(string carName, CarType type)
        {
            switch(type)
            {
               case CarType.Private:
                    return new PrivateCar(carName);
                case CarType.MiniBus:
                    return new MiniBusCar(carName);
                case CarType.Bus:
                    return new BusCar(carName);
            }
            throw new NotImplementedException();
        }
    }
}
