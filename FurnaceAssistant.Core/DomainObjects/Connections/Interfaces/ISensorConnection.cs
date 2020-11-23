using System.Threading.Tasks;
using FurnaceAssistant.Core.DataModels;
using FurnaceAssistant.Core.DataModels.Connection;

namespace FurnaceAssistant.Core
{
    public interface ISensorConnection
    {
        Task<ConnectionResponse> ReadAsync();
    }
}