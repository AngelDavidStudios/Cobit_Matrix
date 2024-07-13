using Cobit_Matrix.Models;
using RestSharp;

namespace Cobit_Matrix.Services;

public class GoalBusinessAPIService
{
    private readonly RestClient _client;

    public GoalBusinessAPIService()
    {
        _client = new RestClient("http://localhost:5249/api/");
    }

    public async Task<IEnumerable<MetaEmpresarial>> GetGoalBusinessesAsync()
    {
        var request = new RestRequest("GoalBusiness", Method.Get);
        var response = await _client.ExecuteAsync<List<MetaEmpresarial>>(request);
        return response.Data;
    }

    public async Task<MetaEmpresarial> GetGoalBusinessAsync(int id)
    {
        var request = new RestRequest($"GoalBusiness/{id}", Method.Get);
        var response = await _client.ExecuteAsync<MetaEmpresarial>(request);
        return response.Data;
    }

    public async Task<MetaEmpresarial> CreateGoalBusinessAsync(MetaEmpresarial goalBusiness)
    {
        var request = new RestRequest("GoalBusiness", Method.Post);
        request.AddJsonBody(goalBusiness);
        var response = await _client.ExecuteAsync<MetaEmpresarial>(request);
        return response.Data;
    }

    public async Task UpdateGoalBusinessAsync(int id, MetaEmpresarial goalBusiness)
    {
        var request = new RestRequest($"GoalBusiness/{id}", Method.Put);
        request.AddJsonBody(goalBusiness);
        await _client.ExecuteAsync(request);
    }

    public async Task DeleteGoalBusinessAsync(int id)
    {
        var request = new RestRequest($"GoalBusiness/{id}", Method.Delete);
        await _client.ExecuteAsync(request);
    }
}