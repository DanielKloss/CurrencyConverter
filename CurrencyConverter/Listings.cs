using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
  public class Listings
  {
    public double WorkAverages(List<double> listOfValues)
    {
      if (listOfValues.Count == 0)
      {
        return 0;
      }

      return listOfValues.Average();
    }

    public virtual Dictionary<string, double> SortedAverages(Dictionary<string, double> averageDictionary)
    {
      Dictionary<string, double> sortedDictionary = new Dictionary<string, double>();
      foreach (KeyValuePair<string, double> item in averageDictionary.OrderBy(i => i.Value))
      {
        sortedDictionary.Add(item.Key, item.Value);
      }
      return sortedDictionary;
    }

    public virtual Dictionary<string, double> StrongerThanEuros(Dictionary<string, double> sortedDictionary)
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

    public virtual Dictionary<string, double> Averages(Dictionary<string, List<double>> dictionary)
    {
      Dictionary<string, double> averagesDictionary = new Dictionary<string, double>();
      foreach (string key in dictionary.Keys)
      {
        double averages = WorkAverages(dictionary[key]);
        averagesDictionary.Add(key, averages);
      }
      return averagesDictionary;
    }
  }
}
