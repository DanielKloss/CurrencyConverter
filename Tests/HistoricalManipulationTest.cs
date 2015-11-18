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
    HistoricalManipulation historicalManipulation;
    Mock<HistoricalMap> mockHistoricalMap;
    [TestInitialize]
    public void Setup()
    {
      mockHistoricalMap = new Mock<HistoricalMap>();
      historicalManipulation = new HistoricalManipulation(mockHistoricalMap.Object);
    }
    [TestMethod]
    public void Test_Averages_ReturnsAverageOfGivenListOfDoubles()
    {
      //Arrange
      List<double> listOfValues = new List<double>() { 3, 5, 7, 2.3, 6.2, 6.5 };
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
      List<double> listOfValues = new List<double>();
      double expectedValue = 0;

      //Act
      double actualValues = historicalManipulation.Averages(listOfValues);

      //Assert
      Assert.AreEqual(expectedValue, actualValues);
    }
    [TestMethod]
    public void Test_ListAverages_ReturnsASortedDictionary_GivenADictionaryOfAverages()
    {
      //Arrange
      Dictionary<string, double> dictionary = new Dictionary<string, double>();
      dictionary.Add("GBP", 1.43256);
      dictionary.Add("EUR", 1);
      dictionary.Add("KRN", 0.999439);
      Dictionary<string, double> expectedDictionary = new Dictionary<string, double>();
      expectedDictionary.Add("KRN", 0.999439);
      expectedDictionary.Add("EUR", 1);
      expectedDictionary.Add("GBP", 1.43256);

      //Act
      Dictionary<string, double> sortedDictionary = historicalManipulation.ListAverages(dictionary);

      //Assert
      CollectionAssert.AreEqual(expectedDictionary, sortedDictionary);
    }
    [TestMethod]
    public void Test_StrongerThanEuros_ReturnsADictionaryOfCurrencesStrongerThanEuros_GivenASortedDictionaryOfAverages()
    {
      //Arrange
      Dictionary<string, double> sortedDictionary = new Dictionary<string, double>();
      sortedDictionary.Add("USD", 0.9564);
      sortedDictionary.Add("KRN", 0.999439);
      sortedDictionary.Add("EUR", 1);
      sortedDictionary.Add("AUD", 1.22234);
      sortedDictionary.Add("YEN", 1.3);
      sortedDictionary.Add("GBP", 1.43256);
      Dictionary<string, double> expectedValue = new Dictionary<string, double>() { 
      {"AUD",1.22234} , 
      {"YEN",1.3},
      {"GBP",1.43256}
      };

      //Act
      Dictionary<string, double> actualValue = historicalManipulation.StrongerThanEuros(sortedDictionary);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_ExtremePerCurrency_ReturnsMinAndMax_WhenGivenAListOfDoubles()
    {
      //Arrange
      List<double> listOfDoubles = new List<double>() { 1.294, 0.999, 3.21, 1.2333, 0.1523324 };
      Tuple<double, double> expectedValue = new Tuple<double, double>(0.1523324, 3.21);

      //Act
      Tuple<double, double> actualValue = historicalManipulation.ExtremePerCurrency(listOfDoubles);

      //Assert
      Assert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_GreatestFluctuation_ReturnsDifference_WhenGivenTwoDoubles()
    {
      //Arrange
      double number1 = 2.3142;
      double number2 = 1.29485;
      double expectedValue = 1.01935;

      //Act
      double actualValue = historicalManipulation.GreatestFluctuation(number2, number1);
      //Assert
      Assert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_GetData_CallsOnGetHistoricalData_WhenCalled()
    {
      //Arrange

      //Act
      historicalManipulation.GetData();

      //Assert
      mockHistoricalMap.Verify(r => r.GetHistoricalData(), Times.Once);
    }
    [TestMethod]
    public void Test_GetDataCurrencyName_ReturnsListOfKey_WhenGivenDictionaryOfDictionary()
    {
      //Arrange
      Dictionary<string, double> dictionary = new Dictionary<string, double>()
      {
        {"GBP", 1.43256},
        {"EUR", 1},
        {"KRN", 0.999439}
      };
      Dictionary<string, double> differentDictionary = new Dictionary<string, double>()
      {
        {"GBP", 1.43256},
        {"YEN", 1},
        {"USD", 0.999439}
      };
      Dictionary<string, Dictionary<string, double>> returnedDictionary = new Dictionary<string, Dictionary<string, double>>()
      {
        {"ME", dictionary},
        {"WE",differentDictionary}
      };
      List<string> expectedValue = new List<string>() { "GBP", "EUR", "KRN", "YEN", "USD" };

      //Act
      List<string> actualValue = historicalManipulation.GetDataCurrencyName(returnedDictionary);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
  }
}
