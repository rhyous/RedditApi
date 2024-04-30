using Rhyous.StringLibrary;

namespace Rhyous.Reddit
{
    internal class RedditSettings : IRedditSettings
    {
        private readonly IArgs _Args;

        public RedditSettings(IArgs args)
        {
            _Args = args;
        }
        public string AppId => _Args.Value(nameof(AppId));
        public string ClientSecret => _Args.Value(nameof(ClientSecret));
        public string OAuth2Url => _Args.Value(nameof(OAuth2Url));
        public string RedirectUrl => _Args.Value(nameof(RedirectUrl));
        public string[] Scopes => _Args.Value(nameof(Scopes)).Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
        public string[] SubReddits => _Args.Value(nameof(SubReddits)).Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
        public string TokenUrl => _Args.Value(nameof(TokenUrl));
        public int MaxThreads => _Args.Value(nameof(MaxThreads)).To<int>();
    }
}
