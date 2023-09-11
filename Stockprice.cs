using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockwatch
{
    public class Stockprice
    {
        public string Symbol { get; }
        public decimal Price { get; }

        public Stockprice(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }
    }
}
