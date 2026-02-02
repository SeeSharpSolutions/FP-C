using FP_C.API.Common;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class PropertyController(IRepository<PropertyInfo> pService, IClientService cService, ILightstoneService lightstoneService) : ControllerBase
    {
        private readonly IRepository<PropertyInfo> _pService = pService;
        private readonly IClientService _cService = cService;
        private readonly ILightstoneService _lightstoneService = lightstoneService;

        [HttpGet("GetByClient/{idNumber}")]
        public async Task<Result<List<PropertyInfo>>> GetByClient(string idNumber)
        {
            var client = await _cService.GetClientById(idNumber);
            await _lightstoneService.UpdateProperties(idNumber);
            return Result<List<PropertyInfo>>.Ok((_pService.Find(x => x.ClientInfoId == client.id)).ToList());
        }

        [HttpGet("GetPropertyValue/{propertyId}")]
        public async Task<Result<PropertyInfo>> GetPropertyValue(string propertyId)
        {            
            return Result<PropertyInfo>.Ok((await _lightstoneService.RetrievePropertyValue(propertyId)));
        }

        [HttpGet("GetPropertyCurrentValue/{propertyId}")]
        public async Task<Result<PropertyInfo>> GetPropertyCurrentValue(string propertyId)
        {
            return Result<PropertyInfo>.Ok((await _lightstoneService.RetrieveCurrentPropertyValue(propertyId)));
        }
    }
}
