using Autofac;
using Newtonsoft.Json.Linq;
using Reddit;
using Rhyous.Reddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhyous.Reddit
{
    internal class RedditClientFactory : IRedditClientFactory
    {
        private readonly ILifetimeScope _Scope;
        private readonly IRedditSettings _RedditSettings;

        public RedditClientFactory(ILifetimeScope scope,
                                   IRedditSettings redditSettings)
        {
            _Scope = scope;
            _RedditSettings = redditSettings;
        }
        public RedditClient Create(string token, string refreshToken)
        {
            return _Scope.Resolve<RedditClient>(new NamedParameter("appId", _RedditSettings.AppId),
                                         new NamedParameter("appSecret", _RedditSettings.ClientSecret),
                                         new NamedParameter("token", token),
                                         new NamedParameter("refreshToken", refreshToken));
        }
    }
}
