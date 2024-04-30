using Autofac;
using Reddit;
using Rhyous.Reddit;
using Rhyous.Reddit.Arguments;
using Rhyous.Reddit.DependencyInjection;
using Rhyous.Reddit.Interfaces;
using Rhyous.SimpleArgs;
using System;
using System.Diagnostics;

internal class Program
{
    internal static IContainer _Container;

    private static async Task Main(string[] args)
    {
        // Handle Args
        new ArgsManager<ArgsHandler>().Start(args);

        // Dependency Injection
        var builder = new ContainerBuilder();
        builder.RegisterModule<RedditModule>();
        _Container = builder.Build();
        var state = _Container.Resolve<IRandomStringGenerator>().Generate();
        var redditSettings = _Container.Resolve<IRedditSettings>();


        // Do stuff - this is to be broken out into SRP classes and registered.
        var listener = _Container.Resolve<IOAuthRedirectListener>();
        var listenTask = listener.ListenAsync(state);
        var code = await listenTask;
        var reddisAuthenticator = _Container.Resolve<IReddisJwtTokenProvider>();
        var token = await reddisAuthenticator.GetAccessToken(code);

        var monitor = _Container.Resolve<ISubRedditMonitors>();
        await monitor.SetupMonitorAsync(redditSettings.SubReddits, token);
        monitor.Start();

        var consoleUI = _Container.Resolve<IConsoleUI>();
        consoleUI.Start();
    }

    private static void Posts_NewUpdated(object? sender, Reddit.Controllers.EventArgs.PostsUpdateEventArgs e)
    {
        foreach (var post in e.Added)
        {
            Console.WriteLine($"New Post received. Author: {post.Author} Title: {post.Title}");
        }
    }
}