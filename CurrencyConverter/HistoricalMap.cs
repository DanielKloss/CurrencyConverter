using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class HistoricalMap
    {
        public virtual Dictionary<string,Dictionary<string, double>> GetHistoricalData()
        {
            HistoricalData data1 = new HistoricalData();
            data1.ReadXMLFile(@"C:\Users\Tolani.Jaiye-Tikolo\Documents\C#workspace\CurrencyConverter\currencyrate90days.xml");          
          return HistoricalData.getDictionary(); 
        }
    }
}
