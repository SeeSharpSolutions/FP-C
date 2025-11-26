using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FP_C.API.Services
{
    public class LightstoneService : ILightstoneService
    {
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;

        public LightstoneService(IApiService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }

        public async Task<List<PropertyPayload>> RetrievePropertyInfo(PortfolioPayload portfolio)
        {
            //await _apiService.ExecuteAsync
            string baseUrl = _configuration.GetSection("Lightstone:property:baseUrl").Value.ToString();
            string method = _configuration.GetSection("Lightstone:property:getProperty").Value.ToString();
            method = method.Replace("{REPLACE}", "20");
            string key = _configuration.GetSection("Lightstone:PrimaryKey").Value.ToString();
            string url = $"{baseUrl}{method}";
            Dictionary<string, string> headers = [];
            headers.Add("Ocp-Apim-Subscription-Key", key);
            var result = await _apiService.GetAsync<List<PropertyPayload>>(url, headers);
            return result;
        }

        public async Task<List<VehicleInfo>> RetrieveVehicleInfo(PortfolioPayload portfolio)
        {
            List<VehicleInfo> result = new()
            {
                new()
                {
                    Name = "Chery",
                    Description = "Tiggo 4 Pro",
                    PurchaseDate = new DateTime(2022,2,2),
                    Value = "180000",
                    ValuePrev = "320000"
                },
                new()
                {
                    Name = "Toyota",
                    Description = "Yaris Spirit",
                    PurchaseDate = new DateTime(2009,6,20),
                    Value = "43250",
                    ValuePrev = "175000"
                }
            };
            return result;
        }
    }
}
