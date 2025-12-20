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
        private readonly IRepository<VehicleInfo> _vService;

        public LightstoneService(IApiService apiService, IConfiguration configuration, IClientService clientService, IRepository<PropertyInfo> prService, IRepository<VehicleInfo> vService)
        {
            _apiService = apiService;
            _configuration = configuration;
            _clientService = clientService;
            _prService = prService;
            _vService = vService;
        }

        public async Task UpdateProperties(string clientId, Customers? client = null)
        {
            client ??= await _clientService.GetClientById(clientId);
            var currentProperties = _prService.Find(x => x.ClientInfoId == client.id);
            // Retieve Property Data from lightstone
            var prop = await RetrievePropertyInfo(client.identityNumber);
            if (prop != null)
            {
                foreach (var obj in prop.results)
                {
                    PropertyInfo pi = new()
                    {
                        Name = obj.propertyId,
                        Description = obj.address,
                        ClientInfoId = client.id
                    };
                    if (!currentProperties.Any(x => x.Name == pi.Name))
                    {
                        await _prService.AddAsync(pi);
                    }
                }
            }
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

        public async Task<PropertyInfo> RetrievePropertyValue(string propertyId)
        {
            var property = _prService.Find(x => x.Name == propertyId).FirstOrDefault();
            if (!string.IsNullOrEmpty(property.Value))
            {
                return property;
            }
            //await _apiService.ExecuteAsync
            string baseUrl = _configuration.GetSection("Lightstone:property:baseUrl").Value.ToString();
            string method = _configuration.GetSection("Lightstone:property:getPropertyValue").Value.ToString();
            method = method.Replace("{REPLACE}", propertyId);

            string key = _configuration.GetSection("Lightstone:PrimaryKey").Value.ToString();
            Dictionary<string, string> headers = [];
            headers.Add("Ocp-Apim-Subscription-Key", key);
            //   MakeRequest(b);
            var result = await _apiService.GetAsync<dynamic>($"{baseUrl}/{method}", headers);
            foreach (var item in result)
            {
                //"purchaseDate": "purchasePrice": 
                property.Value = item.purchasePrice;
                property.PurchaseDate = item.purchaseDate;
                break;
            }
            _prService.Update(property);
            await _prService.SaveChanges();
            return property;
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

        public async Task<VehicleInfo> RetrieveVehicleInfo(string idnumber, string vinNumber, bool force = false)
        {
            var client = await _clientService.GetClientById(idnumber);
            var existingVeh = _vService.Find(x => x.Name == vinNumber && x.ClientInfoId == client.id);
            if (existingVeh != null && existingVeh.Count() > 0 && !force)
            {
                return existingVeh.FirstOrDefault();
            }

            // get token
            string tokenUrl = _configuration.GetSection("Lightstone:Vehicle:tokenUrl").Value;
            string getVehicleUrl = _configuration.GetSection("Lightstone:Vehicle:getVehicleUrl").Value;
            string toGetToken = _configuration.GetSection("Lightstone:Vehicle:toGetToken").Value;

            Dictionary<string, string> headers = [];
            headers.Add("Authorization", "Basic cmFqZXNocGF0Y2hhbGFAZ21haWwuY29tOkxpZ2h0JHRvbmUxMjM0JA==");
            var token = await _apiService.PostAsync<MyToken>(tokenUrl, null, headers);
            // get vehicle
            var obj = new
            {
                ClientPackageId = "1639fde6-03f7-4c65-99f3-aa67868ae02f",
                VinNumber = vinNumber
            };
            Dictionary<string, string> headers2 = [];
            
            headers2.Add("Authorization", $"Bearer {token.Token}");
            var result = await _apiService.PostAsync<dynamic>(getVehicleUrl, obj, headers2);
            string str = JsonConvert.SerializeObject(result);
            VehicleInfo vi = new()
            {
                Name = vinNumber,
                ClientInfoId = client.id
            };
            foreach(var item in result)
            {
                if (item.Category == "General" && item.Description == "Full Model Description")
                {
                    vi.Description = item.Value;
                }
                if(item.EstimateType == "Trade" && item.Category == "Valuation" && item.Description == "Trade Estimate")
                {
                    vi.Value = item.Value;
                }
            }
            if(vi.Value != null)
            {
                await _vService.AddAsync(vi);
                await _vService.SaveChanges();
            }
            return vi;
        }
    }
}
