namespace Stockwatch.Model
{
    public class Stockdata
    {
        public int Id { get; set; }
        public Symbol Symbol { get; set; }
        public decimal Upperlimit { get; set; }
        public decimal Lowerlimit { get; set; }
        public Stockdata(Symbol _symbol, decimal upperlimit, decimal lowerlimit)
        {
            Symbol = _symbol;
            Upperlimit = upperlimit;
            Lowerlimit = lowerlimit;
        }


    }
    public enum Symbol { Appl,IBM }

}
