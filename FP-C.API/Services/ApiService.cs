using FP_C.API.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text;
using System.Text.Json;

namespace FP_C.API.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            return await SendAsync<T>(HttpMethod.Get, url, null, headers);
        }

        public async Task<T?> PostAsync<T>(string url, object? body = null, Dictionary<string, string>? headers = null)
        {
            return await SendAsync<T>(HttpMethod.Post, url, body, headers);
        }

        public async Task<T?> PutAsync<T>(string url, object? body = null, Dictionary<string, string>? headers = null)
        {
            return await SendAsync<T>(HttpMethod.Put, url, body, headers);
        }

        public async Task<T?> DeleteAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            return await SendAsync<T>(HttpMethod.Delete, url, null, headers);
        }

        private async Task<T?> SendAsync<T>(HttpMethod method, string url, object? body, Dictionary<string, string>? headers)
        {
            using var request = new HttpRequestMessage(method, url);

            if (headers != null)
            {
                foreach (var header in headers)
                    request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            if (body != null)
            {
                var json = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"Request failed ({response.StatusCode}): {errorText}");
            }

            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(content))
                return default;

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
