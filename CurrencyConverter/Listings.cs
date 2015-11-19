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

    public virtual Dictionary<string, double> SortDictionary(Dictionary<string, double> dictionaryToSort)
    {
      Dictionary<string, double> sortedDictionary = new Dictionary<string, double>();
      foreach (KeyValuePair<string, double> item in dictionaryToSort.OrderBy(i => i.Value))
      {
        sortedDictionary.Add(item.Key, item.Value);
      }
      return sortedDictionary;
    }

    public virtual Dictionary<string, double> StrongerThanEuros(Dictionary<string, double> sortedDictionary)
    {
            List<string> strongerThanEurosList = new List<string>();
      Dictionary<string, double> strongerThanEurosDictionary = new Dictionary<string, double>();

            foreach (string key in sortedDictionary.Keys)
            {
                if (sortedDictionary[key] < 1)
      {
        strongerThanEurosDictionary.Add(key, sortedDictionary[key]);
      }
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
