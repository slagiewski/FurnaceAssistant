using System.Threading.Tasks;
using FurnaceAssistant.Core;

namespace FurnaceAssistant.DataAccess.Repositories
{
    public class ReadingsRepository : Core.DataAccess.IReadingsRepository
    {
        public Task SaveReadingAsync(SensorReading isAny)
        {
            return Task.CompletedTask;
        }
    }
}
