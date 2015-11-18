using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Converter
    {
        public bool toEuros;
        public string currency;
        public double amount;
        public double rate;
        public double convertedMoney;

        public Converter(bool ToEuros, string Currency, double Amount)
        {
            toEuros = ToEuros;
            currency = Currency.ToUpper();
            amount = Amount;
        }
        public Double GetRate()
        {
            Dictionary<string, double> rates = DailyData.GetDictionary();
          
            /*Finds rate of currency supplied from dailydictionary*/
            if (rates.ContainsKey(currency))
            {
                rate = rates[currency];
            }
            
            return rate;
        }

        public Double Convert()
        {
            if (toEuros == true)
            {
                convertedMoney = 1.00 / (amount * rate);
            }
            else
            {
                convertedMoney = amount * rate;
            }
            return convertedMoney;
        }
    }
}
