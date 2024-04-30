using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using System;

namespace Rhyous.Reddit.Tests.Factories
{
    [TestClass]
    public class ThreadFactoryTests
    {
        private MockRepository _MockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ThreadFactory CreateFactory()
        {
            return new ThreadFactory();
        }

        #region Create
        [TestMethod]
        public void ThreadFactory_Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = CreateFactory();
            Action method = null;

            // Act
            var result = factory.Create(
                method);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
