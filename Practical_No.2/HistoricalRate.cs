using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_No._2
{
    internal class HistoricalRate
    {
        public CurrencyRate Rate { get; set; }
        public double Change24h { get; set; } // Изменение за 24 часа
        public double Change7d { get; set; }
        public double Volatility { get; set; } // Волатильность
    }
}
