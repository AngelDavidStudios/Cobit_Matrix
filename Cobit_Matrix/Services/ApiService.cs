using RestSharp;

namespace Cobit_Matrix.Services;

public class ApiService<T> where T : class
{
    private readonly RestClient _client;

    public ApiService(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<IEnumerable<T>> GetAllAsync(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync<List<T>>(request);
        return response.Data;
    }

    public async Task<T> GetAsync(string endpoint, int id)
    {
        var request = new RestRequest($"{endpoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync<T>(request);
        return response.Data;
    }

    public async Task<T> CreateAsync(string endpoint, T entity)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(entity);
        var response = await _client.ExecuteAsync<T>(request);
        return response.Data;
    }

    public async Task UpdateAsync(string endpoint, int id, T entity)
    {
        var request = new RestRequest($"{endpoint}/{id}", Method.Put);
        request.AddJsonBody(entity);
        await _client.ExecuteAsync(request);
    }

    public async Task DeleteAsync(string endpoint, int id)
    {
        var request = new RestRequest($"{endpoint}/{id}", Method.Delete);
        await _client.ExecuteAsync(request);
    }
}