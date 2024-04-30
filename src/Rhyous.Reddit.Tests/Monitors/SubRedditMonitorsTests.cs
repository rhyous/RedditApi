using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using Rhyous.Reddit.Models;
using System;
using System.Threading.Tasks;

namespace Rhyous.Reddit.Tests.Monitors
{
    [TestClass]
    public class SubRedditMonitorsTests
    {
        private MockRepository _MockRepository;

        private Mock<IRedditSettings> _MockRedditSettings;
        private Mock<IRedditClientFactory> _MockRedditClientFactory;
        private Mock<IThreadFactory> _MockThreadFactory;
        private Mock<ISubRedditRepository> _MockSubRedditRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockRedditSettings = _MockRepository.Create<IRedditSettings>();
            _MockRedditClientFactory = _MockRepository.Create<IRedditClientFactory>();
            _MockThreadFactory = _MockRepository.Create<IThreadFactory>();
            _MockSubRedditRepository = _MockRepository.Create<ISubRedditRepository>();
        }

        private SubRedditMonitors CreateSubRedditMonitors()
        {
            return new SubRedditMonitors(
                _MockRedditSettings.Object,
                _MockRedditClientFactory.Object,
                _MockThreadFactory.Object,
                _MockSubRedditRepository.Object);
        }

        #region SetupMonitorAsync
        [TestMethod]
        public async Task SubRedditMonitors_SetupMonitorAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var subRedditMonitors = CreateSubRedditMonitors();
            IEnumerable<string> subReddits = null;
            TokenResponse response = null;

            // Act
            await subRedditMonitors.SetupMonitorAsync(
                subReddits,
                response);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion

        #region Start
        [TestMethod]
        public void SubRedditMonitors_Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var subRedditMonitors = CreateSubRedditMonitors();

            // Act
            subRedditMonitors.Start();

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion

        #region Stop
        [TestMethod]
        public void SubRedditMonitors_Stop_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var subRedditMonitors = CreateSubRedditMonitors();

            // Act
            subRedditMonitors.Stop();

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
