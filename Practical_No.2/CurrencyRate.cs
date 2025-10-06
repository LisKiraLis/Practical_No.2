using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_No._2
{
    internal class CurrencyRate
    {
        public string NameFrom { get; set; }
        public string NameTo { get; set; }
        public double Course { get; set; }
        public string Date { get; set; }

        public CurrencyRate(string nameFrom, string nameTo, double course, string data)
        {
            NameFrom = nameFrom;
            NameTo = nameTo;
            Course = course;
            Date = data;
        }
    }
}
