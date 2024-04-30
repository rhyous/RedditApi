using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;

namespace Rhyous.Reddit.Tests.Settings
{
    [TestClass]
    public class RedditSettingsTests
    {
        private MockRepository _MockRepository;

        private Mock<IArgs> _MockArgs;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockArgs = _MockRepository.Create<IArgs>();
        }

        private RedditSettings CreateRedditSettings()
        {
            return new RedditSettings(
                _MockArgs.Object);
        }

        #region $TestedMethodName$
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var redditSettings = CreateRedditSettings();

            // Act


            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
