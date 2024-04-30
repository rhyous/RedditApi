using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using System;

namespace Rhyous.Reddit.Tests.Factories
{
    [TestClass]
    public class RedditClientFactoryTests
    {
        private MockRepository _MockRepository;

        private Mock<ILifetimeScope> _MockLifetimeScope;
        private Mock<IRedditSettings> _MockRedditSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockLifetimeScope = _MockRepository.Create<ILifetimeScope>();
            _MockRedditSettings = _MockRepository.Create<IRedditSettings>();
        }

        private RedditClientFactory CreateFactory()
        {
            return new RedditClientFactory(
                _MockLifetimeScope.Object,
                _MockRedditSettings.Object);
        }

        #region Create
        [TestMethod]
        public void RedditClientFactory_Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = CreateFactory();
            string token = null;
            string refreshToken = null;

            // Act
            var result = factory.Create(
                token,
                refreshToken);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
