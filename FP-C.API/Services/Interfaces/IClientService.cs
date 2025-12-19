using FP_C.API.Models;
using FP_C.API.Models.DataEntities;

namespace FP_C.API.Services.Interfaces
{
    public interface IClientService
    {
        Task<Customers> GetClientById(string id);
        Task<Customers> CreateGetClient(PortfolioPayload portfolioPayload);
        Task AddClientVehicle(VehicleInfo vehicleInfo);
        Task RemoveClientVehicle(VehicleInfo vehicleInfo);
    }
}
