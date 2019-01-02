using System;
using UCTS.Entities;

namespace UCTS.Manager.BL
{
    public interface ICarFactory
    {
        ICar GetCar(String carName, CarType type);
    }
}
