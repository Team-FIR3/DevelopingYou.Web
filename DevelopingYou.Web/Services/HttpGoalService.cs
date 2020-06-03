using DevelopingYou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public class HttpGoalService : IGoalService
    {
        //add private readonly httpclient
        private readonly HttpClient client;

        public HttpGoalService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Goal>> GetGoals()
        {
            var responseStream = await client.GetStreamAsync("Goals");

            List<Goal> result = await JsonSerializer.DeserializeAsync<List<Goal>>(responseStream);

            return result;
        }

        public async Task<Goal> CreateGoal(Goal goal)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(goal), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("Goals", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    Goal result = await JsonSerializer.DeserializeAsync<Goal>(responseStream);
                    return result;
                }

                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to POST data: ({response.StatusCode})");
            }
        }

        public async Task<Goal> GetOneGoal(int id)
        {
            var responseStream = await client.GetStreamAsync($"Goals/{id}");

            Goal result = await JsonSerializer.DeserializeAsync<Goal>(responseStream);

            return result;
        }
    }
}
