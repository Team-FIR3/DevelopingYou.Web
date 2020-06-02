using DevelopingYou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public class HttpInstanceService : IInstanceService
    {
        //add private readonly httpclient

        //add http--service
        private readonly HttpClient client;


        public HttpInstanceService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Instance> Create(Instance instance)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(instance), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("Instances", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    Instance result = await JsonSerializer.DeserializeAsync<Instance>(responseStream);
                    return result;
                }
                throw new Exception($"Failed to POST data: ({response.StatusCode})");
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Instance> Edit(int id, Instance instance)
        {
            throw new NotImplementedException();
        }

        public async Task<Instance> GetInstanceById(int id)
        {

            var responseStream = await client.GetStreamAsync($"Instances/{id}");
            Instance result = await JsonSerializer.DeserializeAsync<Instance>(responseStream);
            return result;
        }

        public async Task<Instance> GetInstances()
        {
            //May need list of instances 
            var responseStream = await client.GetStreamAsync("Instances");
            Instance result = await JsonSerializer.DeserializeAsync<Instance>(responseStream);
            return result;
        }
    }
}
