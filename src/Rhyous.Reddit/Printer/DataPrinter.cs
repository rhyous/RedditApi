namespace Rhyous.Reddit
{
    internal class DataPrinter : IDataPrinter
    {
        public void Print(SubRedditData data)
        {
            if (data == null)
            {
                Console.WriteLine($"No data found.");
            }
            else
            {
                Console.WriteLine($"SubReddit: {data.Name}");
                foreach (var post in data.Posts.Values)
                {
                    Console.WriteLine($"Title: {post.Title}");
                    Console.WriteLine($"UpVotes: {post.UpVotes}");
                }
            }
        }
    }
}
