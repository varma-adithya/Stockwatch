namespace Stockwatch.Model
{
    public class Stockdata
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public decimal Upperlimit { get; set; }
        public decimal Lowerlimit { get; set; }
        public Stockdata(string symbol, decimal upperlimit, decimal lowerlimit)
        {
            Symbol = symbol;
            Upperlimit = upperlimit;
            Lowerlimit = lowerlimit;
        }

    }
}
