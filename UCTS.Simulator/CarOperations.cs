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
    public class CarOperations : ICarOperations
    {
        string _url;
        public CarOperations(string url)
        {
            _url = url;
        }

        public async void NewCarAsync(string car_type, string car_name) =>
            await _url.PostJsonAsync(new { CarType = car_type, CarName = car_name });


        public async void RemoveCarAsync(string car_name) =>
            await _url.AppendPathSegment(car_name).DeleteAsync();

        public async Task<string> ReportAsync(string car_name)
        {
            dynamic output = await _url.AppendPathSegment(car_name).GetJsonAsync();
            return JsonConvert.SerializeObject(output);
            //return Results.Ok<string>(output);
        }

        public async void SetAsync(string car_name, string attr, string value)
        {
            var expando = new ExpandoObject();
            var expandoDict = expando as IDictionary<string, object>;
            expandoDict.Add(attr, value);

            await _url.AppendPathSegment(car_name).PatchJsonAsync(expando);
        }
    }

    public interface ICarOperations
    {
        Task<string> ReportAsync(string car_name);
        void NewCarAsync(string car_type, string car_name);
        void RemoveCarAsync(string car_name);
        void SetAsync(string car_name, string attr, string value);
    }
}
