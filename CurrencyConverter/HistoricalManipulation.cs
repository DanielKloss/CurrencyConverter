using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
  public class HistoricalManipulation
  {
    private HistoricalMap _historicalMap;
    public HistoricalMap historicalMap
    {
      get { return _historicalMap; }
      set { _historicalMap = value; }
    }

    public HistoricalManipulation(HistoricalMap HistoricalMap)
    {
      historicalMap = HistoricalMap;
    }
    public double Averages(List<double> listOfValues)
    {
      if (listOfValues.Count == 0)
      {
        return 0;
      }

      return listOfValues.Average();
    }

    public Dictionary<string, double> ListAverages(Dictionary<string, double> averageDictionary)
    {
      Dictionary<string, double> sortedDictionary = new Dictionary<string, double>();
      foreach (KeyValuePair<string, double> item in averageDictionary.OrderBy(i => i.Value))
      {
        sortedDictionary.Add(item.Key, item.Value);
      }
      return sortedDictionary;
    }

    public Dictionary<string, double> StrongerThanEuros(Dictionary<string, double> sortedDictionary)
    {
      List<string> strongerThanEurosList = sortedDictionary.Keys.ToList();
      Dictionary<string, double> strongerThanEurosDictionary = new Dictionary<string, double>();

      int euroIndex = strongerThanEurosList.IndexOf("EUR");
      strongerThanEurosList.RemoveRange(0, euroIndex + 1);

      foreach (string key in strongerThanEurosList)
      {
        strongerThanEurosDictionary.Add(key, sortedDictionary[key]);
      }

      return strongerThanEurosDictionary;
    }

    public Tuple<double, double> ExtremePerCurrency(List<double> listOfDoubles)
    {
      listOfDoubles.Sort();
      double max = listOfDoubles[0];
      double min = listOfDoubles[listOfDoubles.Count - 1];
      Tuple<double, double> maxMinTuple = new Tuple<double, double>(max, min);
      return maxMinTuple;
    }

    public void GetData()
    {
      Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();
      data = historicalMap.GetHistoricalData();
    }

    public List<string> GetDataCurrencyName(Dictionary<string, Dictionary<string, double>> returnedDictionary)
    {
      List<string> currencyName = new List<string>();
      foreach (Dictionary<string, double> dictionary in returnedDictionary.Values)
      {
        foreach (string key in dictionary.Keys)
        {
          if (!currencyName.Contains(key))
          {
            currencyName.Add(key);
          }
        }
      }
      return currencyName;
    }

    public double GreatestFluctuation(double number2, double number1)
    {
      double difference = Math.Abs(number1 - number2);
      return difference;
    }
  }
}
