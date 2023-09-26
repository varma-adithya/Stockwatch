namespace Stockwatch.Model
{
    public class Stockdata
    {
        public int Id { get; set; }
        public int SymbolId { get; set; }
        public decimal Upperlimit { get; set; }
        public decimal Lowerlimit { get; set; }
        public Stocksymbol Stocksymbol { get; set; }

    }

}
