namespace Stockwatch.Model
{
    public class StockAlertRangeDisplay
    {
        public decimal UpperLimit { get; set; }
        public decimal LowerLimit { get; set; }
        public string SymbolName { get; set; }
        public decimal CurrentPrice {  get; set; }
        public string Comments { get; set; }

    }
}
