using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FurnaceAssistant.Core.Abstractions;
using FurnaceAssistant.Core.Connections;
using FurnaceAssistant.Core.Constants;
using Moq;
using Xunit;

namespace FurnaceAssistant.Core
{
    public class HttpNetworkClientTests
    {
        [Fact]
        public async Task HttpNetworkClientShouldReturnSameResultsAsHttpClient()
        {
            var uri = new Uri(@"https://jsonplaceholder.typicode.com/todos/1");

            var httpClient = new HttpClient();
            var httpNetworkClient = new HttpNetworkClient(httpClient);

            var expectedResponse = await httpClient.GetAsync(uri);
            var actualResponse = await httpNetworkClient.GetAsync(uri);

            Assert.Equal(expectedResponse.StatusCode, actualResponse.StatusCode);
            Assert.NotNull(expectedResponse.Content);
            Assert.NotNull(actualResponse.Content);
            Assert.Equal(
                expectedResponse.Content?.ReadAsStringAsync().GetAwaiter().GetResult(),
                actualResponse.Content?.ReadAsStringAsync().GetAwaiter().GetResult());
        }
    }
}
