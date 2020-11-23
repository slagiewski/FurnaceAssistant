using System;
using System.Linq;

namespace FurnaceAssistant.Core.DataModels.Sensor
{
    public class SensorReading
    {
        public string Measurement { get; }
        public ResponseError[] Errors { get; }

        public bool IsValid => !Errors.Any();

        private SensorReading(string content, ResponseError[] errors)
        {
            Measurement = content;
            Errors = errors;
        }

        public static SensorReading Valid(string measurement)
        {
            return new SensorReading(measurement, Array.Empty<ResponseError>());
        }

        public static SensorReading Error(ResponseError error) => Error(new[] {error});

        public static SensorReading Error(ResponseError[] errors) => new SensorReading(string.Empty, errors);
    }
}