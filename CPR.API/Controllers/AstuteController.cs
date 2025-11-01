using AstuteServiceReference;
using CPR.API.Common;
using CPR.API.Models;
using CPR.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class AstuteController : ControllerBase
    {
        private readonly IAstuteService _AstuteService;

        public AstuteController(IAstuteService astuteService)
        {
            _AstuteService = astuteService;
        }

        [HttpGet("GetProductSector")]
        public async Task<Result<ProductSectorSet>> GetProductSector()
        {
            return Result<ProductSectorSet>.Ok(await _AstuteService.GetProductSector());
        }

        [HttpGet("GetProductSet/{sectorCode}")]
        public async Task<Result<ProductSet>> GetProductSet(string sectorCode)
        {
            return Result<ProductSet>.Ok(await _AstuteService.GetProductSet(sectorCode));
        }

        [HttpPost("GetPortfolio")]
        public async Task<Result<object>> GetProductSet([FromBody] PortfolioPayload payload)
        {
            return Result<object>.Ok(await _AstuteService.GetPortfolio(payload));
        }
    }
}
