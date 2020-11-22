using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using FurnaceAssistant.Core.Abstractions;
using FurnaceAssistant.Core.Connections;
using FurnaceAssistant.Core.DomainObjects.Schedulers.Timer;
using FurnaceAssistant.Core.Schedulers;
using FurnaceAssistant.Core.Sensors;
using FurnaceAssistant.DataAccess.Repositories;

namespace FurnaceAssistant.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            var connection = new NetworkStatusConnection(
                new HttpNetworkClient(new HttpClient()), new Uri("https://www.google.com"));
            var sensor = new NetworkConnectionSensor(connection);
            var timerFactory = new TimerFactory();
            var repository = new ReadingsRepository();
            var scheduler = new ReadScheduler(timerFactory, repository);

            var scheduledReadings = scheduler.ScheduleReadings(sensor, 15);
            
            System.Console.ReadKey();

            scheduledReadings.Cancel();

            System.Console.ReadKey();
        }
    }
}
