using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace CurrencyConverter
{
    class ApplicationStart
    {
        public static void Main(string[] args)
        {
          /*  HistoricalData data1 = new HistoricalData();
         
            data1.ReadXMLFile(@"C:\Users\Tolani.Jaiye-Tikolo\Documents\C#workspace\CurrencyConverter\currencyrate90days.xml");
           
            */
            string path = @"C:\Users\Tolani.Jaiye-Tikolo\Documents\C#workspace\CurrencyConverter\eurofxref-daily.xml";
           Dictionary<string,double> dictionary = DailyData.ReadXMLFile(path);
           Reader.ReadFromDailyData(dictionary);
          
            

            Console.ReadLine();
        }
    }
}
