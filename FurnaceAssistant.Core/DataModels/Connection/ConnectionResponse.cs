using System;
using System.Linq;

namespace FurnaceAssistant.Core.DataModels.Connection
{
    public class ConnectionResponse
    {
        public string Response { get; }
        public byte[] OriginalBytes { get; }
        public ResponseError[] Errors { get; }
        public bool IsValid => !Errors.Any();

        private ConnectionResponse(
            string response, 
            byte[] originalBytes, 
            ResponseError[] errors)
        {
            Response = response;
            OriginalBytes = originalBytes;
            Errors = errors;
        }

        public static ConnectionResponse Valid(
            string response,
            byte[] originalBytes)
        {
            return new ConnectionResponse(
                response, originalBytes, Array.Empty<ResponseError>());
        }

        public static ConnectionResponse Valid(
            string response)
        {
            return new ConnectionResponse(
                response, Array.Empty<byte>(), Array.Empty<ResponseError>());
        }

        public static ConnectionResponse Error(
            ResponseError[] errors)
        {
            return new ConnectionResponse(
                string.Empty, Array.Empty<byte>(), errors);
        }

        public static ConnectionResponse Error(ResponseError error) => Error(new [] {error});
    }
}