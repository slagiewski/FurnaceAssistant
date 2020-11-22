using System.Threading.Tasks;
using FurnaceAssistant.Core.Sensors.Interfaces;

namespace FurnaceAssistant.Core.Schedulers
{
    public interface IScheduledReading
    {
        double Interval { get; }
        bool Cancel();
        ISensor ReadSensor { get; }
    }
}