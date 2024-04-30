using Rhyous.Reddit.Models;

namespace Rhyous.Reddit
{
    internal interface ISubRedditMonitors
    {
        Task SetupMonitorAsync(IEnumerable<string> subReddits, TokenResponse response);

        bool IsStarted { get; }
        void Start();
        void Stop();

    }
}