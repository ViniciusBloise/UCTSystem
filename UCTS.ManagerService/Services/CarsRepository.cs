using System;
using System.Collections.Concurrent;
using UCTS.Entities;
using UCTS.Manager.BL;

namespace UCTS.ManagerService.Services
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ConcurrentDictionary<String, ICar> _carPool = new ConcurrentDictionary<string, ICar>();

        public CarsRepository()
        {
        }

        public void NewCar(string car_type, string car_name)
        {
            Enum.TryParse<CarType>(car_type, out var enumCarType);
            ICar car = CarFactory.Instance.GetCar(car_name, enumCarType);
            _carPool.AddOrUpdate(car_name, car, (name, type) => car);
        }

        public void RemoveCar(string car_name)
        {
            throw new NotImplementedException();
        }

        public void Report(string car_name)
        {
            throw new NotImplementedException();
        }

        public void Set(string car_name, string attr, string value)
        {
            throw new NotImplementedException();
        }
    }
}
