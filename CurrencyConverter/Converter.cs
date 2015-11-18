using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Converter
    {
        bool toEuros;
        string currency;
        double amount;
        double rate;
        double convertedMoney;

        public Converter(bool ToEuros, string Currency, double Amount)
        {
            toEuros = ToEuros;
            currency = Currency;
            amount = Amount;
        }
        Double GetRate()
        {
            //Here we would put DailyData.GetDictionary & then a foreach loop where it compares the
            //currency code with the key of the Dictionary returning the value associated
            //with that key
            //Dictionary rates(currencyCode, rateVal) = DailyData.GetDictionary();
            //foreach (currencyCode in rates){
            //  if (currencyCode == currency){
            //      return rateVal;
            //  }
            //rate = rateVal;
            return rate;
        }

        Double Convert()
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
