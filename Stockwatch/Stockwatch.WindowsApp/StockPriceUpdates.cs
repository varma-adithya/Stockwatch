using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public interface IStockPriceUpdates 
    {
        public IntraStockPrice GetCurrentPrice(StockSymbol symbol);
        public string GetComments(IntraStockPrice currentprice, StockAlertRange stockAlertRange);
    }
    public class StockPriceUpdates:IStockPriceUpdates
    {
        private IStockPriceService _stockpriceservice;
        private IConfiguration _Configuration;
        private AlphaVantageAPI _options;
        public StockPriceUpdates(IOptions<AlphaVantageAPI> options, IConfiguration Configuration,IStockPriceService stockPriceService)
        {
            _options = options.Value;
            _Configuration = Configuration;
            _stockpriceservice = stockPriceService;
        }
        public IntraStockPrice GetCurrentPrice(StockSymbol symbol)
        {
            _options.SymbolName = symbol.SymbolName;
            var currentprice = _stockpriceservice.GetStockPrice(_options).Result;
            if (currentprice != null)
                return currentprice;
            else return null;
        }
        public string GetComments(IntraStockPrice currentprice, StockAlertRange stockAlertRange)
        {
            if (currentprice.Price >= stockAlertRange.UpperLimit)
            {
                return "Stock in profit!";
            }
            else if (currentprice.Price <= stockAlertRange.LowerLimit)
            {
                return "Stock in Loss!";
            }
            else
            {
                return "Stock in range!";
            }
        }
    }
}
