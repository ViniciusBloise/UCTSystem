using System;
using UCTS.Entities;

namespace UCTS.Manager.BL
{
    public interface ITravelFactory
    {
        ITravel GetTravel(CarType carType);
        ITravel GetTravel();
    }
}
