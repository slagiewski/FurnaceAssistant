using System;
using System.Text;
using System.Threading.Tasks;
using FurnaceAssistant.Core.Abstractions;
using FurnaceAssistant.Core.Constants;
using FurnaceAssistant.Core.DataModels;
using FurnaceAssistant.Core.DataModels.Connection;

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

        public async Task<ConnectionResponse> ReadAsync()
        {
            var result = await _client.GetAsync(_uriToCheck);

            if (result is null)
            {
                return ConnectionResponse.Error(
                    new ResponseError($"{nameof(NetworkStatusConnection)}: result was null!"));
            }

            if (!result.IsSuccessStatusCode)
            {
                return ConnectionResponse.Error(
                    new ResponseError(SensorConnectionConstants.CONNECTION_FAILED_READING));
            }

            if (result.Content is null)
            {
                return ConnectionResponse.Valid(string.Empty);
            }

            var content = await result.Content?.ReadAsByteArrayAsync();

            return ConnectionResponse.Valid(Encoding.ASCII.GetString(content), content) ;
        }
    }
}