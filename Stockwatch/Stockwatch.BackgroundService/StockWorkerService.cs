using Microsoft.Toolkit.Uwp.Notifications;
using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

namespace Stockwatch.Background
{
    public interface IStockWorkerService
    {
        public Task<List<string>> GetStockSymbolsAsync();
        public void CheckStockRangeVariance(GlobalQuote globalQuote, StockAlertRange stockAlertRange);
        public Task<List<StockAlertRange>> GetAllStockAlertRangesAsync();
    }

    public interface IStockNotificationService
    {
        void NotifyStockRange(string header, string content);
    }

    public class StockNotificationService : IStockNotificationService
    {
        public void NotifyStockRange(string header, string content)
        {
            new ToastContentBuilder()
                .AddText(header)
                .AddText(content)
                .Show();
        }
    }

    public class StockWorkerService : IStockWorkerService
    {
        private IStockAlertRangeService _stockAlertRangeService;
        private IStockNotificationService _stockNotificationService;

        public StockWorkerService(IStockAlertRangeService stockAlertRangeService, IStockNotificationService stockNotificationService)
        {
            _stockAlertRangeService = stockAlertRangeService;
            _stockNotificationService = stockNotificationService;
        }

        public async Task<List<StockAlertRange>> GetAllStockAlertRangesAsync() { return await _stockAlertRangeService.GetAllAsync(); }

        public async Task<List<string>> GetStockSymbolsAsync()
        {
            var allstocks = await _stockAlertRangeService.GetAllAsync();
            return allstocks.Select(stock => stock.StockSymbol.SymbolName).ToList();
        }

        public void CheckStockRangeVariance(GlobalQuote globalQuote, StockAlertRange stockAlertRange)
        {
            if (globalQuote?.Price >= stockAlertRange?.UpperLimit)
            {
                _stockNotificationService.NotifyStockRange("Stock Price Surge", globalQuote.Symbol + " stock price value has surged above the Upper Limit");
            }
            else if (globalQuote?.Price <= stockAlertRange?.LowerLimit)
            {
                _stockNotificationService.NotifyStockRange("Stock Price Fall", globalQuote.Symbol + " stock price value has fallen below the Lower Limit");
            }
        }
    }
}