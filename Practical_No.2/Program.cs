using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Practical_No._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CurrencyRate> rates = new List<CurrencyRate>();

            string[] filePath = File.ReadAllLines("TestInputData.txt");
            FillingInRatesFromFile();

            foreach (CurrencyRate rate in rates)
            {
                RateSelectionMenu(rate);
            }

            void RateSelectionMenu(CurrencyRate rate)
            {
                Console.WriteLine(
                    $"Хотители добавить дополнительную информацию к CurrencyRate " +
                    $"{rate.NameTo}-{rate.NameFrom}? (Yes / No)");
                var result = Console.ReadLine();
                if (result == "Yes")
                {
                    AddRateToOutputFile(rate);
                    AdditionalPropertiesSelectionMenu(rate);
                }
                else if (result != "No") Console.WriteLine("Получены некорректные данные");
            }

            void AdditionalPropertiesSelectionMenu(CurrencyRate rate)
            {
                AddBank(rate);
                AddTypedCurrencyRate(rate);
                AddHistoricalRate(rate);
                AddBanknote(rate);
            }

            void FillingInRatesFromFile()
            {
                int numbarCurrencyRate = Convert.ToInt32(filePath.First());
                for (int i = 1; i < numbarCurrencyRate+1; i++)
                {
                    var rateData = filePath[i].Split(';');
                    CurrencyRate rate = new CurrencyRate(rateData[0], rateData[1], Convert.ToDouble(rateData[2]), rateData[3]);
                    rates.Add(rate);
                }
            }

            void AddBank(CurrencyRate rate)
            {
                Console.WriteLine("Хотители добавить определенный Bank к данному CurrencyRate? (Yes / No)");
                string selectedResponse = Console.ReadLine();
                switch (selectedResponse)
                {
                    case "Yes":
                        Console.WriteLine("Введите данные Bank (название; адресс; телефон)");
                        string result = Console.ReadLine();
                        var bankData = result
                            .Split(';')
                            .Select(s => s.Replace(" ", ""))
                            .ToArray();
                        Bank bank = new Bank(rate, bankData[0], bankData[1], bankData[2]);
                        AddBankToOutputFile(bank);
                        break;
                    case "No": break;
                    default:
                        Console.WriteLine("Получены некорректные данные");
                        break;
                }
            }

            void AddTypedCurrencyRate(CurrencyRate rate)
            {
                Console.WriteLine("Хотители добавить определенный TypedCurrencyRate к данному CurrencyRate? (Yes / No)");
                string selectedResponse = Console.ReadLine();
                switch (selectedResponse)
                {
                    case "Yes":
                        Console.WriteLine("Введите данные TypedCurrencyRate (тип операции; категория валюты)");
                        string result = Console.ReadLine();
                        var typedCurrencyRateData = result
                            .Split(';')
                            .Select(s => s.Replace(" ", ""))
                            .ToArray();
                        TypedCurrencyRate typedCurrencyRate = new TypedCurrencyRate(rate, typedCurrencyRateData[0], typedCurrencyRateData[1]);
                        AddTypedCurrencyRateToOutputFile(typedCurrencyRate);
                        break;
                    case "No": break;
                    default:
                        Console.WriteLine("Получены некорректные данные");
                        break;
                }
            }

            void AddHistoricalRate(CurrencyRate rate)
            {
                Console.WriteLine("Хотители добавить определенный HistoricalRate к данному CurrencyRate? (Yes / No)");
                string selectedResponse = Console.ReadLine();
                switch (selectedResponse)
                {
                    case "Yes":
                        Console.WriteLine("Введите данные HistoricalRate (изменение за 24ч; изменение за 7д; волатильность)");
                        string result = Console.ReadLine();
                        double[] historicalRatesData = result
                            .Split(';')
                            .Select(s => Convert.ToDouble(s.Replace(" ", "")))
                            .ToArray();
                        HistoricalRate historicalRate = new HistoricalRate(rate, historicalRatesData[0], historicalRatesData[1], historicalRatesData[2]);
                        AddHistoricalRateToOutputFile(historicalRate);
                        break;
                    case "No": break;
                    default:
                        Console.WriteLine("Получены некорректные данные");
                        break;
                }
            }

            void AddRateToOutputFile(CurrencyRate rate)
            {
                string result =
                    $"NameFrom: {rate.NameFrom} \n" +
                    $"NameTo: {rate.NameTo} \n" +
                    $"Course: {rate.Course} \n" +
                    $"Date: {rate.Date}";
                using (StreamWriter writer = new StreamWriter("TestOutputData.txt", true))
                {
                    writer.WriteLine(result);
                }
            }

            void AddBankToOutputFile(Bank bank)
            {
                string result =
                    $"Name: {bank.Name} \n" +
                    $"Address: {bank.Address} \n" +
                    $"Course: {bank.Telephone}";
                using (StreamWriter writer = new StreamWriter("TestOutputData.txt", true))
                {
                    writer.WriteLine(result);
                }
            }

            void AddTypedCurrencyRateToOutputFile(TypedCurrencyRate typedCurrencyRate)
            {
                string result =
                    $"OperationType: {typedCurrencyRate.OperationType} \n" +
                    $"RateCategory: {typedCurrencyRate.RateCategory}";
                using (StreamWriter writer = new StreamWriter("TestOutputData.txt", true))
                {
                    writer.WriteLine(result);
                }
            }

            void AddHistoricalRateToOutputFile(HistoricalRate historicalRate)
            {
                string result =
                    $"Change24h: {historicalRate.Change24h} \n" +
                    $"Change7d: {historicalRate.Change7d} \n" +
                    $"Volatility: {historicalRate.Volatility}";
                using (StreamWriter writer = new StreamWriter("TestOutputData.txt", true))
                {
                    writer.WriteLine(result);
                }
            }


            void AddBanknote(CurrencyRate rate)
            {
                Console.WriteLine("Хотители добавить определенный Banknote к данному CurrencyRate? (Yes / No)");
                string selectedResponse = Console.ReadLine();
                switch (selectedResponse)
                {
                    case "Yes":
                        Console.WriteLine("Введите данные Banknote (цвет; размер)");
                        string result = Console.ReadLine();
                        var banknoteData = result
                            .Split(';')
                            .Select(s => s.Replace(" ", ""))
                            .ToArray();
                        Banknote banknote = new Banknote(rate, banknoteData[0], Convert.ToInt32(banknoteData[1]));
                        AddBanknoteToOutputFile(banknote);
                        break;
                    case "No": break;
                    default:
                        Console.WriteLine("Получены некорректные данные");
                        break;
                }
            }

            void AddBanknoteToOutputFile(Banknote banknote)
            {
                string result =
                    $"Color: {banknote.Color} \n" +
                    $"Size: {banknote.Size}";
                using (StreamWriter writer = new StreamWriter("TestOutputData.txt", true))
                {
                    writer.WriteLine(result);
                }
            }
        }
    }
}
