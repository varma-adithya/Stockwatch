﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

namespace Stockwatch.WindowsApp
{
    public interface IStockPriceService 
    {
        public Task<IntraStockPrice?> GetCurrentPriceAsync(StockSymbol symbol);
        public string GetComments(IntraStockPrice currentprice, StockAlertRange stockAlertRange);
    }

    public class StockPriceService:IStockPriceService
    {
        private Business.IStockPriceService _stockpriceservice;

        public StockPriceService(Business.IStockPriceService stockPriceService)
        {
            _stockpriceservice = stockPriceService;
        }

        public async Task<IntraStockPrice?> GetCurrentPriceAsync(StockSymbol symbol)
        {
            var currentprice = await _stockpriceservice.GetStockPriceAsync(symbol);
            return currentprice ?? null;
        }
        
        public string GetComments(IntraStockPrice currentPrice, StockAlertRange stockAlertRange)
        {
            if (currentPrice?.GlobalQuote.Price >= stockAlertRange?.UpperLimit)
            {
                return "Stock Price Surge! "+currentPrice.GlobalQuote.Symbol + " stock price value has surged above the Upper Limit";
            }
            else if (currentPrice?.GlobalQuote.Price <= stockAlertRange?.LowerLimit)
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