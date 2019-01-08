using System;
using System.Threading.Tasks;
using FluentResults;
using UCTS.Simulator;

namespace UCTS.CLI
{
    public class CommandsExecutor : ICLICommands
    {
        private ICarOperations _carOperations;
        private IPublisher _publisher;
        public CommandsExecutor(ICarOperations carOperations, IPublisher publisher)
        {
            _carOperations = carOperations;
            _publisher = publisher;
        }

        public Result NewCar(string car_type, string car_name)
        {
            Task.Run(() => _carOperations.NewCarAsync(car_type, car_name));
            Task.Run(() => _publisher.AddCar(car_name));
            return Results.Ok();
        }

        public Result RemoveCar(string car_name)
        {
            var task = Task.Run(() => _carOperations.RemoveCarAsync( car_name));
            Task.Run(() => _publisher.RemoveCar(car_name));
            return Results.Ok();
        }

        public Result<string> Report(string car_name)
        {
            var task = Task.Run(() =>  _carOperations.ReportAsync(car_name));
            return Results.Ok<string>(task.Result);
        }

        public Result Set(string car_name, string attr, string value)
        {
            Task.Run(() => _carOperations.SetAsync(car_name, attr, value));
            return Results.Ok();
        }
    }
}
