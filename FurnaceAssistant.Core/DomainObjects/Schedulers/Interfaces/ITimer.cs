using System;
using System.Threading.Tasks;

namespace FurnaceAssistant.Core.Schedulers
{
    public interface ITimer : IDisposable
    {
        void OnElapsed(double interval, Action onElapsed);
        void OnElapsed(double interval, Func<Task> onElapsed);
        void Stop();
    }
}