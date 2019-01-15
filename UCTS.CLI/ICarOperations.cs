using System;
using System.Threading.Tasks;

namespace UCTS.CLI
{
    public interface ICarOperations
    {
        Task<string> ReportAsync(string car_name);
        void NewCarAsync(string car_type, string car_name);
        void RemoveCarAsync(string car_name);
        void SetAsync(string car_name, string attr, string value);
    }

    public interface IGetOperations
    {
        ICarOperations Operations { get; }
    }
}
