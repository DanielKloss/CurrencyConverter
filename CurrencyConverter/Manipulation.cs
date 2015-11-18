using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
  public class Manipulation
  {

    public Tuple<double, double> ExtremePerCurrency(List<double> listOfDoubles)
    {
      listOfDoubles.Sort();
      double max = listOfDoubles[0];
      double min = listOfDoubles[listOfDoubles.Count - 1];
      Tuple<double, double> maxMinTuple = new Tuple<double, double>(max, min);
      return maxMinTuple;
    }

    public double GreatestFluctuation(double number2, double number1)
    {
      double difference = Math.Abs(number1 - number2);
      return difference;
    }

    Dictionary<string, double> TenMostStable()
    {

      return null;

    }
  }
}
