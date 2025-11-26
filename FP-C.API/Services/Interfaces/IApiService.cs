namespace FP_C.API.Services.Interfaces
{
    public interface IApiService
    {
        Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers = null);
        Task<T?> PostAsync<T>(string url, object? body = null, Dictionary<string, string>? headers = null);
        Task<T?> PutAsync<T>(string url, object? body = null, Dictionary<string, string>? headers = null);
        Task<T?> DeleteAsync<T>(string url, Dictionary<string, string>? headers = null);
    }
}
