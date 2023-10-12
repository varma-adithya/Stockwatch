using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

namespace Stockwatch.Background
{
    public interface IStockWorkerService
    {
        public List<string> GetStockSymbols();

        public int CheckStockRange(IntraStockPrice currentPrice, StockAlertRange stockAlertRange);
        
        public List<StockAlertRange> GetAll();
    }

    public class StockWorkerService : IStockWorkerService
    {

        private IStockAlertRangeService _stockAlertRangeService;

        public StockWorkerService(IStockAlertRangeService stockAlertRangeService)
        {
            _stockAlertRangeService = stockAlertRangeService;
        }

        public List<StockAlertRange> GetAll() { return _stockAlertRangeService.GetAll(); }

        public List<string> GetStockSymbols()
        {
            var allstocks = _stockAlertRangeService.GetAll();
            return allstocks.Select(stock => stock.StockSymbol.SymbolName).ToList();
        }

        public int CheckStockRange(IntraStockPrice currentPrice, StockAlertRange stockAlertRange)
        {
            if (currentPrice.Price >= stockAlertRange.UpperLimit)
            {
                return 1;
            }
            else if (currentPrice.Price <= stockAlertRange.LowerLimit)
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