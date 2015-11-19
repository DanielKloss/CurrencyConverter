using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DailyDataTest
    {
        Dictionary<string, double> Result;

        [TestInitialize]
        public void Setup()
        {
            Result = null;
        }

        [TestMethod]
        public void Test_ReadXMLFileOfDailyData_CheckIFAnemptyFilePassedToXMLFileOfDailyDataReturnsANULL_ReturnsNullIFEmpty()
        {
            //Arrange
            string path = string.Empty;

            //Act  
            Result = DailyData.ReadXMLFile(path);

            //Assert
            Assert.IsNull(Result);
        }

        [TestMethod]
        public void Test_GetDictionary_ReturnsADictionary_WhenCalled()
        {
            //Arrange
            string path = string.Empty;
            
            //Act
            Result = DailyData.GetDictionary();
            Dictionary<string,double> expected=null;

            //Assert
            Assert.AreSame(expected, Result);
        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}
