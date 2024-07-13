using RestSharp;
using Cobit_Matrix.Models;

namespace Cobit_Matrix.Services
{
    public class GoalAlignAPIService
    {
        private readonly RestClient _client;

        public GoalAlignAPIService()
        {
            _client = new RestClient("http://localhost:5249/api/");
        }

        public async Task<IEnumerable<MetaAlineamiento>> GetGoalAlignmentsAsync()
        {
            var request = new RestRequest("GoalAlignment", Method.Get);
            var response = await _client.ExecuteAsync<List<MetaAlineamiento>>(request);
            return response.Data;
        }

        public async Task<MetaAlineamiento> GetGoalAlignmentAsync(int id)
        {
            var request = new RestRequest($"GoalAlignment/{id}", Method.Get);
            var response = await _client.ExecuteAsync<MetaAlineamiento>(request);
            return response.Data;
        }

        public async Task<MetaAlineamiento> CreateGoalAlignmentAsync(MetaAlineamiento goalAlignment)
        {
            var request = new RestRequest("GoalAlignment", Method.Post);
            request.AddJsonBody(goalAlignment);
            var response = await _client.ExecuteAsync<MetaAlineamiento>(request);
            return response.Data;
        }

        public async Task UpdateGoalAlignmentAsync(int id, MetaAlineamiento goalAlignment)
        {
            var request = new RestRequest($"GoalAlignment/{id}", Method.Put);
            request.AddJsonBody(goalAlignment);
            await _client.ExecuteAsync(request);
        }

        public async Task DeleteGoalAlignmentAsync(int id)
        {
            var request = new RestRequest($"GoalAlignment/{id}", Method.Delete);
            await _client.ExecuteAsync(request);
        }
    }
}