using FP_C.API.Common;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services;
using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpGet("GetClientByIdNumber/{idNumber}")]
        public async Task<Result<Customers>> GetClientByIdNumber(string idNumber)
        {
            
            var clients = await _clientService.GetClientById(idNumber);
            return Result<Customers>.Ok(clients);
        }
    }
}
