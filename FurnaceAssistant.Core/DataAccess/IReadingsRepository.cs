using System.Threading.Tasks;
using FurnaceAssistant.Core.DataModels;
using FurnaceAssistant.Core.DataModels.Sensor;

namespace FurnaceAssistant.Core.DataAccess
{
    public interface IReadingsRepository
    {
        Task SaveReadingAsync(SensorReading isAny);
    }
}