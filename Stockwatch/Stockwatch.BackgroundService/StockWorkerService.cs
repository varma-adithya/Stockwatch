using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.Background
{
    public interface IStockWorkerService
    {
        public List<string> GetStocksymbols();
        public int CheckStockRange(IntraStockPrice currentprice, StockAlertRange stockAlertRange);
        public List<StockAlertRange> GetAll();
    }

    public class StockWorkerService : IStockWorkerService
    {

        private IStockAlertRangeservice _stockAlertRangeService;


        public StockWorkerService(IStockAlertRangeservice stockAlertRangeService)
        {
            _stockAlertRangeService = stockAlertRangeService;
        }

        public List<StockAlertRange> GetAll() {return _stockAlertRangeService.GetAll(); }

        public List<string> GetStocksymbols() {
            var allstocks = _stockAlertRangeService.GetAll();
            return allstocks.Select(stock => stock.StockSymbol.SymbolName).ToList();
        }

        public int CheckStockRange(IntraStockPrice currentprice, StockAlertRange stockAlertRange)
        {
            if (currentprice.Price >= stockAlertRange.UpperLimit)
            {
                return 1;
            }
            else if(currentprice.Price <= stockAlertRange.LowerLimit)
            {
                return -1;
            }
            else 
            {
                return 0;
            }
         }


    }
}
