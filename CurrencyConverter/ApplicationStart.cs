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

        static void getDataForConverter(bool toEuro)
        {
            string convertTo;
            Console.WriteLine(Environment.NewLine);
            foreach (KeyValuePair<string, double> value in DailyData.dictionaryMetaDaily) Console.WriteLine(value.Key);
            Console.WriteLine("Please choose a non-Euro currency from the list above.");
            string currency = Console.ReadLine();
            Console.WriteLine("OK! Please type in the amount you would like to convert (numbers only please!)");
            double amount = Convert.ToDouble(Console.ReadLine());
            Converter converter = new Converter(toEuro, currency, amount);
            converter.GetRate();
            Console.WriteLine(Environment.NewLine);
            if(toEuro == true)
            {
                convertTo = "to";
            }
            else
            {
                convertTo = "from";
            }
           Console.Write("Result of converting "+ currency + " " + convertTo +" Euros is " + converter.Convert());
          //  Console.ReadLine();
            
        }

       // static void  

        public static void Main(string[] args)
        {
           /* HistoricalData data1 = new HistoricalData();
         
            data1.ReadXMLFile(@"C:\Users\Tolani.Jaiye-Tikolo\Documents\C#workspace\CurrencyConverter\currencyrate90days.xml");*/
           
            
            string path = @"C:\Users\Tolani.Jaiye-Tikolo\Documents\C#workspace\CurrencyConverter\eurofxref-daily.xml";
            Dictionary<string, double> dictionary = DailyData.ReadXMLFile(path);


            /*Creating the  User Interface for the Application*/
            Console.Title = "Currency Conversion Application---> Group Red";
            Console.WriteLine("Enter your  ID e.g Name");
            string reply = Console.ReadLine();
 
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome to team RED's awesome currency converter," + " "+reply + "! Please mind the bugs.");
            Console.ResetColor();


            //This line displays options for the User
            Console.WriteLine("*******************************************************************************");
         LabelWord: Console.WriteLine("A. Convert Any Currency to Euro");
            Console.WriteLine("B. Convert Euro to another  Currency");
            Console.WriteLine("C. Display the History of the Last 90 Days");

            //Retrieves user Input
            string answerOption = Console.ReadLine();
          //  while(answerOption.GetType() == 'c'.GetType()){
        //        char answerOption2 = Convert.ToChar(answerOption);
               //}
            switch (Convert.ToChar(answerOption))
            {
                case 'A': getDataForConverter(true); break;
                case 'B': getDataForConverter(false); break;
                case 'C': break;
                default: Console.WriteLine(); Console.WriteLine("Enter appropriate Option"); goto LabelWord;
                 
            }

            Console.ReadLine();
        }
    }
}
