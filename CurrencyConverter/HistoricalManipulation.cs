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
    private Listings _listings;
    public Listings listings
    {
      get { return _listings; }
      set { _listings = value; }
    }
    private Manipulation _manipulation;
    public Manipulation manipulation
    {
      get { return _manipulation; }
      set { _manipulation = value; }
    }
    public HistoricalManipulation(HistoricalMap HistoricalMap, Listings Listings, Manipulation Manipulation)
    {
      historicalMap = HistoricalMap;
      listings = Listings;
      manipulation = Manipulation;
    }

    public Dictionary<string, double> Listings(string functionToCall)
    {
      Dictionary<string, double> returnDictionary = new Dictionary<string, double>();
      returnDictionary = listings.Averages(GetData());
      if (functionToCall != "Averages")
      {
        returnDictionary = listings.SortDictionary(returnDictionary);
        if (functionToCall == "StrongerThanEuros")
        {
          returnDictionary = listings.StrongerThanEuros(returnDictionary);
        }
      }
      foreach (KeyValuePair<string, double> dict in returnDictionary)
      {
          Console.WriteLine("{0} : {1}", dict.Key,dict.Value);
          Console.WriteLine();
      }
      return returnDictionary;
    }

    public Dictionary<string, List<double>> GetData()
    {
      Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();
      data = historicalMap.GetHistoricalData();
      Dictionary<string, List<double>> dictionary = GetDataCurrencyDictionary(data);
      return dictionary;
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

    public List<double> GetDataCurrencyValue(Dictionary<string, Dictionary<string, double>> returnedDictionary, string searchKey)
    {
      List<double> currencyValue = new List<double>();
      foreach (Dictionary<string, double> dictionary in returnedDictionary.Values)
      {
        double currentValue = 0;
        try
        {
          currentValue = dictionary[searchKey];
        }
        catch (KeyNotFoundException)
        {
          currentValue = -1.0;
        }

        if (currentValue > 0)
        {
          currencyValue.Add(currentValue);
        }
      }
      return currencyValue;
    }

    public virtual Dictionary<string, List<double>> GetDataCurrencyDictionary(Dictionary<string, Dictionary<string, double>> data)
    {
      List<string> currencyName = GetDataCurrencyName(data);
      Dictionary<string, List<double>> currencyDictionary = new Dictionary<string, List<double>>();
      foreach (string Name in currencyName)
      {
         // Console.WriteLine(Name);
        List<double> currencyValue = GetDataCurrencyValue(data, Name);
        currencyDictionary.Add(Name, currencyValue);
      }
      return currencyDictionary;
    }

    public Dictionary<string, double> Manipulation(string functionToCall)
    {
      Dictionary<string, double> returnDictionary = new Dictionary<string, double>();
      Dictionary<string, Tuple<double, double>> returnExtreme = new Dictionary<string, Tuple<double, double>>();
      returnExtreme = manipulation.ExtremePerCurrency(GetData());
      returnDictionary = manipulation.GreatestFluctuationPerCurrency(returnExtreme);
      if (functionToCall == "TenMostStable")
      {
        returnDictionary = manipulation.TenMostStable(returnDictionary);
      }
      foreach (KeyValuePair<string, double> dict in returnDictionary)
      {
          Console.WriteLine("{0} : {1}", dict.Key, dict.Value);
          Console.WriteLine();
      }
      return returnDictionary;
    }
    public Dictionary<string, Tuple<double, double>> ExtremePerCurrency()
    {
      Dictionary<string, Tuple<double, double>> returnExtreme = new Dictionary<string, Tuple<double, double>>();
      returnExtreme = manipulation.ExtremePerCurrency(GetData());

      foreach (KeyValuePair<string, Tuple<double,double>> dict in returnExtreme)
      {
          Console.WriteLine("{0} : {1}", dict.Key, dict.Value);
          Console.WriteLine();
      }
        return returnExtreme;
    }
  }
}
