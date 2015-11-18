using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CurrencyConverter;

namespace Tests
{
  [TestClass]
  public class ManipulationTest
  {
    Manipulation manipulation;
    [TestInitialize]
    public void Setup()
    {
      manipulation = new Manipulation();
    }
    [TestMethod]
    public void Test_ExtremePerCurrency_ReturnsMinAndMax_WhenGivenAListOfDoubles()
    {
      //Arrange
      List<double> listOfDoubles = new List<double>() { 1.294, 0.999, 3.21, 1.2333, 0.1523324 };
      Tuple<double, double> expectedValue = new Tuple<double, double>(0.1523324, 3.21);

      //Act
      Tuple<double, double> actualValue = manipulation.ExtremePerCurrency(listOfDoubles);

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
      double actualValue = manipulation.GreatestFluctuation(number2, number1);
      //Assert
      Assert.AreEqual(expectedValue, actualValue);
    }
  }
}
