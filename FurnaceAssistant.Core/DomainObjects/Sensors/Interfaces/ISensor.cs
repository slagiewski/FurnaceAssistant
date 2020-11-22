using System.Threading.Tasks;

namespace FurnaceAssistant.Core.Sensors.Interfaces
{
    public interface ISensor
    {
        Task<SensorReading> ReadAsync();
    }
}