using System.Threading.Tasks;

namespace FurnaceAssistant.Core
{
    public interface ISensorConnection
    {
        Task<byte[]> ReadAsync();
    }
}