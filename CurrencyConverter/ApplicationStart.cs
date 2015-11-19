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
         PrintDictionary:   foreach (KeyValuePair<string, double> value in DailyData.dictionaryMetaDaily) Console.WriteLine(value.Key);
         
             
                Console.WriteLine("Please choose a non-Euro currency from the list above.");
                string currency = Console.ReadLine().ToUpper();
                if (!DailyData.dictionaryMetaDaily.ContainsKey(currency))
                {
                    Console.WriteLine("I'm sorry, the currency you input is not on our records.");
                    Console.WriteLine("Please reference the list and try again. Thank you!");
                    Console.WriteLine("Hit enter to continue.");
                    Console.ReadLine();
                    goto PrintDictionary;
                }
         
              ArgumentValidation:  Console.WriteLine("OK! Please type in the amount you would like to convert (numbers only please!)");
             //   double amount = Convert.ToDouble(Console.ReadLine());
                   double amount;
                   bool returnResult = Double.TryParse(Console.ReadLine(), out amount);
                   if (returnResult)
                   {
                       Converter converter = new Converter(toEuro, currency, amount);
                       converter.GetRate();
                       Console.WriteLine(Environment.NewLine);
                       if (toEuro == true)
                       {
                           convertTo = "to";
                       }
                       else
                       {
                           convertTo = "from";
                       }
                       Console.WriteLine("Result of converting " + currency + " " + convertTo + " Euros is " + Math.Round(converter.Convert(),3));
                   }
                   else
                   {
                       Console.WriteLine("Argument Passed is not valid");
                       goto ArgumentValidation;
                   }
                
                //  Console.ReadLine();

         
        }

        static void LeaveLoop()
            {
               Console.WriteLine("Would you like to exit the Application? Y/N");
               char reply = Convert.ToChar(Console.ReadLine());
               if (reply == 'Y' || reply == 'y')
               {
                   Environment.Exit(0);
               }
               else
               {
                   Console.WriteLine("Select One of our options ");
                   Console.Clear();
                   ApplicationStart.Main(new String [] { ""});
               }

            }
       // static void  

        public static void Main(string[] args)
        {
               
            string path = @"C:\Users\Tolani.Jaiye-Tikolo\Documents\C#workspace\CurrencyConverter\eurofxref-daily.xml";
            Dictionary<string, double> dictionary = DailyData.ReadXMLFile(path);


            /*Creating the  User Interface for the Application*/
            Console.Title = "Currency Conversion Application---> Group Red";
            Console.WriteLine("Enter your  ID e.g Name");
            string reply = Console.ReadLine();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome to team RED's awesome currency converter," + " "+reply + "! Please mind the bugs.");
            Console.ResetColor();
            Console.WriteLine("\n");


            //This line changes the background of the Username
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\n");

            //This section displays options to the User
         LabelWord: Console.WriteLine("A. Convert Any Currency to Euro");
            Console.WriteLine("B. Convert Euro to another  Currency");
            Console.WriteLine("C. Average rate for each currency, for the last 90 days");
            Console.WriteLine("D. Sorted Average rate for each currency, for the last 90 days");
            Console.WriteLine("E. Display the Currencies that are stronger than Euro");

            //Instantiate the Listings class
          
            HistoricalMap map = new HistoricalMap();
            Listings newList = new Listings();
            Manipulation manipulate = new Manipulation();
            HistoricalManipulation manipulateHistory = new HistoricalManipulation(map, newList,manipulate);


            //Retrieves user Input
            string answerOption = Console.ReadLine();

           try { 
            char answerOption2 = Convert.ToChar(answerOption);
            
            // iterates over all the user options to execute the Data
            switch (Char.ToUpper(answerOption2))
            {
                case 'A': getDataForConverter(true); LeaveLoop(); break;
                case 'B': getDataForConverter(false); LeaveLoop(); break;
                case 'C': Console.WriteLine("************"); manipulateHistory.Listings("Averages"); LeaveLoop(); break;
                case 'D': Console.WriteLine("************"); manipulateHistory.Listings("SortedAverages"); LeaveLoop(); break;
                case 'E': Console.WriteLine("************"); manipulateHistory.Listings("StrongerThanEuros"); LeaveLoop(); break;
                default: Console.WriteLine(); Console.WriteLine("Enter appropriate Option"); goto LabelWord;
                 
            }
            }
           catch (FormatException ex)
           {
               Console.WriteLine("Error with Input parameter:  " +ex.Message);
               goto LabelWord;
           }
          

            Console.ReadLine();
        }
    }
}
