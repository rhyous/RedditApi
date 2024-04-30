using System.Diagnostics.CodeAnalysis;
using System.Net;
using Rhyous.Reddit.Interfaces;

namespace Rhyous.Reddit
{
    [ExcludeFromCodeCoverage]
    internal class HttpListenerWrapper : IHttpListener
    {
        private readonly HttpListener _HttpListener;

        public HttpListenerWrapper(HttpListener httpListener)
        {
            _HttpListener = httpListener;
        }

        public HttpListenerPrefixCollection Prefixes => _HttpListener.Prefixes;
        public HttpListenerRequest Request { get; }

        public void Dispose() => (_HttpListener as IDisposable).Dispose();

        public async Task<HttpListenerContext> GetContextAsync() => await _HttpListener.GetContextAsync();
        public void Start() => _HttpListener.Start();
        public void Stop() => _HttpListener.Stop();
    }
}
