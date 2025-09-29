using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_No._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CurrencyRate currencyRate = new CurrencyRate();
            List<CurrencyRate> currencyRateList = new List<CurrencyRate>();

            Console.WriteLine("Введите Y или N: ");
            string result = Console.ReadLine();
            while (result == "Y")
            {
                Console.WriteLine("Введите данные курса валют (От_куда Куда Курс Дата)");
                string resultCurrencyRate = Console.ReadLine();
                string[] resultCurrencyRateArray = resultCurrencyRate.Split(' ');
                currencyRate = new CurrencyRate
                {
                    NameFrom = resultCurrencyRateArray[0],
                    NameTo = resultCurrencyRateArray[1],
                    Course = Convert.ToDouble(resultCurrencyRateArray[2]),
                    Date = resultCurrencyRateArray[3]
                };
                currencyRateList.Add(currencyRate);

                Console.WriteLine("Введите Y или N");
                result = Console.ReadLine();
                if (result == "N")
                    break;
            }

            foreach (CurrencyRate m in currencyRateList)
            {
                Console.WriteLine($"{m.NameFrom}; {m.NameTo}; {m.Course}; {m.Date}");
            }


            Bank bank = new Bank();

            Console.WriteLine("Введите данные банка ('Наименование' 'Адрес' Телефон)");
            string resultBank = Console.ReadLine();
            string[] resultBankArray = resultBank.Split('"');
            bank = new Bank
            {
                Name = resultBankArray[1].Trim(),
                Address = resultBankArray[3].Trim(),
                Telephone = resultBankArray[4].Trim(),
            };
            Console.WriteLine($"{bank.Name}; {bank.Address}; {bank.Telephone}");
        }
    }
}
