using Microsoft.Toolkit.Uwp.Notifications;
using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

namespace Stockwatch.Background
{
    public interface IStockWorkerService
    {
        public Task<List<string>> GetStockSymbols();
        public void CheckStockRangeVariance(GlobalQuote globalQuote, StockAlertRange stockAlertRange);
        public Task<List<StockAlertRange>> GetAllAsync();
    }

    public class StockWorkerService : IStockWorkerService
    {
        private IStockAlertRangeService _stockAlertRangeService;

        public StockWorkerService(IStockAlertRangeService stockAlertRangeService)
        {
            _stockAlertRangeService = stockAlertRangeService;
        }

        public async Task<List<StockAlertRange>> GetAllAsync() { return await _stockAlertRangeService.GetAllAsync(); }

        public async Task<List<string>> GetStockSymbols()
        {
            var allstocks = await _stockAlertRangeService.GetAllAsync();
            return allstocks.Select(stock => stock.StockSymbol.SymbolName).ToList();
        }

        public void CheckStockRangeVariance(GlobalQuote globalQuote, StockAlertRange stockAlertRange)
        {
                if (globalQuote.Price >= stockAlertRange.UpperLimit)
                {
                    NotifyStockRange("Stock Price Surge", globalQuote.Symbol + " stock price value has surged above the Upper Limit");
                }
                else if (globalQuote.Price <= stockAlertRange.LowerLimit)
                {
                    NotifyStockRange("Stock Price Fall", globalQuote.Symbol + " stock price value has fallen below the Lower Limit");
                }
        }

        private void NotifyStockRange(string head, string content)
        {
            new ToastContentBuilder()
                .AddText(head)
                .AddText(content)
                .Show();
        }


    }
}