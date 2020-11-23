using FurnaceAssistant.Core.DataModels.Connection;
using System;
using System.Threading.Tasks;

namespace FurnaceAssistant.Core.Connections
{
    public class SensorConnection: ISensorConnection
    {
        public SensorConnection()
        {
            
        }

        Task<ConnectionResponse> ISensorConnection.ReadAsync()
        {
            throw new NotImplementedException();
        }
    }
}