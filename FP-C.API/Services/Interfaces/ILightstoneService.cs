using FP_C.API.Models;
using FP_C.API.Models.DataEntities;

namespace FP_C.API.Services.Interfaces
{
    public interface ILightstoneService
    {
        Task UpdateProperties(string idNumer, Customers? client = null);
        Task<dynamic> RetrievePropertyInfo(string idNumber);
        Task<PropertyInfo> RetrievePropertyValue(string propertyId);
        Task<VehicleInfo> RetrieveVehicleInfo(string idNumber, string vinNumber, bool force = false);
    }
}
