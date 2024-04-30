using System.Collections.Concurrent;

namespace Rhyous.Reddit
{
    internal class SubRedditRepository : ISubRedditRepository
    {
        public SubRedditRepository()
        {
            Data = new ConcurrentDictionary<string, SubRedditData>();
        }

        public ConcurrentDictionary<string, SubRedditData> Data { get; }

        public void Create(SubRedditData data)
        {
            if (!Data.TryGetValue(data.Name, out _))
                Data.AddOrUpdate(data.Name, data, (s, d1) => data);
        }

        public SubRedditData Get(string name)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }
            return Data.TryGetValue(name, out SubRedditData data)
                 ? data
                 : null;
        }
    }
}
