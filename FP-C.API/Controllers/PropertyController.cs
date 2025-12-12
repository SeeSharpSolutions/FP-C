using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController(IRepository<PropertyInfo> pService, ILightstoneService lightstoneService) : ControllerBase
    {
        private readonly IRepository<PropertyInfo> _pService = pService;
        private readonly ILightstoneService _lightstoneService = lightstoneService;

        [HttpGet("GetByClient/{clientId}")]
        public async Task<Result<List<PropertyInfo>>> GetByClient(int clientId)
        {
            await _lightstoneService.UpdateProperties(clientId);
            return Result<List<PropertyInfo>>.Ok((_pService.Find(x => x.ClientInfoId == clientId)).ToList());
        }

        [HttpGet("GetPropertyValue/{propertyId}")]
        public async Task<Result<object>> GetPropertyValue(string propertyId)
        {            
            return Result<object>.Ok((_lightstoneService.RetrievePropertyValue(propertyId)));
        }
    }
}
