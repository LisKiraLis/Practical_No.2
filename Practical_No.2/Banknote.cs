using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_No._2
{
    internal class Banknote
    {
        public CurrencyRate Rate { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }

        public Banknote(CurrencyRate rate, string color, int size)
        {
            Rate = rate; Color = color; Size = size;
        }
    }
}
