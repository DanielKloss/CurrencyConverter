using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
  public class Manipulation
  {
    private Listings _listings;
    public Listings listings
    {
      get { return _listings; }
      set { _listings = value; }
    }

    public Manipulation(Listings Listings)
    {
      listings = Listings;
    }

    public Tuple<double, double> Extremes(List<double> listOfDoubles)
    {
      listOfDoubles.Sort();
      double min = listOfDoubles[0];
      double max = listOfDoubles[listOfDoubles.Count - 1];
      Tuple<double, double> maxMinTuple = new Tuple<double, double>(max, min);
      return maxMinTuple;
    }

    public double GreatestFluctuation(Tuple<double, double> maxMinTuple)
    {

      double difference = Math.Abs(maxMinTuple.Item1 - maxMinTuple.Item2);
      difference = Math.Round(difference, 10);
      return difference;
    }

    public Dictionary<string, double> SortDictionary(Dictionary<string, double> data)
    {
      Dictionary<string, double> sortedDictionary = listings.SortDictionary(data);
      return sortedDictionary;
    }

    public virtual Dictionary<string, Tuple<double, double>> ExtremePerCurrency(Dictionary<string, List<double>> data)
    {
      Dictionary<string, Tuple<double, double>> extremeDictionary = new Dictionary<string, Tuple<double, double>>();

      foreach (string key in data.Keys)
      {
        Tuple<double, double> maxMinTuple = Extremes(data[key]);
        extremeDictionary.Add(key, maxMinTuple);
      }

      return extremeDictionary;
    }

    public virtual Dictionary<string, double> GreatestFluctuationPerCurrency(Dictionary<string, Tuple<double, double>> data)
    {
      Dictionary<string, double> fluctuationDictionary = new Dictionary<string, double>();
      foreach (string key in data.Keys)
      {
        double fluctuation = GreatestFluctuation(data[key]);
        fluctuationDictionary.Add(key, fluctuation);
      }
      return fluctuationDictionary;
    }

    public virtual Dictionary<string, double> TenMostStable(Dictionary<string, double> sortedDictionary)
    {
      List<string> tenMostStableList = sortedDictionary.Keys.ToList();
      Dictionary<string, double> tenMostStableDictionary = new Dictionary<string, double>();
      int minStart = Math.Min(10, tenMostStableList.Count);

      tenMostStableList.RemoveRange(minStart, tenMostStableList.Count - minStart);

      foreach (string key in tenMostStableList)
      {
        tenMostStableDictionary.Add(key, sortedDictionary[key]);
      }

      return tenMostStableDictionary;

    }
  }
}
