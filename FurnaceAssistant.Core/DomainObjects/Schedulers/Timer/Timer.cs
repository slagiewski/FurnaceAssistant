using System;
using System.Threading.Tasks;
using FurnaceAssistant.Core.Schedulers;

namespace FurnaceAssistant.Core.DomainObjects.Schedulers.Timer
{
    public class Timer : ITimer
    {
        private readonly System.Timers.Timer _timer;

        public Timer()
        {
            _timer = new System.Timers.Timer();
        }

        public void OnElapsed(double interval, Action onElapsed)
        {
            _timer.Interval = interval;
            _timer.AutoReset = true;
            _timer.Elapsed += (sender, args) => onElapsed();
            _timer.Start();
        }

        public void OnElapsed(double intervalInSecs, Func<Task> onElapsed)
        {
            _timer.Interval = intervalInSecs * 1000;
            _timer.AutoReset = true;
            _timer.Elapsed += async (sender, args) => await onElapsed();
            _timer.Start();
        }


        public void Stop()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
