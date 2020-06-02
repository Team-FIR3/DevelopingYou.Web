using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
