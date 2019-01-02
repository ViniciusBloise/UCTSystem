using System;

namespace UCTS.Entities
{
    public interface ICarBaseAttribs
    {
        double Cost_per_km { get; set; }
        int Allowed_num_passengers { get; set; }
        double Allowed_max_speed { get; set; }
    }

    public interface ICar
    {
        CarType CarType { get; }
        String CarName { get; set; }
    }

    public enum CarType
    {
        Private = 1,
        MiniBus,
        Bus
    }
    /*
     There are three car types: ‘private’, ‘minibus’ and ‘bus’.
     Each of them has a different number of seats – 4, 10 and 40, accordingly.
     Pay attention that allowed_num_passengers can never be greater than the number of seats. 
     The allowed number of passengers for each car is initialized to the maximum (number of seats in this car); 
     the cost per KM is initialized to $1.5 in the private car and to $0.8 in the larger vehicles; 
     maximal speed is set to 100Kmph for all vehicles.

        Startup configuration

           Car
           [{ "carType":"Private", "numberOfSeats":4, "costPerKm":1.5, "maximalSpeed":100.0 },
           { "carType":"Minibus", "numberOfSeats":10, "costPerKm":0.8, "maximalSpeed":100.0 },
           { "carType":"Bus", "numberOfSeats":40, "costPerKm":0.8, "maximalSpeed":100.0 }]
     */
}
