using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using System;
using System.Threading.Tasks;

namespace Rhyous.Reddit.Tests.Auth
{
    [TestClass]
    public class ReddisJwtTokenProviderTests
    {
        private MockRepository _MockRepository;

        private Mock<IHttpClientFactory> _MockHttpClientFactory;
        private Mock<IRedditSettings> _MockRedditSettings;
        private Mock<ISerializer> _MockSerializer;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockHttpClientFactory = _MockRepository.Create<IHttpClientFactory>();
            _MockRedditSettings = _MockRepository.Create<IRedditSettings>();
            _MockSerializer = _MockRepository.Create<ISerializer>();
        }

        private ReddisJwtTokenProvider CreateProvider()
        {
            return new ReddisJwtTokenProvider(
                _MockHttpClientFactory.Object,
                _MockRedditSettings.Object,
                _MockSerializer.Object);
        }

        #region GetAccessToken
        [TestMethod]
        public async Task ReddisJwtTokenProvider_GetAccessToken_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var provider = CreateProvider();
            string code = null;

            // Act
            var result = await provider.GetAccessToken(
                code);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
