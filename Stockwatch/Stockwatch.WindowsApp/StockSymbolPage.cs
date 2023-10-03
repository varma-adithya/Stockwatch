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
        void AddSymbol(string symbol);

        List<string> GetSymbolList();
    }
    public class StockSymbolPage : IStockSymbolPage
    {
        public IStockSymbolService _stockSymbolService;
        
        public StockSymbolPage(IStockSymbolService stocksymbolservice) {
            _stockSymbolService = stocksymbolservice;
        }
        
        public void AddSymbol(string symbol)
        {
            _stockSymbolService.AddStockSymbol(new StockSymbol { SymbolName = symbol });
        }

        public List<string> GetSymbolList() 
        {
            var stockSymbols = _stockSymbolService.GetAll();
            return stockSymbols.Select(ss => ss.SymbolName).ToList();
        }
    }
}
