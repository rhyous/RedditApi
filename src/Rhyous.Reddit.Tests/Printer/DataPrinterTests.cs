using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhyous.Reddit;
using System;

namespace Rhyous.Reddit.Tests.Printer
{
    [TestClass]
    public class DataPrinterTests
    {
        private MockRepository _MockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);


        }

        private DataPrinter CreateDataPrinter()
        {
            return new DataPrinter();
        }

        #region Print
        [TestMethod]
        public void DataPrinter_Print_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dataPrinter = CreateDataPrinter();
            SubRedditData data = null;

            // Act
            dataPrinter.Print(
                data);

            // Assert
            Assert.Fail();
            _MockRepository.VerifyAll();
        }
        #endregion
    }
}
