using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

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

        public string GetComments(IntraStockPrice currentPrice, StockAlertRange stockAlertRange)
        {
            if (currentPrice?.GlobalQuote.Price >= stockAlertRange?.UpperLimit)
            {
                return "Stock Price Surge! " + currentPrice.GlobalQuote.Symbol + " stock price value has surged above the Upper Limit";
            }
            else if (currentPrice?.GlobalQuote.Price <= stockAlertRange?.LowerLimit)
            {
                return "Stock Price Fall! " + currentPrice.GlobalQuote.Symbol + " stock price value has fallen below the Lower Limit";
            }
            else
            {
                return "Stock in range";
            }
        }

        public async Task<StockAlertRangeDisplay> GetStockAlertRangeAsync(StockAlertRange stockAlertRange)
        {
            var stockCurrentPrice = await _stockPriceUpdates.GetStockPriceAsync(stockAlertRange.StockSymbol); //new IntraStockPrice { GlobalQuote = new GlobalQuote() { Price = 50 } };
            var stockAlertRangeDisplay = new StockAlertRangeDisplay();
            stockAlertRangeDisplay.StockAlertRangeId = stockAlertRange.Id;
            stockAlertRangeDisplay.UpperLimit = stockAlertRange.UpperLimit;
            stockAlertRangeDisplay.LowerLimit = stockAlertRange.LowerLimit;
            stockAlertRangeDisplay.SymbolId = stockAlertRange.StockSymbol.Id;
            stockAlertRangeDisplay.CurrentPrice = stockCurrentPrice.GlobalQuote.Price;
            stockAlertRangeDisplay.Comments = GetComments(stockCurrentPrice, stockAlertRange);
            
            return stockAlertRangeDisplay;
        }
    }
}
