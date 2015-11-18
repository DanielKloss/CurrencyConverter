using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyConverter
{
  public  class HistoricalData
    {
       public  Dictionary<string, Dictionary<string, double>> ReadXMLFile(string URL)
        {
            String URLString = URL;

            XmlDocument doc = new XmlDocument();
            doc.Load(URLString);

            Dictionary<string, Dictionary<string, double>> dictionary =
                new Dictionary<string, Dictionary<string, double>>();

            //Console.WriteLine(doc.DocumentElement.ChildNodes[2].ChildNodes[0].InnerXml);

            int counter = doc.DocumentElement.ChildNodes[2].ChildNodes.Count;
            
            for (int i = 0; i < counter; i++)
            {
                XmlNode DateNodes = doc.DocumentElement.ChildNodes[2].ChildNodes[i];
                XmlAttributeCollection attcol = DateNodes.Attributes;
                Console.WriteLine(attcol[0].Value);

                Dictionary<string, double> CurrencyRates ;
            
                foreach (XmlNode node in DateNodes) 
                {

                   Console.WriteLine(node.Attributes[0].Value);
                   Console.WriteLine(node.Attributes[1].Value);

                   CurrencyRates = new Dictionary<string, double>();
                   CurrencyRates.Add(node.Attributes[0].Value,Convert.ToDouble(node.Attributes[1].Value));

                   dictionary.Add(attcol[0].Value,CurrencyRates);
                  
                }
                CurrencyRates = null;
                Console.WriteLine();
            }

            return dictionary;
        }
    }
}
