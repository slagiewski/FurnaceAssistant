namespace FurnaceAssistant.Core
{
    public class SensorReading
    {
        public string Content { get; }
        public bool IsValid { get; }

        public SensorReading(string content, bool isValid)
        {
            Content = content;
            IsValid = isValid;
        }
    }
}