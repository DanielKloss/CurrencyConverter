using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CurrencyConverter;
using Moq;

namespace Tests
{
  [TestClass]
  public class HistoricalManipulationTest
  {
    [TestMethod]
    public void Test_Averages_ReturnsAverageOfGivenListOfNumbers()
    {
      //Arrange
      HistoricalManipulation historicalManipulation = new HistoricalManipulation();
      List<double> listOfValues = new List<double>() {3,5,7,2.3,6.2,6.5};
      double expectedValue = 5;

      //Act
      double actualValues = historicalManipulation.Averages(listOfValues);

      //Assert
      Assert.AreEqual(expectedValue, actualValues);
    }
    [TestMethod]
    public void Test_Averages_Returns0WhenGivenEmptyList()
    {
      //Arrange
      HistoricalManipulation historicalManipulation = new HistoricalManipulation();
      List<double> listOfValues = new List<double>();
      double expectedValue = 0;

      //Act
      double actualValues = historicalManipulation.Averages(listOfValues);

      //Assert
      Assert.AreEqual(expectedValue, actualValues);
    }
    [TestMethod]
    public void Test_ListAverages_ReturnsAListOfAveragesPerLine_GivenADictionaryOfDouble()
    {
      //Arrange
      HistoricalManipulation historicalManipulation = new HistoricalManipulation();


      //Act


      //Assert


    }
  }
}
