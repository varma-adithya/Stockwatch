namespace Stockwatch.Model
{
    public class StockAlertRange
    {
        public int Id { get; set; }
        public int StockSymbolId { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal LowerLimit { get; set; }

        public virtual StockSymbol StockSymbol { get; set; }

    }

}
