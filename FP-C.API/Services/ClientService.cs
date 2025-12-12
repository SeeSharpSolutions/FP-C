using FP_C.API.Common;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;

namespace FP_C.API.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<ClientInfo> _cService;
        private readonly IRepository<VehicleInfo> _vService;

        public ClientService(IRepository<ClientInfo> cService, IRepository<VehicleInfo> vService) 
        {
            _cService = cService;
            _vService = vService;
        }

        public async Task AddClientVehicle(VehicleInfo vehicleInfo)
        {
            vehicleInfo.ClientInfo = await GetClientById(vehicleInfo.ClientInfoId);
            await _vService.AddAsync(vehicleInfo);
            await _vService.SaveChanges();
        }

        public async Task<ClientInfo> CreateGetClient(PortfolioPayload portfolioPayload)
        {
            var clients = _cService.Find(x => x.IdNumber == portfolioPayload.IdNumber);
            ClientInfo client = null;
            if (clients == null || !clients.Any())
            {
                client = portfolioPayload.ToClient();
                await _cService.AddAsync(client);
                await _cService.SaveChanges();
                clients = _cService.Find(x => x.IdNumber == portfolioPayload.IdNumber);
            }
            client = clients != null ? clients.FirstOrDefault() : new();
            return client!;
        }

        public async Task<ClientInfo> GetClientById(int id)
        {
            return await _cService.GetByIdAsync(id);
        }

        public async Task RemoveClientVehicle(VehicleInfo vehicleInfo)
        {
            _vService.Remove(vehicleInfo);
            await _vService.SaveChanges();
        }

        public async Task UpdateClient(ClientInfo clientInfo)
        {
            _cService.Update(clientInfo);
            await _cService.SaveChanges();
        }
    }
}
