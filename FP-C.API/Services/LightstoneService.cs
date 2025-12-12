using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http.Headers;
using RestSharp;
using FP_C.API.Models.Lightstone;
using FP_C.API.Data.Interfaces;

namespace FP_C.API.Services
{
    public class LightstoneService : ILightstoneService
    {
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;
        private readonly IRepository<PropertyInfo> _prService;

        public LightstoneService(IApiService apiService, IConfiguration configuration, IClientService clientService, IRepository<PropertyInfo> prService)
        {
            _apiService = apiService;
            _configuration = configuration;
            _clientService = clientService;
            _prService = prService;
        }

        public async Task UpdateProperties(int clientId, ClientInfo? client = null)
        {
            client ??= await _clientService.GetClientById(clientId);
            var currentProperties = _prService.Find(x => x.ClientInfoId == client.Id);
            // Retieve Property Data from lightstone
            var prop = await RetrievePropertyInfo(client.IdNumber);
            if (prop != null)
            {
                foreach (var obj in prop.results)
                {
                    PropertyInfo pi = new()
                    {
                        Name = obj.propertyId,
                        Description = obj.address,
                        ClientInfoId = client.Id,
                        ClientInfo = client
                    };
                    if(!currentProperties.Any(x => x.Name == pi.Name))
                    {
                        await _prService.AddAsync(pi);
                    }
                }
            }
            client.LastPropertyCheck = DateTime.Now;
            await _clientService.UpdateClient(client);
            await _prService.SaveChanges();
        }

        public async Task<dynamic> RetrievePropertyInfo(string idNumber)
        {
            //await _apiService.ExecuteAsync
            string baseUrl = _configuration.GetSection("Lightstone:property:baseUrl").Value.ToString();
            string method = _configuration.GetSection("Lightstone:property:getProperty").Value.ToString();
            
            string key = _configuration.GetSection("Lightstone:PrimaryKey").Value.ToString();
            var body = new
            {
                maxRowsToReturn = 10,
                ownerIdentifier = idNumber
            };
            Dictionary<string, string> headers = [];
            headers.Add("Ocp-Apim-Subscription-Key", key);
            //   MakeRequest(b);
            var result = await _apiService.PostAsync<dynamic>($"{baseUrl}/{method}", body, headers);
            return result;
        }

        public async Task<dynamic> RetrievePropertyValue(string propertyId)
        {
            //await _apiService.ExecuteAsync
            string baseUrl = _configuration.GetSection("Lightstone:property:baseUrl").Value.ToString();
            string method = _configuration.GetSection("Lightstone:property:getPropertyValue").Value.ToString();
            method = method.Replace("{REPLACE}", propertyId);

            string key = _configuration.GetSection("Lightstone:PrimaryKey").Value.ToString();
            Dictionary<string, string> headers = [];
            headers.Add("Ocp-Apim-Subscription-Key", key);
            //   MakeRequest(b);
            var result = await _apiService.GetAsync<dynamic>($"{baseUrl}/{method}", headers);
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
