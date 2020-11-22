using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FurnaceAssistant.Core.Abstractions
{
    public class HttpNetworkClient : INetworkClient
    {
        private readonly HttpClient _client;

        public HttpNetworkClient(HttpClient client)
        {
            _client = client;
        }

        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return _client.GetAsync(uri);
        }
    }
}