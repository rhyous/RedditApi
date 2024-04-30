using System.Collections.Concurrent;

namespace Rhyous.Reddit
{
    public class SubRedditData 
    {
        public SubRedditData()
        {
            Posts = new ConcurrentDictionary<string, Post>();
        }

        public string Name { get; set; }

        public ConcurrentDictionary<string, Post> Posts { get; }
    }
}
