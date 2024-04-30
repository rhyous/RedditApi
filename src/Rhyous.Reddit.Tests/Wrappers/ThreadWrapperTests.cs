using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using System;

namespace Rhyous.Reddit.Tests.Wrappers
{
    [TestClass]
    public class ThreadWrapperTests
    {
        private MockRepository _MockRepository;

        private Mock<Action> _MockAction;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockAction = _MockRepository.Create<Action>();
        }

        private ThreadWrapper CreateThreadWrapper()
        {
            return new ThreadWrapper(
                _MockAction.Object);
        }

        #region Start
        [TestMethod]
        public void ThreadWrapper_Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var threadWrapper = CreateThreadWrapper();

            // Act
            threadWrapper.Start();

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion

        #region Stop
        [TestMethod]
        public void ThreadWrapper_Stop_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var threadWrapper = CreateThreadWrapper();

            // Act
            threadWrapper.Stop();

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
