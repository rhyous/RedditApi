using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using System;

namespace Rhyous.Reddit.Tests.Factories
{
    [TestClass]
    public class HttpClientFactoryTests
    {
        private MockRepository _MockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);


        }

        private HttpClientFactory CreateFactory()
        {
            return new HttpClientFactory();
        }

        #region GetHttpClient
        [TestMethod]
        public void HttpClientFactory_GetHttpClient_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = CreateFactory();
            string url = null;

            // Act
            var result = factory.GetHttpClient(
                url);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
