using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnaceAssistant.Core.DataModels.Sensor;
using FurnaceAssistant.Core.Sensors.Interfaces;

namespace FurnaceAssistant.Core.Sensors
{
    public class ConnectionSensor : ISensor
    {
        private readonly ISensorConnection _connection;

        public ConnectionSensor(ISensorConnection connection)
        {
            _connection = connection;
        }

        public async Task<SensorReading> ReadAsync()
        {
            var connectionResponse = await _connection.ReadAsync();

            return connectionResponse.IsValid
                ? SensorReading.Valid("Ok!")
                : SensorReading.Error(
                    connectionResponse.Errors
                        .Select(e => new ResponseError(e.Message))
                        .ToArray());
        }
    }
}