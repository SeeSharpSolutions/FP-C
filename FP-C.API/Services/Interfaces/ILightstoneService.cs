using FP_C.API.Models;
using FP_C.API.Models.DataEntities;

namespace FP_C.API.Services.Interfaces
{
    public interface ILightstoneService
    {
        Task<object> RetrievePropertyInfo(PortfolioPayload portfolio);
        Task<List<VehicleInfo>> RetrieveVehicleInfo(PortfolioPayload portfolio);
    }
}
