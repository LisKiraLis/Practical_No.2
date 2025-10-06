using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_No._2
{
    internal class Bank
    {
        public CurrencyRate Rate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone {  get; set; }

        public Bank(CurrencyRate rate, string name, string address, string telephone)
        {
            Rate = rate;
            Name = name;
            Address = address;
            Telephone = telephone;
        }
    }
}
