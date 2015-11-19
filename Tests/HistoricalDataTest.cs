using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.IO;
using Moq;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HistoricalDataTest
    {
        HistoricalData newData;
 
        [TestInitialize]
        public void Setup()
        {
        newData=null;
        }

        [TestMethod]
        public void Test_ReadXMLFileOfHistoricalData_CheckIFAnemptyFilePassedToXMLFileOfHistoricalDataReturnsANULL_ReturnsNullIFEmpty()
        {
            //Arrange
            newData = new HistoricalData();
            Dictionary<string, Dictionary<string, double>> Result;

            //Act
            string path = string.Empty;
            Result = newData.ReadXMLFile(path);

            //Assert
            Assert.IsNull(Result);
        }
     
   /*     [TestMethod]
        public void Test_ReadXMLFileOfHistoricalData_CheckIFTheMethodCallsTheFileExistFunction_ReturnsTrue()
        {

           //Arrange
            newData = new HistoricalData();
           // del handler= File.Exists;
            string path = "example.xml";
           // Dictionary<string, Dictionary<string, double>> Result;

           //Act
            Mock<HistoricalData> data = new Mock<HistoricalData>();
            
           //Assert
            data.Object.ReadXMLFile(path);
            //data.Verify(x =>, Times.AtLeastOnce);

        }*/
        [TestMethod]
        public void Test_ReadReturnValidity_CheckIfTheStringIsAVAlidPath_ReturnsTrue()
        {
            //Arrange
            string path = "example.xml";

            //Act
            bool Result = HistoricalData.ReturnXmlValidity(path);

            //Assert
            Assert.IsTrue(Result);
        }

        
        [TestCleanup]
       public void Cleanup()
       {
           newData = null;
       }

    }
}
