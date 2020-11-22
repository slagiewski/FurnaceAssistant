using System;
using System.Threading.Tasks;
using FurnaceAssistant.Core.DataAccess;
using FurnaceAssistant.Core.Sensors.Interfaces;
using Moq;
using Xunit;

namespace FurnaceAssistant.Core.Schedulers
{
    public class ReadSchedulerTests
    {
        [Fact]
        public async Task SchedulerShouldCallSensorAndTimer()
        {
            var timerMock = new Mock<ITimer>();
            var timerFactoryMock = new Mock<ITimerFactory>();
            var sensorMock = new Mock<ISensor>();
            var readingsRepositoryMock = new Mock<IReadingsRepository>();
            const double interval = 2.0d;

            timerFactoryMock.Setup(factory => factory.CreateTimer()).Returns(timerMock.Object);

            var scheduler = new ReadScheduler(timerFactoryMock.Object, readingsRepositoryMock.Object);

            var scheduledReading = scheduler.ScheduleReadings(sensorMock.Object, interval);
            
            // wait until elapsed

            timerFactoryMock.Verify(factory => factory.CreateTimer(), Times.Once);
            timerMock.Verify(timer => timer.OnElapsed(interval, It.IsAny<Func<Task>>()));
        }
    }
}
