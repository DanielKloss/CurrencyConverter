using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyConverter
{
    class DailyData
    {

      public static Dictionary<string, double> dictionaryMetaDaily;
        
       public static Dictionary<string, double> ReadXMLFile(string URL)
        {
            String URLString = URL;

            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);
            int counter = doc.DocumentElement.ChildNodes[2].ChildNodes.Count;

            Dictionary<string, double> dailyDictionary = new Dictionary<string, double>();

            for (int i = 0; i < counter; i++)
            {
                XmlNode childNode = doc.DocumentElement.ChildNodes[2].ChildNodes[i];
                foreach (XmlNode node in childNode)
                {
                    dailyDictionary.Add(node.Attributes[0].Value.ToString(), Convert.ToDouble(node.Attributes[1].Value));
                }
            }
            dictionaryMetaDaily = dailyDictionary;
            return dictionaryMetaDaily;
        }
       public static Dictionary<string, double> GetDictionary()
       {
           return dictionaryMetaDaily;
       }
    }
}
