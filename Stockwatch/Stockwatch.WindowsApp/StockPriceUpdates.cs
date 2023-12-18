using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

namespace Stockwatch.WindowsApp
{
    public interface IStockPriceUpdates 
    {
        public Task<IntraStockPrice> GetCurrentPrice(StockSymbol symbol);
        public string GetComments(IntraStockPrice currentprice, StockAlertRange stockAlertRange);
    }
    public class StockPriceUpdates:IStockPriceUpdates
    {
        private IStockPriceService _stockpriceservice;
        private IConfiguration _Configuration;
        private ApiOptions _options;
        public StockPriceUpdates(IOptions<ApiOptions> options, IConfiguration Configuration,IStockPriceService stockPriceService)
        {
            _options = options.Value;
            _Configuration = Configuration;
            _stockpriceservice = stockPriceService;
        }
        public async Task<IntraStockPrice> GetCurrentPrice(StockSymbol symbol)
        {
            var currentprice = await _stockpriceservice.GetStockPriceAsync(symbol);
            if (currentprice != null)
                return currentprice;
            else return null;
        }
        public string GetComments(IntraStockPrice currentPrice, StockAlertRange stockAlertRange)
        {
            if (currentPrice.GlobalQuote.Price >= stockAlertRange.UpperLimit)
            {
                return "Stock Price Surge! "+currentPrice.GlobalQuote.Symbol + " stock price value has surged above the Upper Limit";
            }
            else if (currentPrice.GlobalQuote.Price <= stockAlertRange.LowerLimit)
            {
                return "Stock Price Fall! "+currentPrice.GlobalQuote.Symbol + " stock price value has fallen below the Lower Limit";
            }
            else
            {
                return "Stock in range";
            }
        }
    }
}
