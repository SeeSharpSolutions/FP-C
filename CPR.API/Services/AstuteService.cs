using AstuteServiceReference;
using CPR.API.Common;
using CPR.API.Models;
using CPR.API.Services.Interfaces;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CPR.API.Services
{
    public class AstuteService : IAstuteService
    {
        private readonly IConfiguration _configuration;
        private readonly string _username;
        private readonly string _password;
        private readonly string _userAgent;
        private readonly AstuteServiceV3Client _client;

        public AstuteService(IConfiguration configuration)
        {
            _configuration = configuration;
            var astuteSettings = _configuration.GetSection("Astute");
            _username = astuteSettings!["Username"];
            _password = astuteSettings!["Password"];
            _userAgent = astuteSettings!["UserAgent"];
            _client = new AstuteServiceV3Client();
            _client.ClientCredentials.UserName.UserName = _username;
            _client.ClientCredentials.UserName.Password = _password;
        }

        public async Task<object> GetPortfolio(PortfolioPayload portfolioPayload)
        {
            Guid msgId = Guid.NewGuid();
            var item = portfolioPayload.GetPortfolio();
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, _userAgent);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.PerformCcpRequestAsync(item, msgId, null);
            await GetHeaders(msgId);
            return result;
        }

        public async Task<ProductSectorSet> GetProductSector()
        {
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, _userAgent);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetProductSectorSetAsync();
            return result.Data;
        }

        public async Task<ProductSet> GetProductSet(string sectorCode)
        {
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, _userAgent);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetProductSetAsync(sectorCode);
            return result.Data;
        }

        public async Task GetHeaders(Guid msgId)
        {
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, _userAgent);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetMessageHeaderAsync(msgId);
        }
    }
}
