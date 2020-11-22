using System.Text;
using System.Threading.Tasks;
using FurnaceAssistant.Core.Constants;
using FurnaceAssistant.Core.Sensors.Interfaces;

namespace FurnaceAssistant.Core.Sensors
{
    public class NetworkConnectionSensor : ISensor
    {
        private readonly ISensorConnection _connection;

        public NetworkConnectionSensor(ISensorConnection connection)
        {
            _connection = connection;
        }

        public async Task<SensorReading> ReadAsync()
        {
            var rawReading = await _connection.ReadAsync();

            return new SensorReading(
                content: IsValid(rawReading) 
                    ? "Ok!" 
                    : Encoding.ASCII.GetString(rawReading), 
                isValid: IsValid(rawReading));
        }

        private bool IsValid(byte[] bytes) =>
            GetString(bytes) != NetworkConnectionConstants.CONNECTION_FAILED_READING;

        private string GetString(byte[] bytes) => Encoding.ASCII.GetString(bytes);
    }
}