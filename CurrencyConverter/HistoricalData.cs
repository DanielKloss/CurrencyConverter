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
        Dictionary<string, double> currencyRates = new Dictionary<string, double>();


        public Dictionary<string, Dictionary<string, double>> ReadXMLFile(string URL)
        {

            if (File.Exists(URL) && ReturnXmlValidity(URL))
            {
                var URLString = URL;

                XmlDocument doc = new XmlDocument();  // Creates an XmlDocumentd
                doc.Load(URLString);   // Loads an XmlDocumentd

                var dictionary = new Dictionary<string, Dictionary<string, double>>();  // This decalares the Date as the key e.g Dictionary<Date, Dictionary<USD,12.888>>

                //Console.WriteLine(doc.DocumentElement.ChildNodes[2].ChildNodes[0].InnerXml);

                int counter = doc.DocumentElement.ChildNodes[2].ChildNodes.Count;

                for (int i = 0; i < counter; i++)
                {
                    //the xmlNode gets all <Cube> within the Cube Node 
                    XmlNode DateNodes = doc.DocumentElement.ChildNodes[2].ChildNodes[i];
                    XmlAttributeCollection attcol = DateNodes.Attributes;  // Gets all attribute of Cube e.g <Cube time="....">
                    Console.WriteLine(attcol[0].Value); // extracts all the value of time for each cube e.g <cube time="2015-08-11"




                    // this foreach loop loops through each subchild within a parent node <Cube time =".....">
                    foreach (XmlNode node in DateNodes)
                    {

                        /*This line prints the currency Abbreviation and value
                         * Console.WriteLine(node.Attributes[0].Value);
                         Console.WriteLine(node.Attributes[1].Value);
                         */

                        currencyRates.Add(node.Attributes[0].Value, Convert.ToDouble(node.Attributes[1].Value));
                    }
                    dictionary.Add(attcol[0].Value, currencyRates);

                    currencyRates = new Dictionary<string, double>();
                    Console.WriteLine();
                }

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
    }
}
