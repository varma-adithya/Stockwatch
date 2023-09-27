using Stockwatch.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockwatch.WindowsApp
{
    public interface IStockSymbolPage
    {
        void AddSymbol();
        List<string> GetSymbolList();
    }
    public class StockSymbolPage : IStockSymbolPage
    {
        public IStockSymbolService _stocksymbolservice;
        public StockSymbolPage(IStockSymbolService stocksymbolservice) { 
            _stocksymbolservice = stocksymbolservice;
        }
        public void AddSymbol()
        {
            if (_stocksymbolservice.FetchStockAlertRangeByIdSymbolByName("AAPL") == null)
            {
                _stocksymbolservice.AddStockAlertRangeSymbol(new Model.StockSymbol { SymbolName = "AAPL" });
            }
            if (_stocksymbolservice.FetchStockAlertRangeByIdSymbolByName("IBM") == null)
            {
                _stocksymbolservice.AddStockAlertRangeSymbol(new Model.StockSymbol { SymbolName = "IBM" });
            }
        
        }

        public List<string> GetSymbolList() {
            var stockSymbols = _stocksymbolservice.GetAll();
            return stockSymbols.Select(ss => ss.SymbolName).ToList();
        }
    }
}
