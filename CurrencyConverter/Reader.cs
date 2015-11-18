using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
   public interface Reader
    {

       Dictionary<string, double> ReadFromXMLFile(string URL);
     //  Dictionary<string, Dictionary<string, double>> ReadFromXMLFile(string URL);

       /*The ReadFromDailyData  method reads from the Dictionary returned from the DailyData*/
        /*public   static void ReadFromDailyData(Dictionary<string, double> dictionary)
          {
              foreach (KeyValuePair<string, double> DailyData_keyvalue in dictionary)
              {
                  Console.WriteLine("{0}       {1}",DailyData_keyvalue.Key,DailyData_keyvalue.Value);

              }
          }*/

    }
}
