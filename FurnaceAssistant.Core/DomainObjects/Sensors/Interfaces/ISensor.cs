using System.Threading.Tasks;
using FurnaceAssistant.Core.DataModels;
using FurnaceAssistant.Core.DataModels.Sensor;

namespace FurnaceAssistant.Core.Sensors.Interfaces
{
    public interface ISensor
    {
        Task<SensorReading> ReadAsync();
    }
}