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

        public async Task<object> RetrievePropertyInfo(PortfolioPayload portfolio)
        {
            //await _apiService.ExecuteAsync
            string baseUrl = _configuration.GetSection("Lightstone:property:baseUrl").Value.ToString();
            string method = _configuration.GetSection("Lightstone:property:getProperty").Value.ToString();
            string key = _configuration.GetSection("Lightstone:PrimaryKey").Value.ToString();
            string url = $"{baseUrl}{method}";
            var body = new
            {
                maxRowsToReturn = 10,
                ownerIdentifier = portfolio.IdNumber
            };
            Dictionary<string, string> headers = [];
            headers.Add("Ocp-Apim-Subscription-Key", key);
            var result = await _apiService.PostAsync<object>(url, body, headers);
            return result;
        }

//        {
//    "maxRowsToReturn": 0,
//    "propertyType": "string",
//    "streetNumber": "string",
//    "streetName": "string",
//    "streetType": "string",
//    "estateName": "string",
//    "suburb": "string",
//    "town": "string",
//    "deedTown": "string",
//    "municipality": "string",
//    "districtCouncil": "string",
//    "province": "string",
//    "postCode": "string",
//    "deedsOfficeCode": "string",
//    "township": "string",
//    "erfNumber": 0,
//    "portionNumber": 0,
//    "sectionalSchemeName": "string",
//    "sectionalSchemeYear": 0,
//    "sectionalSchemeNumber": 0,
//    "sectionalSchemeUnitNumber": 0,
//    "registrationDivision": "string",
//    "farmNumber": 0,
//    "farmName": "string",
//    "holdingNumber": 0,
//    "holdingName": "string",
//    "ownerName": "string",
//    "ownerIdentifier": "string",
//    "titleDeedNumber": "string",
//    "bondNumber": "string",
//    "rooftopCoordinatesLongitudeX": 0,
//    "rooftopCoordinatesLatitudeY": 0,
//    "radius": 0,
//    "discardNonUnique": true,
//    "highlights": true,
//    "explain": true,
//    "topLeftLat": 0,
//    "topLeftLong": 0,
//    "bottomRightLat": 0,
//    "bottomRightLong": 0
//}

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
