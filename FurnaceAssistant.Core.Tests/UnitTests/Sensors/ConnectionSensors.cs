using System.Text;
using System.Threading.Tasks;
using FurnaceAssistant.Core.Constants;
using FurnaceAssistant.Core.DataModels.Connection;
using FurnaceAssistant.Core.Sensors;
using Moq;
using Xunit;

namespace FurnaceAssistant.Core.Tests.UnitTests.Sensors
{
    public class ConnectionSensors
    {
        [Fact]
        public async Task SensorWithInvalidConnectionShouldReturnInvalidReading()
        {
            var networkConnectionMock = new Mock<ISensorConnection>();
            networkConnectionMock.Setup(connection => connection.ReadAsync())
                .ReturnsAsync(ConnectionResponse.Error(
                    new ResponseError(SensorConnectionConstants.CONNECTION_FAILED_READING)));
            var sensor = new ConnectionSensor(networkConnectionMock.Object);

            var reading = await sensor.ReadAsync();

            Assert.False(reading.IsValid);
        }

        [Fact]
        public async Task SensorWithValidConnectionShouldReturnValidReading()
        {
            var networkConnectionMock = new Mock<ISensorConnection>();
            networkConnectionMock.Setup(connection => connection.ReadAsync())
                .ReturnsAsync(ConnectionResponse.Valid("Message!"));
            var sensor = new ConnectionSensor(networkConnectionMock.Object);

            var reading = await sensor.ReadAsync();

            Assert.True(reading.IsValid);
        }
    }
}
