using Stockwatch.Business;
using Stockwatch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockwatch.Background
{
    public interface IStockWorkerService
    {
        public List<string> GetStocksymbols();
    }

    public class StockWorkerService : IStockWorkerService
    {
        private IStockAlertRangeservice _stockAlertRangeService;

        public StockWorkerService(IStockAlertRangeservice stockAlertRangeservice)
        {
            _stockAlertRangeService = stockAlertRangeservice;
        }

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
