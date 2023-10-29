using Microsoft.Toolkit.Uwp.Notifications;
using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

namespace Stockwatch.Background
{
    public interface IStockWorkerService
    {
        public List<string> GetStockSymbols();
        public void CheckAndNotifyStockRange(IntraStockPrice currentPrice, StockAlertRange stockAlertRange);
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

        public void CheckAndNotifyStockRange(IntraStockPrice currentPrice, StockAlertRange stockAlertRange)
        {
            if (currentPrice.GlobalQuote.Price >= stockAlertRange.UpperLimit)
            {
                NotifyStockRange("Stock Price Surge",currentPrice.GlobalQuote.Symbol+" stock price value has surged above the Upper Limit");
            }
            else if (currentPrice.GlobalQuote.Price <= stockAlertRange.LowerLimit)
            {
                NotifyStockRange("Stock Price Fall", currentPrice.GlobalQuote.Symbol + " stock price value has fallen below the Lower Limit");
            }
            //else
            //    NotifyStockRange("Stock Price in Range", currentPrice.GlobalQuote.Symbol + " stock price value is in range");
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