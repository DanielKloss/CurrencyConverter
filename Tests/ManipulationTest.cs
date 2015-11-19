using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CurrencyConverter;
using Moq;

namespace Tests
{
  [TestClass]
  public class ManipulationTest
  {
    Manipulation manipulation;
    Mock<Listings> mockListings;
    [TestInitialize]
    public void Setup()
    {
      mockListings = new Mock<Listings>();
      manipulation = new Manipulation(mockListings.Object);
    }
    [TestMethod]
    public void Test_Extremes_ReturnsMinAndMax_WhenGivenAListOfDoubles()
    {
      //Arrange
      List<double> listOfDoubles = new List<double>() { 1.294, 0.999, 3.21, 1.2333, 0.1523324 };
      Tuple<double, double> expectedValue = new Tuple<double, double>(3.21, 0.1523324);

      //Act
      Tuple<double, double> actualValue = manipulation.Extremes(listOfDoubles);

      //Assert
      Assert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_GreatestFluctuation_ReturnsDifference_WhenGivenTwoDoubles()
    {
      //Arrange
      Tuple<double, double> numbers = new Tuple<double, double>(2.3142, 1.29485);
      double expectedValue = 1.01935;

      //Act
      double actualValue = manipulation.GreatestFluctuation(numbers);
      //Assert
      Assert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_ExtremePerCurrency_ReturnsDictionaryOfTuple_WhenGivenADictionaryOfList()
    {
      //Arrange
      List<double> gbp = new List<double>() { 1.4, 1.5, 1.6, 1.3 };
      List<double> eur = new List<double>() { 1 };
      List<double> krn = new List<double>() { 0.999439, 0.99439 };
      List<double> yen = new List<double>() { 1.23, 1.433, 3.2 };

      Dictionary<string, List<double>> data = new Dictionary<string, List<double>>()
      {
        {"GBP",gbp},
        {"EUR",eur},
        {"KRN",krn},
        {"YEN",yen}
      };
      Tuple<double, double> gbpT = new Tuple<double, double>(1.6, 1.3);
      Tuple<double, double> eurT = new Tuple<double, double>(1, 1);
      Tuple<double, double> krnT = new Tuple<double, double>(0.999439, 0.99439);
      Tuple<double, double> yenT = new Tuple<double, double>(3.2, 1.23);
      Dictionary<string, Tuple<double, double>> expectedValue = new Dictionary<string, Tuple<double, double>>()
      {
        {"GBP",gbpT},
        {"EUR",eurT},
        {"KRN",krnT},
        {"YEN",yenT}
      };

      //Act
      Dictionary<string, Tuple<double, double>> actualValue = manipulation.ExtremePerCurrency(data);

      //Assert
      Assert.AreEqual(expectedValue["GBP"], actualValue["GBP"]);
      Assert.AreEqual(expectedValue["EUR"], actualValue["EUR"]);
      Assert.AreEqual(expectedValue["KRN"], actualValue["KRN"]);
      Assert.AreEqual(expectedValue["YEN"], actualValue["YEN"]);
      CollectionAssert.AreEqual(expectedValue.Keys, actualValue.Keys);
    }
    [TestMethod]
    public void Test_GreatestFluctuationPerCurrency_ReturnsDictionaryOfDouble_WhenGivenADictionaryOfTuple()
    {
      //Arrange
      Tuple<double, double> gbpT = new Tuple<double, double>(1.6, 1.3);
      Tuple<double, double> eurT = new Tuple<double, double>(1, 1);
      Tuple<double, double> krnT = new Tuple<double, double>(0.999439, 0.99439);
      Tuple<double, double> yenT = new Tuple<double, double>(3.2, 1.23);
      Dictionary<string, Tuple<double, double>> data = new Dictionary<string, Tuple<double, double>>()
      {
        {"GBP",gbpT},
        {"EUR",eurT},
        {"KRN",krnT},
        {"YEN",yenT}
      };
      Dictionary<string, double> expectedValue = new Dictionary<string, double>()
      {
        {"GBP",0.3},
        {"EUR",0},
        {"KRN",0.005049},
        {"YEN",1.97}
      };

      //Act
      Dictionary<string, double> actualValue = manipulation.GreatestFluctuationPerCurrency(data);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_SortDictionary_ReturnsSortedDictionary_WhenGivenADictionaryOfDouble()
    {
      //Arrange
      Dictionary<string, double> expectedValue = new Dictionary<string, double>()
      {
        {"A",0},
        {"B",0.001},
        {"C",0.005049},
        {"D",0.1},
        {"E",0.3},
        {"F",0.5},
        {"G",0.5049},
        {"H",0.97},
        {"I",1},
        {"J",1.01},
        {"K",1.05049},
        {"L",1.097},
        {"M",1.3},
        {"N",1.5},
        {"O",1.5049},
        {"P",1.97}
      };

      mockListings.Setup(x => x.SortedDictionary(It.IsAny<Dictionary<string, double>>())).Returns(expectedValue);

      //Act
      Dictionary<string, double> actualValue = manipulation.SortDictionary(It.IsAny<Dictionary<string, double>>());

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_SortDictionary_CallsOnListingSortDictionary_WhenCalled()
    {
      //Arrange
      Dictionary<string, double> data = new Dictionary<string, double>()
      {
        {"C",0.005049},
        {"J",1.01},
        {"B",0.001},
        {"O",1.5049},
        {"D",0.1},
        {"E",0.3},
      };

      //Act
      manipulation.SortDictionary(data);

      //Assert
      mockListings.Verify(x => x.SortDictionary(It.IsAny<Dictionary<string, double>>()), Times.Once);
    }
    [TestMethod]
    public void Test_TenMostStable_Returns10LowestFluctuation_WhenGivenASortedDictionaryOfDouble()
    {
      //Arrange
      Dictionary<string, double> data = new Dictionary<string, double>()
      {
        {"A",0},
        {"B",0.001},
        {"C",0.005049},
        {"D",0.1},
        {"E",0.3},
        {"F",0.5},
        {"G",0.5049},
        {"H",0.97},
        {"I",1},
        {"J",1.01},
        {"K",1.05049},
        {"L",1.097},
        {"M",1.3},
        {"N",1.5},
        {"O",1.5049},
        {"P",1.97}
      };
      Dictionary<string, double> expectedValue = new Dictionary<string, double>()
      {
        {"A",0},
        {"B",0.001},
        {"C",0.005049},
        {"D",0.1},
        {"E",0.3},
        {"F",0.5},
        {"G",0.5049},
        {"H",0.97},
        {"I",1},
        {"J",1.01},
      };

      //Act
      Dictionary<string, double> actualValue = manipulation.TenMostStable(data);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
    [TestMethod]
    public void Test_TenMostStable_ReturnsDictionaryOfLength2_WhenGivenASortedDictionaryOfLength2()
    {
      //Arrange
      Dictionary<string, double> data = new Dictionary<string, double>()
      {
        {"A",0},
        {"B",0.001},
      };
      Dictionary<string, double> expectedValue = new Dictionary<string, double>()
      {
        {"A",0},
        {"B",0.001},
      };

      //Act
      Dictionary<string, double> actualValue = manipulation.TenMostStable(data);

      //Assert
      CollectionAssert.AreEqual(expectedValue, actualValue);
    }
  }
}
