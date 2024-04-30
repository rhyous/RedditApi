namespace Rhyous.Reddit
{
    internal interface IRedditSettings
    {
        string AppId { get; }
        string ClientSecret { get; }
        string OAuth2Url { get; }
        string RedirectUrl { get; }
        string[] Scopes { get; }
        string[] SubReddits { get; }
        string TokenUrl { get; }
        int MaxThreads { get; }
    }
}