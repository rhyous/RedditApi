using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;

namespace Rhyous.Reddit.Tests.UI
{
    [TestClass]
    public class ConsoleUITests
    {
        private MockRepository _MockRepository;

        private Mock<ISubRedditRepository> _MockSubRedditRepository;
        private Mock<IDataPrinter> _MockDataPrinter;
        private Mock<IRedditSettings> _MockRedditSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockSubRedditRepository = _MockRepository.Create<ISubRedditRepository>();
            _MockDataPrinter = _MockRepository.Create<IDataPrinter>();
            _MockRedditSettings = _MockRepository.Create<IRedditSettings>();
        }

        private ConsoleUI CreateConsoleUI()
        {
            return new ConsoleUI(
                _MockSubRedditRepository.Object,
                _MockDataPrinter.Object,
                _MockRedditSettings.Object);
        }

        #region Start
        [TestMethod]
        public void ConsoleUI_Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var consoleUI = CreateConsoleUI();

            // Act
            consoleUI.Start();

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
