namespace FurnaceAssistant.Core
{
    public class SensorReading
    {
        public string Measurement { get; }
        public bool IsValid { get; }

        public SensorReading(string content, bool isValid)
        {
            Measurement = content;
            IsValid = isValid;
        }
    }
}