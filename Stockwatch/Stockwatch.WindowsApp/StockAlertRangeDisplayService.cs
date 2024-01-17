using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;
using System.Xml.Linq;

namespace Stockwatch.WindowsApp
{
    public interface IStockAlertRangeDisplayService
    {
        public Task<StockAlertRangeDisplay> GetStockAlertRangeAsync(StockAlertRange stockAlertRange);
    }

    public class StockAlertRangeDisplayService:IStockAlertRangeDisplayService
    {
        private IStockPriceService _stockPriceUpdates;

        public StockAlertRangeDisplayService(IStockPriceService stockPriceUpdates)
        {
            _stockPriceUpdates = stockPriceUpdates;
        }

        public async Task<StockAlertRangeDisplay> GetStockAlertRangeAsync(StockAlertRange stockAlertRange)
        {
            var stockCurrentPrice = new IntraStockPrice { GlobalQuote = new GlobalQuote() { Price = 50 } }; //await _stockPriceUpdates.GetCurrentPriceAsync(stockAlertRange.StockSymbol);
            var stockAlertRangeDisplay = new StockAlertRangeDisplay();
            stockAlertRangeDisplay.UpperLimit = stockAlertRange.UpperLimit;
            stockAlertRangeDisplay.LowerLimit = stockAlertRange.LowerLimit;
            stockAlertRangeDisplay.SymbolId = stockAlertRange.StockSymbol.Id;
            stockAlertRangeDisplay.CurrentPrice = stockCurrentPrice.GlobalQuote.Price;
            stockAlertRangeDisplay.Comments = _stockPriceUpdates.GetComments(stockCurrentPrice, stockAlertRange);
            
            return stockAlertRangeDisplay;
        }
    }
}
