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
    Mock<Manipulation> mockManipulation;
    Mock<Listings> mockListings;
    [TestInitialize]
    public void Setup()
    {
      mockHistoricalMap = new Mock<HistoricalMap>();
      mockManipulation = new Mock<Manipulation>();
      mockListings = new Mock<Listings>();
      historicalManipulation = new HistoricalManipulation(mockHistoricalMap.Object,mockListings.Object,mockManipulation.Object);
    }
    [TestMethod]
    public void Test_GetData_CallsOnGetHistoricalData_WhenCalled()
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
        {"GBP", 1.5526},
        {"YEN", 1},
        {"USD", 0.999439}
      };
      Dictionary<string, Dictionary<string, double>> returnedDictionary = new Dictionary<string, Dictionary<string, double>>()
      {
        {"ME", dictionary},
        {"WE",differentDictionary}
      };

      mockHistoricalMap.Setup(x => x.GetHistoricalData()).Returns(returnedDictionary);
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
    [TestMethod]
    public void Test_GetDataCurrencyValue_ReturnsListOfValues_WhenGivenDictionaryOfDictionaryAndLookingValue()
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
        {"GBP", 1.5526},
        {"YEN", 1},
        {"USD", 0.999439}
      };
      Dictionary<string, Dictionary<string, double>> returnedDictionary = new Dictionary<string, Dictionary<string, double>>()
      {
        {"ME", dictionary},
        {"WE",differentDictionary}
      };
      string searchValue = "GBP";
      List<double> expectedValue = new List<double>() { 1.43256, 1.5526 };

      //Act
      List<double> actualValue = historicalManipulation.GetDataCurrencyValue(returnedDictionary, searchValue);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);

    }
    [TestMethod]
    public void Test_GetDataCurrencyValue_ReturnsListOfValues_WhenGivenDictionaryOfDictionaryAndLookingValueIgnoringNulls()
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
        {"GBP", 1.5526},
        {"YEN", 1},
        {"USD", 0.999439}
      };
      Dictionary<string, Dictionary<string, double>> returnedDictionary = new Dictionary<string, Dictionary<string, double>>()
      {
        {"ME", dictionary},
        {"WE",differentDictionary}
      };
      string searchValue = "EUR";
      List<double> expectedValue = new List<double>() { 1 };

      //Act
      List<double> actualValue = historicalManipulation.GetDataCurrencyValue(returnedDictionary, searchValue);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);

    }
    [TestMethod]
    public void Test_GetDataCurrencyDictionary_ReturnsDictionaryOfList_GivenDictionaryOfDictionary()
    {
      //Arrange
      Dictionary<string, double> dictionary = new Dictionary<string, double>()
      {
        {"GBP", 1.4},
        {"EUR", 1},
        {"KRN", 0.999439}
      };
      Dictionary<string, double> differentDictionary = new Dictionary<string, double>()
      {
        {"GBP", 1.5},
        {"YEN", 1.23},
        {"KRN", 0.99439}
      };
      Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>()
      {
        {"ME", dictionary},
        {"WE",differentDictionary}
      };
      List<double> gbp = new List<double>() { 1.4, 1.5 };
      List<double> eur = new List<double>() { 1 };
      List<double> krn = new List<double>() { 0.999439, 0.99439 };
      List<double> yen = new List<double>() { 1.23 };

      Dictionary<string, List<double>> expectedValue = new Dictionary<string, List<double>>()
      {
        {"GBP",gbp},
        {"EUR",eur},
        {"KRN",krn},
        {"YEN",yen}
      };
      //Act
      Dictionary<string, List<double>> actualValue = historicalManipulation.GetDataCurrencyDictionary(data);

      //Assert
      CollectionAssert.AreEqual(expectedValue["GBP"], actualValue["GBP"]);
      CollectionAssert.AreEqual(expectedValue["EUR"], actualValue["EUR"]);
      CollectionAssert.AreEqual(expectedValue["KRN"], actualValue["KRN"]);
      CollectionAssert.AreEqual(expectedValue["YEN"], actualValue["YEN"]);
      CollectionAssert.AreEqual(expectedValue.Keys, actualValue.Keys);
    }
    [TestMethod]
    public void Test_Listings_CallsOnAverages_WhenCalled()
    {
      //Arrange
      //Arrange
      Dictionary<string, double> dictionary = new Dictionary<string, double>()
      {
        {"GBP", 1.4},
        {"EUR", 1},
        {"KRN", 0.999439}
      };
      Dictionary<string, double> differentDictionary = new Dictionary<string, double>()
      {
        {"GBP", 1.5},
        {"YEN", 1.23},
        {"KRN", 0.99439}
      };
      Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>()
      {
        {"ME", dictionary},
        {"WE",differentDictionary}
      };

      mockHistoricalMap.Setup(x => x.GetHistoricalData()).Returns(data);

      //Act
      historicalManipulation.Listings("Averages");

      //Assert
      mockListings.Verify(x => x.Averages(It.IsAny<Dictionary<string, List<double>>>()), Times.Once);
    }
  }
}
