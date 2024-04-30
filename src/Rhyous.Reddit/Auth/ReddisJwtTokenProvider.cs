using Rhyous.Reddit.Models;
using System.Net.Http.Headers;
using System.Text;

namespace Rhyous.Reddit
{
    internal class ReddisJwtTokenProvider : IReddisJwtTokenProvider
    {
        private readonly IHttpClientFactory _HttpClientFactory;
        private readonly IRedditSettings _RedditSettings;
        private readonly ISerializer _Serializer;

        public ReddisJwtTokenProvider(IHttpClientFactory httpClientFactory,
                                      IRedditSettings redditSettings,
                                      ISerializer serializer)
        {
            _HttpClientFactory = httpClientFactory;
            _RedditSettings = redditSettings;
            _Serializer = serializer;
        }

        public async Task<TokenResponse> GetAccessToken(string code)
        {
            var client = _HttpClientFactory.GetHttpClient(_RedditSettings.TokenUrl);
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_RedditSettings.AppId}:{_RedditSettings.ClientSecret}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Rhyous.WebApp/0.1 by Rhyous");

            var content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", _RedditSettings.RedirectUrl)
            ]);

            var response = await client.PostAsync(_RedditSettings.TokenUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var token = _Serializer.Deserialize<TokenResponse>(responseString);
            return token; // Deserialize and use this response
        }
    }
}
