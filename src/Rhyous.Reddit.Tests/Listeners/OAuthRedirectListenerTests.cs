using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using Rhyous.Reddit.Interfaces;
using System;
using System.Threading.Tasks;

namespace Rhyous.Reddit.Tests.Listeners
{
    [TestClass]
    public class OAuthRedirectListenerTests
    {
        private MockRepository _MockRepository;

        private Mock<IRandomStringGenerator> _MockRandomStringGenerator;
        private Mock<IRedditSettings> _MockRedditSettings;
        private Mock<IObjectFactory<IHttpListener>> _MockObjectFactory;
        private Mock<ILogger> _MockLogger;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockRandomStringGenerator = _MockRepository.Create<IRandomStringGenerator>();
            _MockRedditSettings = _MockRepository.Create<IRedditSettings>();
            _MockObjectFactory = _MockRepository.Create<IObjectFactory<IHttpListener>>();
            _MockLogger = _MockRepository.Create<ILogger>();
        }

        private OAuthRedirectListener CreateOAuthRedirectListener()
        {
            return new OAuthRedirectListener(
                _MockRandomStringGenerator.Object,
                _MockRedditSettings.Object,
                _MockObjectFactory.Object,
                _MockLogger.Object);
        }

        #region ListenAsync
        [TestMethod]
        public async Task OAuthRedirectListener_ListenAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var oAuthRedirectListener = CreateOAuthRedirectListener();
            string state = null;

            // Act
            var result = await oAuthRedirectListener.ListenAsync(
                state);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
