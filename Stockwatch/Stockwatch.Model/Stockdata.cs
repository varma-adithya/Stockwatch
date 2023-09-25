namespace Stockwatch.Model
{
    public class StockData
    {
        public int Id { get; set; }
        public int SymbolId { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal LowerLimit { get; set; }
        public StockSymbol StockSymbol { get; set; }

    }

}
