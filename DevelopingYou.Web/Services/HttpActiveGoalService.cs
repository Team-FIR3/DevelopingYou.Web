using DevelopingYou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public class HttpActiveGoalService : IActiveGoal
    {
        //add private readonly httpclient
        private readonly HttpClient client;

        public HttpActiveGoalService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<IEnumerable<Goal>> GetActiveGoals()
        {
            var responseStream = await client.GetStreamAsync("Goals/Active");

            List<Goal> result = await JsonSerializer.DeserializeAsync<List<Goal>>(responseStream);

            return result;
        }
    }
}
