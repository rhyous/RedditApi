using Rhyous.SimpleArgs;
using System.Collections.ObjectModel;
using System.Linq;

namespace Rhyous.Reddit.Arguments
{
    /// <summary>
    /// A class that implements IArgumentsHandler where command line
    /// arguments are defined.
    /// </summary>
    public sealed class ArgsHandler : Rhyous.SimpleArgs.ArgsHandlerBase
    {
        public override void InitializeArguments(IArgsManager argsManager)
        {
            Arguments.AddRange(new List<Argument>
            {
                // string AppId { get; }
                new Argument
                {
                    Name = "AppId",
                    ShortName = "a",
                    Description = "The application id. Provided when registering your app on Reddit.",
                    Example = "{name}=alphnumerics123_alphnumerics456",
                    IsRequired = true
                },
                // string ClientSecret { get; }
                new Argument
                {
                    Name = "ClientSecret",
                    ShortName = "c",
                    Description = "The cleint secret. Provided when registering your app on Reddit as a web site.",
                    Example = "{name}=alphnumericssecret123",
                    IsRequired = true
                },                
                // string OAuth2Url { get; }
                new Argument
                {
                    Name = "OAuth2Url",
                    ShortName = "o",
                    Description = "The url to call to authenticate with.",
                    Example = "{name}=https://www.reddit.com/api/v1/authorize",
                    DefaultValue = "https://www.reddit.com/api/v1/authorize",
                    IsRequired = false // The defaul shoudl work
                },
                // string OAuth2Url { get; }
                new Argument
                {
                    Name = "RedirectUrl",
                    ShortName = "ru",
                    Description = "The url to call to authenticate with.",
                    Example = "{name}=http://127.0.0.1:7090",
                    IsRequired = true
                },
                /// string[] Scopes { get; }
                new Argument
                {
                    Name = "Scopes",
                    ShortName = "s",
                    Description = "A space separate list of scopes. It must be quoted or the spaces look like different params.",
                    Example = "{name}=\"Scope1 Scope2\"",
                    IsRequired = true
                },
                /// string[] SubReddits { get; }
                new Argument
                {
                    Name = "SubReddits",
                    ShortName = "sr",
                    Description = "A space separate list of SubReddits. It must be quoted or the spaces look like different params.",
                    Example = "{name}=\"SubReddit1 SubReddit2\"",
                    IsRequired = true
                },
                // string OAuth2Url { get; }
                new Argument
                {
                    Name = "TokenUrl",
                    ShortName = "t",
                    Description = "The token url to call to authenticate with which returns the OAuth2 JWT Token.",
                    Example = "{name}=\"https://www.reddit.com/api/v1/access_token\"",
                    DefaultValue = "https://www.reddit.com/api/v1/access_token",
                    IsRequired = false // Has default
                },
                // string MaxThreads { get; }
                new Argument
                {
                    Name = "MaxThreads",
                    ShortName = "m",
                    Description = "The maximum number of threads.",
                    Example = "{name}=10",
                    DefaultValue = 10.ToString(),
                    IsRequired = false // Has default
                },
                // string MaxThreads { get; }
                new Argument
                {
                    Name = "LogLevel",
                    ShortName = "l",
                    Description = $"Valid log levels with are {string.Join(", ", Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>().Select(e => e.ToString()))}.",
                    Example = "{name}=Debug",
                    DefaultValue = "Info",
                    IsRequired = false, // Has default
                    AllowedValues = new ObservableCollection<string>(Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>().Select(e => e.ToString()))
                },
                new ConfigFileArgument(argsManager)
            });
        }

        public override int MinimumRequiredArgs
        {
            get { return Arguments.Where(arg => arg.IsRequired).Count(); } // At least one argument is required
        }
    }
}