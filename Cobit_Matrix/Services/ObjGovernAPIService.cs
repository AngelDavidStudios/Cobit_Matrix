using Cobit_Matrix.Models;
using RestSharp;

namespace Cobit_Matrix.Services;

public class ObjGovernAPIService
{
    private readonly RestClient _client;

    public ObjGovernAPIService()
    {
        _client = new RestClient("http://localhost:5249/api/");
    }
    
    public async Task<IEnumerable<ObjetivosGobierno>> GetObjGovernAsync()
    {
        var request = new RestRequest("ObjeGovernment", Method.Get);
        var response = await _client.ExecuteAsync<List<ObjetivosGobierno>>(request);
        return response.Data;
    }
    
    public async Task<ObjetivosGobierno> GetObjGovernAsync(int id)
    {
        var request = new RestRequest($"ObjeGovernment/{id}", Method.Get);
        var response = await _client.ExecuteAsync<ObjetivosGobierno>(request);
        return response.Data;
    }
    
    public async Task<ObjetivosGobierno> CreateObjGovernAsync(ObjetivosGobierno objGovern)
    {
        var request = new RestRequest("ObjeGovernment", Method.Post);
        request.AddJsonBody(objGovern);
        var response = await _client.ExecuteAsync<ObjetivosGobierno>(request);
        return response.Data;
    }
    
    public async Task UpdateObjGovernAsync(int id, ObjetivosGobierno objGovern)
    {
        var request = new RestRequest($"ObjeGovernment/{id}", Method.Put);
        request.AddJsonBody(objGovern);
        await _client.ExecuteAsync(request);
    }
    
    public async Task DeleteObjGovernAsync(int id)
    {
        var request = new RestRequest($"ObjeGovernment/{id}", Method.Delete);
        await _client.ExecuteAsync(request);
    }
}