using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyConverter
{
    class HistoricalData
    {
        Dictionary<string, double> ReadXMLFile()
        {
            String URLString = " http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml?9e7c8c96b871ab52a826945b5f275911";
            XmlTextReader reader = new XmlTextReader(URLString);
            return null;
        }
    }
}
