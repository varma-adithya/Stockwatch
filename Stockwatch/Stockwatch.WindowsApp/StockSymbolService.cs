﻿using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public interface IStockSymbolService
    {
        Task AddSymbol();
        Task<List<StockSymbol>> GetSymbolListAsync();
        Task<StockSymbol?> FetchStockSymbolByIdAsync(int id);
        Task<StockSymbol?> FetchStockSymbolByNameAsync(string name);
    }

    public class StockSymbolService : IStockSymbolService
    {
        public Business.IStockSymbolService _stockSymbolService;
        
        public StockSymbolService(Business.IStockSymbolService stocksymbolservice) {
            _stockSymbolService = stocksymbolservice;
        }

        public async Task AddSymbol()
        {
            if (await _stockSymbolService.FetchStockSymbolByNameAsync("AAPL") == null)
            {
                await _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "AAPL" });
            }
            if (await _stockSymbolService.FetchStockSymbolByNameAsync("IBM") == null)
            {
                await _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "IBM" });
            }
            if (await _stockSymbolService.FetchStockSymbolByNameAsync("BAC") == null)
            {
                await _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "BAC" });
            }
            if (await _stockSymbolService.FetchStockSymbolByNameAsync("GOOGL") == null)
            {
                await _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "GOOGL" });
            }
            if (await _stockSymbolService.FetchStockSymbolByNameAsync("AMZN") == null)
            {
                await _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "AMZN" });
            }
        }

        public async Task<StockSymbol?> FetchStockSymbolByIdAsync(int id)
        {
            var stockSymbol = await _stockSymbolService.FetchStockSymbolByIdAsync(id);
            return stockSymbol ?? null;
        }

        public async Task<StockSymbol?> FetchStockSymbolByNameAsync(string name)
        {
            var stockSymbol = await _stockSymbolService.FetchStockSymbolByNameAsync(name);
            return stockSymbol ?? null;
        }

        public async Task<List<StockSymbol>> GetSymbolListAsync() => await _stockSymbolService.GetAllAsync();
    }
}
