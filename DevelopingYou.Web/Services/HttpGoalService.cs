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

        //add http--service
        public async Task<List<Goal>> GetGoals()
        {
            var responseStream = await client.GetStreamAsync("Goals");

            List<Goal> result = await JsonSerializer.DeserializeAsync<List<Goal>>(responseStream);

            return result;
        }
    }
}
