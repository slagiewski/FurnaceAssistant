using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FurnaceAssistant.Core.Abstractions
{
    public interface INetworkClient
    {
        Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}