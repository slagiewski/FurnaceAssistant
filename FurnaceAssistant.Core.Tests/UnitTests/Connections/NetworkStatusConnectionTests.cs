using FurnaceAssistant.Core.Abstractions;
using FurnaceAssistant.Core.Connections;
using FurnaceAssistant.Core.Constants;
using Moq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FurnaceAssistant.Core
{
    public class NetworkStatusConnectionTests
    {
        private readonly Uri _uri = new Uri(@"https://www.google.com");

        [Fact]
        public async Task NetworkStatusConnectionWithoutClientShouldReturnError()
        {
            var clientMock = new Mock<INetworkClient>();
            var connection = new NetworkStatusConnection(clientMock.Object, _uri);

            Assert.False((await connection.ReadAsync()).IsValid);
        }

        [Fact]
        public async Task NetworkStatusConnectionShouldNotReturnErrorIfResponseOk()
        {
            var okResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var clientMock = new Mock<INetworkClient>();
            clientMock.Setup(x => x.GetAsync(_uri))
                .Returns(
                    Task.FromResult(okResponseMessage)
                    );
            var connection = new NetworkStatusConnection(clientMock.Object, _uri);

            var response = await connection.ReadAsync();

            Assert.True(response.IsValid);
            Assert.Empty(response.Errors);
        }

        [Fact]
        public async Task NetworkStatusConnectionShouldReturnErrorIfResponseNotOk()
        {
            var invalidResponseMessage = new HttpResponseMessage(
                HttpStatusCode.BadRequest);
            var clientMock = new Mock<INetworkClient>();
            clientMock.Setup(x => x.GetAsync(_uri))
                .Returns(
                    Task.FromResult(invalidResponseMessage)
                );
            var connection = new NetworkStatusConnection(clientMock.Object, _uri);

            var response = await connection.ReadAsync();

            Assert.False(response.IsValid);
            Assert.Contains(SensorConnectionConstants.CONNECTION_FAILED_READING, response.Errors.Select(r => r.Message));
        }
    }
}
