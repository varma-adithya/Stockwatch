namespace Stockwatch
{
    public class Stockdata
    {
        public string Symbol { get; }
        public decimal Price { get; }

        public Stockdata(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }

    }
}
