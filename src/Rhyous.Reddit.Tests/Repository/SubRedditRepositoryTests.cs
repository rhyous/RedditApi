using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using System;

namespace Rhyous.Reddit.Tests.Repository
{
    [TestClass]
    public class SubRedditRepositoryTests
    {
        private MockRepository _MockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);


        }

        private SubRedditRepository CreateSubRedditRepository()
        {
            return new SubRedditRepository();
        }

        #region Create
        [TestMethod]
        public void SubRedditRepository_Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var subRedditRepository = CreateSubRedditRepository();
            SubRedditData data = null;

            // Act
            subRedditRepository.Create(
                data);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion

        #region Get
        [TestMethod]
        public void SubRedditRepository_Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var subRedditRepository = CreateSubRedditRepository();
            string name = null;

            // Act
            var result = subRedditRepository.Get(
                name);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
