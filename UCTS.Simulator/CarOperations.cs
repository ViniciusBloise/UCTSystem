using System;
using Flurl;
using Flurl.Http;
using FluentResults;
using UCTS.Simulator;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Dynamic;
using System.Collections.Generic;

namespace UCTS.Simulator
{
    public class ManagerOperations : IManagerOperations
    {
        readonly string _url;
        readonly string _sender;
        IFlurlRequest _caller => _url.WithHeader("sender", _sender);

        public ManagerOperations(string url, string sender)
        {
            _url = url;
            _sender = sender;
        }

        public async void NewCar(string car_type, string car_name) =>
            await _caller.PostJsonAsync(new { CarType = car_type, CarName = car_name });

        public async void RemoveCar(string car_name) =>
            await _caller.AppendPathSegment(car_name).DeleteAsync();

        public async Task<string> Report(string car_name)
        {
            dynamic output = await _caller.AppendPathSegment(car_name).GetStringAsync();
            return output;
            //return Results.Ok<string>(output);
        }

        public async void SetAttribute(string car_name, string attr, string value)
        {
            var expando = new ExpandoObject();
            var expandoDict = expando as IDictionary<string, object>;
            expandoDict.Add(attr, value);

            await _caller.AppendPathSegment(car_name).PatchJsonAsync(expando);
        }
    }

    public interface IManagerOperations
    {
        Task<string> Report(string car_name);
        void NewCar(string car_type, string car_name);
        void RemoveCar(string car_name);
        void SetAttribute(string car_name, string attr, string value);
    }
}
