using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using System.IO;
namespace CurrencyConverter
{
    public class HistoricalData
    {
        // CurrencyRates dictionary stores the Currency and Value before it is passed to the 
        //outer dictionary
        Dictionary<string, double> currencyRates = new Dictionary<string, double>();

       static Dictionary<string, Dictionary<string, double>> HandlerForGetDictionary = new Dictionary<string, Dictionary<string, double>>();

        public Dictionary<string, Dictionary<string, double>> ReadXMLFile(string URL)
        {

            if (File.Exists(URL) && ReturnXmlValidity(URL))
            {
                var URLString = URL;

                XmlDocument doc = new XmlDocument();  // Creates an XmlDocumentd
                doc.Load(URLString);   // Loads an XmlDocumentd

                var dictionary = new Dictionary<string, Dictionary<string, double>>();  // This decalares the Date as the key e.g Dictionary<Date, Dictionary<USD,12.888>>

                int counter = doc.DocumentElement.ChildNodes[2].ChildNodes.Count;

                for (int i = 0; i < counter; i++)
                {
                    //the xmlNode gets all <Cube> within the Cube Node 
                    XmlNode DateNodes = doc.DocumentElement.ChildNodes[2].ChildNodes[i];
                    XmlAttributeCollection attcol = DateNodes.Attributes;  // Gets all attribute of Cube e.g <Cube time="....">

                    // this foreach loop loops through each subchild within a parent node <Cube time =".....">
                    foreach (XmlNode node in DateNodes)
                    {
                        currencyRates.Add(node.Attributes[0].Value, Convert.ToDouble(node.Attributes[1].Value));
                    }
                    dictionary.Add(attcol[0].Value, currencyRates);

                    currencyRates = new Dictionary<string, double>();
                }
                HandlerForGetDictionary = dictionary;
                return dictionary;
            }
            else
            {
                Console.WriteLine("Error: The file does not exist");
                return null;
            }
        }


        public static bool ReturnXmlValidity(string value)
        {
            if (value.EndsWith("xml"))
            {
                return true;
            }
            else return false;
        }

        public static Dictionary<string, Dictionary<string, double>> getDictionary()
        {
            return HandlerForGetDictionary;
        }
    }
}
