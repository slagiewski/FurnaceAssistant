using FurnaceAssistant.Core.DataAccess;
using FurnaceAssistant.Core.Sensors.Interfaces;

namespace FurnaceAssistant.Core.Schedulers
{
    public class ReadScheduler
    {
        private readonly ITimerFactory _timerFactory;
        private readonly IReadingsRepository _readingsRepository;

        public ReadScheduler(ITimerFactory timerFactory, IReadingsRepository readingsRepository)
        {
            _timerFactory = timerFactory;
            _readingsRepository = readingsRepository;
        }

        public IScheduledReading ScheduleReadings(ISensor sensor, in double intervalInSec)
        {
            var timer = _timerFactory.CreateTimer();
            timer.OnElapsed(intervalInSec, async () =>
            {
                var reading = await sensor.ReadAsync();
                await _readingsRepository.SaveReadingAsync(reading);
            });
            return new ScheduledReading(sensor, intervalInSec, timer);
        }
    }
}