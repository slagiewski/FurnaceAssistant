using System;
using FurnaceAssistant.Core.Sensors.Interfaces;

namespace FurnaceAssistant.Core.Schedulers
{
    public class ScheduledReading : IScheduledReading
    {
        private readonly ITimer _timer;
        public ISensor ReadSensor { get; }
        public double Interval { get; }

        public ScheduledReading(ISensor sensor, in double interval, ITimer timer)
        {
            ReadSensor = sensor;
            Interval = interval;
            _timer = timer;
        }

        public bool Cancel()
        {
            try
            {
                _timer.Stop();
                _timer.Dispose();
                return true;
            }
            catch (Exception e)
            {
                // TODO: Add logger
                Console.WriteLine(e);
                return false;
            }
        }
    }
}