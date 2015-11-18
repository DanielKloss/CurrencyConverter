using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.Linq;
using System.Xml.Linq;
using Moq;
using System.Xml;


namespace UnitTest
{
    [TestClass]
    public class UnitTestReader
    {
        [TestMethod]
        public void Test_ReadXMLFile_CallsTheXmlReader_WhenCalled()
        {
            //Arrange

            HistoricalData history = new HistoricalData();
            Mock<XmlTextReader> reader = new Mock<XmlTextReader>();

            //Act


            //Assert

        }
    }
}
