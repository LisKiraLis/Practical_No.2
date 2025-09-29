using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_No._2
{
    internal class TypedCurrencyRate
    {
        public CurrencyRate Rate { get; set; }
        public string OperationType { get; set; } // Покупка, продажа, конверсия
        public string RateCategory { get; set; } // Наличный, безналичный, карточный
    }
}
