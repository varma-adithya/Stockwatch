﻿namespace Stockwatch.Model
{
    public class StockAlertRangeDisplay
    {
        public int StockAlertRangeId { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal LowerLimit { get; set; }
        public int SymbolId { get; set; }
        public decimal CurrentPrice {  get; set; }
        public string Comments { get; set; }

    }
}
