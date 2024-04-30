using System.Collections.Concurrent;

namespace Rhyous.Reddit
{
    internal interface ISubRedditRepository
    {
        /// <summary></summary>
        /// <remarks>This id of posts is a string.</remarks>
        ConcurrentDictionary<string, SubRedditData> Data { get; }

        void Create(SubRedditData data);

        SubRedditData Get(string id);
    }
}