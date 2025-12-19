using AstuteServiceReference;
using FP_C.API.Common;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace FP_C.API.Services
{
    public class AstuteService : IAstuteService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<BrokerRequest> _brService;
        private readonly IRepository<PolicyInfo> _pService;
        private readonly IRepository<PropertyInfo> _prService;
        private readonly IRepository<VehicleInfo> _vService;
        private readonly ILightstoneService _lightstoneService;
        private readonly IRepository<Broker> _bService;
        private readonly string _username;
        private readonly string _password;
        private readonly string _defaultUserAgent;
        private readonly AstuteServiceV3Client _client;
        private readonly IServiceProvider _serviceProvider;
        private readonly IClientService _clientService;

        public AstuteService(IConfiguration configuration
            , IRepository<Broker> bService
            , IRepository<BrokerRequest> brService
            , IRepository<PolicyInfo> pService
            , IRepository<PropertyInfo> prService
            , IRepository<VehicleInfo> vService
            , ILightstoneService lightstoneService
            , IServiceProvider serviceProvider
            , IClientService clientService)
        {
            _configuration = configuration;
            _bService = bService;
            _brService = brService;
            _pService = pService;
            _prService = prService;
            _vService = vService;
            _lightstoneService = lightstoneService;
            _serviceProvider = serviceProvider;
            _clientService = clientService;
            var astuteSettings = _configuration.GetSection("Astute");
            _username = astuteSettings!["Username"];
            _password = astuteSettings!["Password"];
            _defaultUserAgent = astuteSettings!["UserAgent"];
            _client = new AstuteServiceV3Client();
            _client.ClientCredentials.UserName.UserName = _username;
            _client.ClientCredentials.UserName.Password = _password;
        }

        public async Task<Result<ICollection<PolicyInfo>>> GetPortfolio(string key, PortfolioPayload portfolioPayload)
        {
            Guid msgId = Guid.NewGuid();
            var item = portfolioPayload.GetPortfolio();

            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return Result<ICollection<PolicyInfo>>.Fail("Key cant be empty.");
            }
            var brokers = _bService.Find(x => x.ApiKey == key);
            if (brokers == null || !brokers.Any())
            {
                return Result<ICollection<PolicyInfo>>.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker

            #region CCPRequest

            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            // Change to intermediaterequest
            var result = await _client.PerformCcpRequestAsync(item, msgId, null);
            string message = result?.Result?.CompletionCode.ToString();
            #endregion CCPRequest

            #region CheckForPrevRequests
            var requests = _brService.Find(x => x.BrokerId == broker.Id && x.ClientInfoId == 0 && !x.IsConcluded);
            if (requests != null && requests.Any())
            {
                foreach (var req in requests)
                {
                    req.IsConcluded = true;
                    _brService.Update(req);
                }
            }

            #endregion CheckForPrevRequests

            #region CreateBrokerRequest

            BrokerRequest brokerRequest = new()
            {
                BrokerId = broker.Id,
                ClientInfoId = 0,
                DateCreated = DateTime.Now,
                Request = JsonConvert.SerializeObject(item),
                MessageId = msgId
            };
            await _brService.AddAsync(brokerRequest);
            await _brService.SaveChanges();

            #endregion CreateBrokerRequest

            return Result<ICollection<PolicyInfo>>.Ok(null);
        }

        public async Task<Result<ProductSectorSet>> GetProductSector(string key)
        {
            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return Result<ProductSectorSet>.Fail("Key cant be empty.");
            }
            var brokers = _bService.Find(x => x.ApiKey == key);
            if (brokers == null || !brokers.Any())
            {
                return Result<ProductSectorSet>.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker!.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetProductSectorSetAsync();
            return Result<ProductSectorSet>.Ok(result.Data);
        }

        public async Task<Result<ProductSet>> GetProductSet(string key, string sectorCode)
        {
            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return Result<ProductSet>.Fail("Key cant be empty.");
            }
            var brokers = _bService.Find(x => x.ApiKey == key);
            if (brokers == null || !brokers.Any())
            {
                return Result<ProductSet>.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetProductSetAsync(sectorCode);

            return Result<ProductSet>.Ok(result.Data);
        }

        public async Task<Result<MessageContent>> RetrievePortfolios(string key, Guid msgId)
        {
            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return Result<MessageContent>.Fail("Key cant be empty.");
            }
            var brokers = _bService.Find(x => x.ApiKey == key);
            if (brokers == null || !brokers.Any())
            {
                return Result<MessageContent>.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result2 = await _client.GetMessageContentAsync(msgId);
            return Result<MessageContent>.Ok(result2.Data);

        }

        public async Task RunRetrieval()
        {
            var openRequests = _brService.Find(x => !x.IsConcluded).ToList();
            List<PolicyInfo> clientPolicies = new();
            Broker broker = null;
            PolicyInfo policy = null;

            foreach (var req in openRequests)
            {
                broker = _bService.Find(x => x.Id == req.BrokerId).FirstOrDefault();
                var retrievalResult = await RetrievePortfolios(broker.ApiKey, req.MessageId);
                if (retrievalResult.IsSuccess)
                {
                    if (retrievalResult.Value.MessageHeader.TimestampCompleted != null)
                    {
                        req.IsConcluded = true;
                        _brService.Update(req);
                        clientPolicies = _pService.Find(x => x.ClientInfoId == req.ClientInfoId).ToList();
                        foreach (var item in retrievalResult.Value.MessageBody)
                        {
                            var descItem = MyCommon.ResultCodes.FirstOrDefault(x => x.Key == item.Value);
                            string descString = string.Empty;
                            if (descItem.Key != null && descItem.Value != null)
                            {
                                descString = $"{descItem.Key} - {descItem.Value}";
                            }
                            else descString = "N/A"; 
                            if(!clientPolicies.Any(x => x.Name == item.ProviderCode))
                            {                                
                                policy = new()
                                {
                                    ClientInfoId = req.ClientInfoId,
                                    Name = item.ProviderCode,
                                    Description = descItem.Value ?? string.Empty
                                };
                                await _pService.AddAsync(policy);
                            }
                            else if(clientPolicies.Any(x => x.Name == item.ProviderCode && x.Description != descString))
                            {
                                policy = clientPolicies.FirstOrDefault(x => x.Name == item.ProviderCode && x.Description != descString);
                                policy.Description = descString;
                                _pService.Update(policy);
                            }                            
                        }
                        await _brService.SaveChanges();
                        await _pService.SaveChanges();
                    }
                }
            }
        }
    }
}
