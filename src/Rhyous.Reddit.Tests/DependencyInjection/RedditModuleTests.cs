using Autofac;
using Moq;
using Rhyous.Reddit.DependencyInjection;
using Rhyous.Reddit.Interfaces;
using System.Net;

namespace Rhyous.Reddit.Tests.DependencyInjection
{
    [TestClass]
    public class RedditModuleTests
    {
        private MockRepository _MockRepository;

        IContainer _Container;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            _MockRepository = new MockRepository(MockBehavior.Strict);

            var builder = new ContainerBuilder();
            // Register dependencies for the container here, probably as mocks if you can
            var args = new string[]
            {
                "LogLevel=Debug",
                "appId=someAppId",
                "clientSecret=someClientSecret",
                "oauth2Url=someOAth2Url",
                "redirectUrl=someRedirectUrl",
                "scopes=\"Scope1 Scope2\"",
                "subReddits=\"brandonsanderson cosmere mistborn\""
            };

            // Register the module
            builder.RegisterModule<RedditModule>();

            // Build the container
            _Container = builder.Build();
        }

        #region Test that everything resolves
        [TestMethod]
        public void RedditModule_IArgs_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IArgs>();
            var b = _Container.Resolve<IArgs>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_ILogSettings_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<ILogSettings>();
            var b = _Container.Resolve<ILogSettings>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IRedditSettings_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IRedditSettings>();
            var b = _Container.Resolve<IRedditSettings>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_ILogger_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<ILogger>();
            var b = _Container.Resolve<ILogger>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IObjectFactory_ILogger_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IObjectFactory<ILogger>>();
            var b = _Container.Resolve<IObjectFactory<ILogger>>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IRandomStringGenerator_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IRandomStringGenerator>();
            var b = _Container.Resolve<IRandomStringGenerator>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_HttpListener_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<HttpListener>();
            var b = _Container.Resolve<HttpListener>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IHttpListener_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IHttpListener>();
            var b = _Container.Resolve<IHttpListener>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_ISerializer_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<ISerializer>();
            var b = _Container.Resolve<ISerializer>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IOAuthRedirectListener_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IOAuthRedirectListener>();
            var b = _Container.Resolve<IOAuthRedirectListener>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IReddisJwtTokenProvider_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IReddisJwtTokenProvider>();
            var b = _Container.Resolve<IReddisJwtTokenProvider>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IHttpClientFactory_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IHttpClientFactory>();
            var b = _Container.Resolve<IHttpClientFactory>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IRedditClientFactory_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IRedditClientFactory>();
            var b = _Container.Resolve<IRedditClientFactory>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IThreadFactory_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IThreadFactory>();
            var b = _Container.Resolve<IThreadFactory>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_ISubRedditMonitors_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<ISubRedditMonitors>();
            var b = _Container.Resolve<ISubRedditMonitors>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_ISubRedditRepository_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<ISubRedditRepository>();
            var b = _Container.Resolve<ISubRedditRepository>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IConsoleUI_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IConsoleUI>();
            var b = _Container.Resolve<IConsoleUI>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        [TestMethod]
        public void RedditModule_IDataPrinter_ResolvesAsSingleton()
        {
            // Act
            var a = _Container.Resolve<IDataPrinter>();
            var b = _Container.Resolve<IDataPrinter>();

            // Assert
            Assert.IsNotNull(a);
            Assert.AreSame(a, b);
        }

        #endregion
    }
}
