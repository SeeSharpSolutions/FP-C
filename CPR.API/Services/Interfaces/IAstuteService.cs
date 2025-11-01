using AstuteServiceReference;
using CPR.API.Models;

namespace CPR.API.Services.Interfaces
{
    public interface IAstuteService
    {
        Task<ProductSectorSet> GetProductSector();
        Task<ProductSet> GetProductSet(string sectorCode);
        Task<object> GetPortfolio(PortfolioPayload portfolioPayload);
    }
}