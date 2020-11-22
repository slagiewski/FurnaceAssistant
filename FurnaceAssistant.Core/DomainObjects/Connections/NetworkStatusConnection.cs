using System;
using System.Text;
using System.Threading.Tasks;
using FurnaceAssistant.Core.Abstractions;
using FurnaceAssistant.Core.Constants;

namespace FurnaceAssistant.Core.Connections
{
    public class NetworkStatusConnection : ISensorConnection
    {
        private readonly INetworkClient _client;
        private readonly Uri _uriToCheck;

        public NetworkStatusConnection(INetworkClient client, Uri uriToCheck)
        {
            _client = client;
            _uriToCheck = uriToCheck;
        }

        public async Task<byte[]> ReadAsync()
        {
            var result = await _client.GetAsync(_uriToCheck);

            if (result is null)
            {
                throw new Exception($"{nameof(NetworkStatusConnection)}: result was null!");
            }

            if (!result.IsSuccessStatusCode)
            {
                return Encoding.ASCII.GetBytes(NetworkConnectionConstants.CONNECTION_FAILED_READING);
            }

            if (result.Content is null)
            {
                return Array.Empty<byte>();
            }

            return await result.Content?.ReadAsByteArrayAsync();
        }
    }
}