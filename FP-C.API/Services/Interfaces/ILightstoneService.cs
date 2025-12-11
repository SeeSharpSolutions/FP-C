using FP_C.API.Models;
using FP_C.API.Models.DataEntities;

namespace FP_C.API.Services.Interfaces
{
    public interface ILightstoneService
    {
        Task<dynamic> RetrievePropertyInfo(PortfolioPayload portfolio);
        Task<dynamic> RetrievePropertyValue(string propertyId);
        Task<List<VehicleInfo>> RetrieveVehicleInfo(PortfolioPayload portfolio);
    }
}
