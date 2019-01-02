using System;
namespace UCTS.Entities
{
    public class MiniBusCar : Car
    {
        public MiniBusCar()
        {
            this.CarType = CarType.MiniBus;
            SetInitialAttribs();
        }
        public MiniBusCar(string carName)
        {
            this.CarType = CarType.MiniBus;
            this.CarName = carName;
            SetInitialAttribs();
        }
        private void SetInitialAttribs()
        {
            ICarBaseAttribs attribs = this;
            attribs.Allowed_max_speed = 100.0;
            attribs.Allowed_num_passengers = 10;
            attribs.Cost_per_km = 0.8;
        }
    }
}
