using System;
using System.Threading.Tasks;

namespace FurnaceAssistant.Core.Connections
{
    public class SensorConnection: ISensorConnection
    {
        public SensorConnection()
        {
            
        }

        public Task<byte[]> ReadAsync()
        {
            throw new NotImplementedException();
        }
    }
}