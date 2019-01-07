using System;
using FluentResults;

namespace UCTS.Simulator
{
    public interface ICLICommands
    {
        //Create and start running a new car, named<car_name>.
        Result NewCar(string car_type, string car_name);
        // newcar<car_type> <car_name>: 
        //remove<car_name>: Stop and remove the car<car_name> from the system.
        Result RemoveCar(string car_name);
        //report<car_name>: Get a report from <car_name>.
        Result<string> Report(string car_name);
        // set<car_name> <attr> <val>: Set attribute <attr> of<car_name> to <val>
        Result Set(string car_name, string attr, string value);
    }
}
