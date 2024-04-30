using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;

namespace Rhyous.Reddit.Tests.Factories
{
    [TestClass]
    public class ObjectFactoryTests
    {
        private MockRepository _MockRepository;

        private Mock<ILifetimeScope> _MockLifetimeScope;

        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);

            _MockLifetimeScope = _MockRepository.Create<ILifetimeScope>();
        }

        private ObjectFactory<T> CreateFactory<T>()
        {
            return new ObjectFactory<T>(_MockLifetimeScope.Object);
        }

        #region Create
        [TestMethod]
        public void ObjectFactory_Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = CreateFactory<ILogger>();
            var mockLogger = _MockRepository.Create<ILogger>();
            _MockLifetimeScope.Setup(m => m.Resolve<ILogger>()).Returns(mockLogger.Object);
            // Act
            var result = factory.Create();

            // Assert
            Assert.AreEqual(mockLogger.Object, result);
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
