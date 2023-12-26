using Stockwatch.Business;
using Stockwatch.Model;
using System.Xml.Linq;

namespace Stockwatch.WindowsApp
{
    public interface IStockAlertRangeDisplayService
    {
        public Task<StockAlertRangeDisplay> GetStockAlertRangeAsync(StockAlertRange stockAlertRange);
    }

    public class StockAlertRangeDisplayService:IStockAlertRangeDisplayService
    {
        private IStockPriceUpdates _stockPriceUpdates;

        public StockAlertRangeDisplayService(IStockPriceUpdates stockPriceUpdates, IStockSymbolPage stockSymbolPage, IStockAlertRangeService dataservice)
        {
            _stockPriceUpdates = stockPriceUpdates;
        }

        public async Task<StockAlertRangeDisplay> GetStockAlertRangeAsync(StockAlertRange stockAlertRange)
        {
            var stockCurrentPrice = await _stockPriceUpdates.GetCurrentPriceAsync(stockAlertRange.StockSymbol);
            var stockAlertRangeDisplay = new StockAlertRangeDisplay();
            stockAlertRangeDisplay.UpperLimit = stockAlertRange.UpperLimit;
            stockAlertRangeDisplay.LowerLimit = stockAlertRange.LowerLimit;
            stockAlertRangeDisplay.StockSymbolName = stockAlertRange.StockSymbol.SymbolName;
            stockAlertRangeDisplay.CurrentPrice = stockCurrentPrice.GlobalQuote.Price;
            stockAlertRangeDisplay.Comments = _stockPriceUpdates.GetComments(stockCurrentPrice, stockAlertRange);
            
            return stockAlertRangeDisplay;
        }
    }
}
