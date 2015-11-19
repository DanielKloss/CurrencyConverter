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
                string currency = Console.ReadLine();
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
           /* HistoricalData data1 = new HistoricalData();
         
            data1.ReadXMLFile(@"C:\Users\Tolani.Jaiye-Tikolo\Documents\C#workspace\CurrencyConverter\currencyrate90days.xml");*/
           
            
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


            //This line displays options for the User
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\n");
         LabelWord: Console.WriteLine("A. Convert Any Currency to Euro");
            Console.WriteLine("B. Convert Euro to another  Currency");
            Console.WriteLine("C. Display the History of the Last 90 Days");

            //Retrieves user Input
            string answerOption = Console.ReadLine();
          //  while(answerOption.GetType() == 'c'.GetType()){
        //        
               //}
           try { 
            char answerOption2 = Convert.ToChar(answerOption);
            
            
            switch (answerOption2)
            {
                case 'A': getDataForConverter(true); LeaveLoop(); break;
                case 'B': getDataForConverter(false); LeaveLoop(); break;
                case 'C': Console.WriteLine("Sorry, we don't have this yet!"); LeaveLoop(); break;
                default: Console.WriteLine(); Console.WriteLine("Enter appropriate Option"); goto LabelWord;
                 
            }
            }
           catch (FormatException ex)
           {
               Console.WriteLine("Error with Input parameter:  "+ex.Message);
               goto LabelWord;
           }
          

            Console.ReadLine();
        }
    }
}
