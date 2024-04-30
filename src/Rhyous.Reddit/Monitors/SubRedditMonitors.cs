using Reddit;
using Rhyous.Reddit.Models;

namespace Rhyous.Reddit
{
    internal class SubRedditMonitors : ISubRedditMonitors
    {

        private List<IThread> _Threads = new List<IThread>();

        private readonly IRedditSettings _RedditSettings;
        private readonly IRedditClientFactory _RedditClientFactory;
        private readonly IThreadFactory _ThreadFactory;
        private readonly ISubRedditRepository _SubRedditRepository;

        public SubRedditMonitors(IRedditSettings redditSettings,
                                 IRedditClientFactory redditClientFactory,
                                 IThreadFactory threadFactory,
                                 ISubRedditRepository subRedditRepository)
        {
            _RedditSettings = redditSettings;
            _RedditClientFactory = redditClientFactory;
            _ThreadFactory = threadFactory;
            _SubRedditRepository = subRedditRepository;
        }

        public async Task SetupMonitorAsync(IEnumerable<string> subReddits, TokenResponse response)
        {
            await Task.Run(() =>
            {
                var client = _RedditClientFactory.Create(response.AccessToken, response.RefreshToken);
                var subReddits = _RedditSettings.SubReddits.Take(_RedditSettings.MaxThreads); // only do this for max
                foreach (var subReddit in subReddits)
                {
                    var thread = _ThreadFactory.Create(() => { GetTop10Posts(client, subReddit); });
                    _Threads.Add(thread);
                }
            });
        }

        public bool IsStarted => _Threads.Any(t => t.IsStarted);

        public void Start()
        {
            foreach (var thread in _Threads)
            {
                thread.Start();
            }
        }

        public void Stop()
        {
            foreach (var thread in _Threads)
            {
                thread.Start();
            }
        }

        // This currently doesn't get everything asked for yet, but it can. 
        // I'd probably through the data to gather into an SRP class and inject it
        private void GetTop10Posts(RedditClient client, string subReddit)
        {
            var sub = client.Subreddit(subReddit);
            var data = new SubRedditData { Name = subReddit };
            var topPosts = sub.Posts.GetTop(t: "all", limit: 10);
            foreach (var post in topPosts)
            {
                var repoPost = new Post { Name = post.Fullname, Title = post.Title, UpVotes = post.UpVotes };
                data.Posts.AddOrUpdate(post.Id, repoPost, (n, p) => repoPost);
            }
            _SubRedditRepository.Create(data);

        }
    }
}
