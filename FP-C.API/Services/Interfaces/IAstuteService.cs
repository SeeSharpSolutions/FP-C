using AstuteServiceReference;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;

namespace FP_C.API.Services.Interfaces
{
    public interface IAstuteService
    {
        Task<Result<ProductSectorSet>> GetProductSector(string key);
        Task<Result<ProductSet>> GetProductSet(string key, string sectorCode);
        Task<Result<ClientInfo>> GetPortfolio(string key, PortfolioPayload portfolioPayload);
        Task<Result<MessageContent>> RetrievePortfolios(string key, Guid msgId);
        Task RunRetrieval();
    }
}