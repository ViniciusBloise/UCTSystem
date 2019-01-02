using System;
namespace UCTS.Entities
{
    public class PrivateCar : Car
    {
        public PrivateCar()
        {
            this.CarType = CarType.Private;
            SetInitialAttribs();
        }
        public PrivateCar(string carName)
        {
            this.CarType = CarType.Private;
            this.CarName = carName;
            SetInitialAttribs();
        }
        private void SetInitialAttribs()
        {
            ICarBaseAttribs attribs = this;
            attribs.Allowed_max_speed = 100.0;
            attribs.Allowed_num_passengers = 4;
            attribs.Cost_per_km = 1.5;
        }
    }
}
