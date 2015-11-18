using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
   public  class Reader
    {
        //Declare an a delegate that encapsulates the ReadXMLFile () from the DailyData
        //public delegate Dictionary<string, double>  Del (string URl);

        //Intialize this delegate
        //Del ReadXMLFileEncapsulated = DailyData.ReadXMLFile(string path);

       /*The ReadFromDailyData  method reads from the Dictionary returned from the DailyData*/
      public   static void ReadFromDailyData(Dictionary<string, double> dictionary)
        {
            foreach (KeyValuePair<string, double> DailyData_keyvalue in dictionary)
            {
                Console.WriteLine("{0}       {1}",DailyData_keyvalue.Key,DailyData_keyvalue.Value);

            }
        }
    }
}
