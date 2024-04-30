using Rhyous.Reddit;
using System.Collections.Concurrent;

namespace Rhyous.Reddit
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly ConcurrentDictionary<string, IHttpClient> _HttpClients;

        private readonly IHttpClient _SingleHttpClient;

        public HttpClientFactory()
        {
            _SingleHttpClient = new HttpClientWrapper(new HttpClient());
            _HttpClients = new ConcurrentDictionary<string, IHttpClient>();
        }
        public IHttpClient GetHttpClient(string url = null)
        {
            if (string.IsNullOrWhiteSpace(url))
                return _SingleHttpClient;
            if (_HttpClients.TryGetValue(url, out IHttpClient client))
                return client;
            // Turn the Url into a base address.
            var getBaseAddress = new Uri(new Uri(url).GetLeftPart(UriPartial.Authority));
            var httpClient = new HttpClientWrapper(new HttpClient { BaseAddress = getBaseAddress });
            _HttpClients.TryAdd(url, httpClient);
            return httpClient;
        }
    }
}
