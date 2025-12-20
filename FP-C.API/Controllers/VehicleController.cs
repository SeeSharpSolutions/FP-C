using FP_C.API.Common;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class VehicleController(ILightstoneService lightstoneService) : ControllerBase
    {
        private readonly ILightstoneService _lightstoneService = lightstoneService;

        [HttpGet("GetByVinNumber/{idNumber}/{vinNumber}")]
        public async Task<Result<VehicleInfo>> GetByVinNumber(string idNumber, string vinNumber)
        {
            var result = await _lightstoneService.RetrieveVehicleInfo(idNumber, vinNumber);
            return Result<VehicleInfo>.Ok(result);
        }

        [HttpGet("ForceGetByVinNumber/{idNumber}/{vinNumber}")]
        public async Task<Result<VehicleInfo>> ForceGetByVinNumber(string idNumber, string vinNumber)
        {
            var result = await _lightstoneService.RetrieveVehicleInfo(idNumber, vinNumber);
            return Result<VehicleInfo>.Ok(result);
        }
    }
}
