using Autofac;
using Reddit;
using Rhyous.Reddit.Interfaces;
using Rhyous.Reddit;
using System.Net;

namespace Rhyous.Reddit.DependencyInjection
{
    internal class RedditModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArgsWrapper>().As<IArgs>().SingleInstance();

            builder.RegisterType<LogSettings>().As<ILogSettings>().SingleInstance();
            builder.RegisterType<RedditSettings>().As<IRedditSettings>().SingleInstance();

            builder.RegisterType<ConsoleLogger>().As<ILogger>().SingleInstance();
            builder.RegisterGeneric(typeof(ObjectFactory<>)).As(typeof(IObjectFactory<>)).SingleInstance();
            builder.RegisterType<RandomStringGenerator>().As<IRandomStringGenerator>().SingleInstance();
            builder.RegisterType<HttpListener>().SingleInstance();
            builder.RegisterType<HttpListenerWrapper>().As<IHttpListener>().SingleInstance();
            builder.RegisterType<JsonSerializer>().As<ISerializer>().SingleInstance();
            builder.RegisterType<OAuthRedirectListener>().As<IOAuthRedirectListener>().SingleInstance();
            builder.RegisterType<ReddisJwtTokenProvider>().As<IReddisJwtTokenProvider>().SingleInstance();

            builder.RegisterType<HttpClientFactory>().As<IHttpClientFactory>().SingleInstance();
            builder.RegisterType<RedditClientFactory>().As<IRedditClientFactory>().SingleInstance();
            builder.RegisterType<ThreadFactory>().As<IThreadFactory>().SingleInstance();

            builder.RegisterType<SubRedditMonitors>().As<ISubRedditMonitors>().SingleInstance();
            builder.RegisterType<SubRedditRepository>().As<ISubRedditRepository>().SingleInstance();

            builder.RegisterType<ConsoleUI>().As<IConsoleUI>().SingleInstance();

            builder.RegisterType<DataPrinter>().As<IDataPrinter>().SingleInstance();

            builder.RegisterType<RedditClient>();
        }
    }
}
