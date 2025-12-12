using FP_C.API.Models;
using FP_C.API.Models.DataEntities;

namespace FP_C.API.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientInfo> GetClientById(int id);
        Task<ClientInfo> CreateGetClient(PortfolioPayload portfolioPayload);
        Task UpdateClient(ClientInfo clientInfo);
        Task AddClientVehicle(VehicleInfo vehicleInfo);
        Task RemoveClientVehicle(VehicleInfo vehicleInfo);
    }
}
