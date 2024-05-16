using Stockwatch.Business;

namespace Stockwatch.Background
{
    public class Worker : BackgroundService
    {

        private ILogger<Worker> _logger;
        private IStockWorkerService _stockWorkerService;
        private IStockPriceService _stockPriceService;

        public Worker(IServiceProvider serviceProvider, IStockPriceService stockPriceService, ILogger<Worker> logger)
        {
            _stockPriceService = stockPriceService;
            _stockWorkerService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IStockWorkerService>();
            _logger = logger;
        }
        
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Ticker has started!");
            await base.StartAsync(cancellationToken);
        }
        
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Ticker has stopped!");
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var stockAlertRangeList = await _stockWorkerService.GetAllStockAlertRangesAsync();

                if (stockAlertRangeList.Count == 0)
                {
                    _logger.LogWarning("No Stock Range in database! Please add stock range to get alerts");
                }
                else
                {
                    foreach (var stockAlertRange in stockAlertRangeList)
                    {
                        var currentPrice = await _stockPriceService.GetStockPriceAsync(stockAlertRange.StockSymbol);
                        _logger.LogInformation($"Stock price for stock symbol {stockAlertRange.StockSymbol.SymbolName} requested");

                        if (currentPrice?.GlobalQuote != null)
                        {
                            _stockWorkerService.CheckStockRangeVariance(currentPrice.GlobalQuote, stockAlertRange);                           
                        }
                        else
                            _logger.LogWarning($"Stock price request for {stockAlertRange.StockSymbol.SymbolName} failed"); ;
                    }
                }

                _logger.LogInformation("Checks for all Stock Alerts ended! Next check in 5 minutes from now");
                await Task.Delay(300000, stoppingToken);
                stockAlertRangeList = await _stockWorkerService.GetAllStockAlertRangesAsync();
            }
        }
    }
}