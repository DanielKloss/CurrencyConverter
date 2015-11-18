using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public  class HistoricalManipulation
    {
        //public abstract string Manipulation();
        // public abstract string ListM();

      public virtual double Averages(List<double> listOfValues)
      {
        if (listOfValues.Count==0)
        {
          return 0;
        }

        return listOfValues.Average();
      }

      public  void ListAverages()
      {
        List<double> listOfDoubles = new List<double>();
        double average = Averages(listOfDoubles);
      }
    }
}
