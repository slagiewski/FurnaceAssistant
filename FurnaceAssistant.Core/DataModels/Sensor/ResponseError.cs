namespace FurnaceAssistant.Core.DataModels.Sensor
{
    public class ResponseError
    {
        public string Message { get; }

        public ResponseError(string message)
        {
            Message = message;
        }
    }
}
