﻿using System;
using UCTS.Entities;

namespace UCTS.ManagerService.Services
{
    public interface ICarsRepository
    {
        ICar GetCar(string car_name);
        ICar NewCar(string car_type, string car_name);
        void RemoveCar(string car_name);
    }
}
