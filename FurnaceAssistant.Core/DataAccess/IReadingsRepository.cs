using System.Threading.Tasks;

namespace FurnaceAssistant.Core.DataAccess
{
    public interface IReadingsRepository
    {
        Task SaveReadingAsync(SensorReading isAny);
    }
}