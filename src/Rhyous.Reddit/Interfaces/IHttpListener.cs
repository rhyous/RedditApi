using System.Net;

namespace Rhyous.Reddit.Interfaces
{
    internal interface IHttpListener : IDisposable
    {
        HttpListenerPrefixCollection Prefixes { get; }
        HttpListenerRequest Request { get; }

        Task<HttpListenerContext> GetContextAsync();
        void Start();
        void Stop();
    }
}