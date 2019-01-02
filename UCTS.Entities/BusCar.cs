using System;
namespace UCTS.Entities
{
    public class BusCar : Car
    {
        public BusCar()
        {
            this.CarType = CarType.Bus;
            SetInitialAttribs();
        }
        public BusCar(string carName)
        {
            this.CarType = CarType.Bus;
            this.CarName = carName;
            SetInitialAttribs();
        }
        private void SetInitialAttribs()
        {
            ICarBaseAttribs attribs = this;
            attribs.Allowed_max_speed = 100.0;
            attribs.Allowed_num_passengers = 40;
            attribs.Cost_per_km = 0.8;
        }
    }
}
