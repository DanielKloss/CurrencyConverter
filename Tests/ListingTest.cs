using CurrencyConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
  [TestClass]
  public class ListingTest
  {
    Listings listing;
    [TestInitialize]
    public void Setup()
    {
      listing = new Listings();
    }
    [TestMethod]
    public void Test_WorkAverages_ReturnsAverageOfGivenListOfDoubles()
    {
      //Arrange
      List<double> listOfValues = new List<double>() { 3, 5, 7, 2.3, 6.2, 6.5 };
      double expectedValue = 5;

      //Act
      double actualValues = listing.WorkAverages(listOfValues);

      //Assert
      Assert.AreEqual(expectedValue, actualValues);
    }
    [TestMethod]
    public void Test_WorkAverages_Returns0WhenGivenEmptyList()
    {
      //Arrange
      List<double> listOfValues = new List<double>();
      double expectedValue = 0;

      //Act
      double actualValues = listing.WorkAverages(listOfValues);

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
      Dictionary<string, double> sortedDictionary = listing.SortDictionary(dictionary);

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
      {"USD", 0.9564} , 
      {"KRN", 0.999439},
      };

      //Act
      Dictionary<string, double> actualValue = listing.StrongerThanEuros(sortedDictionary);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_Averages_ReturnsDictionaryWithAverages_GivenDictionaryOfList()
    {
      //Arrange
      List<double> gbp = new List<double>() { 1.434, 1.543, 1.234, 0.234 };
      List<double> eur = new List<double>() { 1 };
      List<double> krn = new List<double>() { 0.999439, 0.99439, 0.2595, 1 };
      List<double> yen = new List<double>() { 1.23, 0.234, 0.3859, 0.999 };

      Dictionary<string, List<double>> dictionary = new Dictionary<string, List<double>>()
      {
        {"GBP",gbp},
        {"EUR",eur},
        {"KRN",krn},
        {"YEN",yen}
      };
      Dictionary<string, double> expectedValue = new Dictionary<string, double>()
      {
        {"GBP",1.11125},
        {"EUR",1},
        {"KRN",0.81333225},
        {"YEN",0.712225}
      };
      //Act
      Dictionary<string, double> actualValue = listing.Averages(dictionary);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
  }
}
