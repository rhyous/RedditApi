using Reddit;

namespace Rhyous.Reddit
{
    internal interface IRedditClientFactory
    {
        RedditClient Create(string token, string refreshToken);
    }
}