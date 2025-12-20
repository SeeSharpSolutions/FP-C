using FP_C.API.Common;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;

namespace FP_C.API.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Customers> _cService;
        private readonly IRepository<VehicleInfo> _vService;

        public ClientService(IRepository<Customers> cService, IRepository<VehicleInfo> vService) 
        {
            _cService = cService;
            _vService = vService;
        }

        public async Task AddClientVehicle(VehicleInfo vehicleInfo)
        {
            await _vService.AddAsync(vehicleInfo);
            await _vService.SaveChanges();
        }

        public async Task<Customers> GetClientById(string id)
        {
            var clients = _cService.Find(x => x.identityNumber == id);
            var client = clients != null ? clients.FirstOrDefault() : new();
            return client!;
        }
    }
}
