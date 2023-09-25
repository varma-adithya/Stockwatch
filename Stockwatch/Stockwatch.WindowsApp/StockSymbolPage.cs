﻿using Stockwatch.Business;
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
        public IStockSymbolService _stocksymbolservice;
        public StockSymbolPage(IStockSymbolService stocksymbolservice) { 
            _stocksymbolservice = stocksymbolservice;
        }
        public void AddSymbol(string symbol)
        {
        _stocksymbolservice.AddStock(new Model.StockSymbol { SymbolName = symbol });
        }

        public List<string> GetSymbolList() {
            var stockSymbols = _stocksymbolservice.GetAll();
            return stockSymbols.Select(ss => ss.SymbolName).ToList();
        }
    }
}
