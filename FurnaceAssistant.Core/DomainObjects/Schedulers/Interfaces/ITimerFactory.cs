namespace FurnaceAssistant.Core.Schedulers
{
    public interface ITimerFactory
    {
        ITimer CreateTimer();
    }
}