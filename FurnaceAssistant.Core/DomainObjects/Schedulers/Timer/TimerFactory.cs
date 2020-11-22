using FurnaceAssistant.Core.Schedulers;

namespace FurnaceAssistant.Core.DomainObjects.Schedulers.Timer
{
    public class TimerFactory : ITimerFactory
    {
        public ITimer CreateTimer()
        {
            return new Timer();
        }
    }
}
