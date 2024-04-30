using Rhyous.StringLibrary;

namespace Rhyous.Reddit
{
    internal class ConsoleUI : IConsoleUI
    {
        private bool _IsStarted;

        private readonly ISubRedditRepository _SubRedditRepository;
        private readonly IDataPrinter _DataPrinter;
        private readonly IRedditSettings _RedditSettings;

        public ConsoleUI(ISubRedditRepository subRedditRepository,
                         IDataPrinter dataPrinter,
                         IRedditSettings redditSettings)
        {
            _SubRedditRepository = subRedditRepository;
            _DataPrinter = dataPrinter;
            _RedditSettings = redditSettings;
        }

        public void Start()
        {
            _IsStarted = true;
            while (_IsStarted)
            {
                Console.WriteLine("1. Output Top Posts.");
                Console.WriteLine("2. Exit.");
                var keyInfo = Console.ReadKey();
                Console.WriteLine();
                switch (keyInfo.KeyChar)
                {
                    case '1':
                        Console.WriteLine("What SubReddit?");
                        for (int i = 0; i < _RedditSettings.SubReddits.Length; i++)
                        {
                            Console.WriteLine($"{i}. {_RedditSettings.SubReddits[i]}");
                        }
                        var subRedditKeyInfo = Console.ReadKey();
                        Console.WriteLine();
                        var subRedditId = subRedditKeyInfo.KeyChar.ToString().To<int>(-1);
                        if (subRedditId < 0 || subRedditId > _RedditSettings.SubReddits.Length - 1)
                        {
                            PrepareForRepeat("Wrong choice.");
                            break;
                        }
                        _DataPrinter.Print(_SubRedditRepository.Get(_RedditSettings.SubReddits[subRedditId]));
                        PrepareForRepeat();
                        break;
                    case '2':
                        _IsStarted = false;
                        break;
                    default:
                        PrepareForRepeat("Wrong choice.");
                        break;
                }
            }
        }

        private static void PrepareForRepeat(string msg = null)
        {
            Console.WriteLine();
            if (msg != null)
                Console.WriteLine($"{msg}");
            Console.WriteLine($"{msg} Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
