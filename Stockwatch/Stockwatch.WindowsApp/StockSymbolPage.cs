using Stockwatch.Business;
using Stockwatch.Model;
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
        StockSymbol FetchStockAlertRangeByIdSymbolById(int id);
        StockSymbol FetchStockAlertRangeByIdSymbolByName(string Name);
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
                _stocksymbolservice.AddStockAlertRangeSymbol(new StockSymbol { SymbolName = "AAPL" });
            }
            if (_stocksymbolservice.FetchStockAlertRangeByIdSymbolByName("IBM") == null)
            {
                _stocksymbolservice.AddStockAlertRangeSymbol(new StockSymbol { SymbolName = "IBM" });
            }
        
        }

        public StockSymbol FetchStockAlertRangeByIdSymbolById(int id)
        {
            return _stocksymbolservice.FetchStockAlertRangeByIdSymbolById(id);
        }

        public StockSymbol FetchStockAlertRangeByIdSymbolByName(string Name)
        {
        return _stocksymbolservice.FetchStockAlertRangeByIdSymbolByName(Name);
        }

        public List<string> GetSymbolList() {
            var stockSymbols = _stocksymbolservice.GetAll();
            return stockSymbols.Select(ss => ss.SymbolName).ToList();
        }
    }
}
