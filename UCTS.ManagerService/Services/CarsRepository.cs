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

        public ICar GetCar(string car_name)
        {
            try
            { 
                return _carPool.GetOrAdd(car_name, null as ICar);
            }
            catch(Exception)
            {
                throw new Exception("Cannot get car.");
            }
        }

        public ICar NewCar(string car_type, string car_name)
        {
            try
            {
                Enum.TryParse<CarType>(car_type, out var enumCarType); 
                ICar car = CarFactory.Instance.GetCar(car_name, enumCarType);
                
                _carPool.AddOrUpdate(car_name, car, (name, type) => car);
                return car;

            }
            catch (Exception)
            {
                throw new Exception("Cannot add a car");
            }
        }

        public void RemoveCar(string car_name)
        {
            _carPool.TryRemove(car_name, out ICar car);
        }
        

        public void Set(string car_name, string attr, string value)
        {
            throw new NotImplementedException();
        }
    }
}
