using Stockwatch.Business;

namespace Stockwatch.Background
{
    public class Worker : BackgroundService
    {

        private ILogger<Worker> _logger;
        private IStockWorkerService _workerService;
        private IStockPriceService _priceService;

        public Worker(IServiceProvider serviceProvider, IStockPriceService priceService, ILogger<Worker> logger)
        {
            _priceService = priceService;
            _workerService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IStockWorkerService>();
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
                var stockAlertRangeList = await _workerService.GetAllStockAlertRangesAsync();

                if (stockAlertRangeList.Count == 0)
                {
                    _logger.LogWarning("No Stock Range in database! Please add stock range to get alerts");
                }
                else
                {
                    foreach (var stockAlertRange in stockAlertRangeList)
                    {
                        var currentPrice = await _priceService.GetStockPriceAsync(stockAlertRange.StockSymbol);
                        _logger.LogInformation($"Stock price for stock symbol {stockAlertRange.StockSymbol.SymbolName} requested");

                        if (currentPrice?.GlobalQuote != null)
                        {
                            _workerService.CheckStockRangeVariance(currentPrice.GlobalQuote, stockAlertRange);                           
                        }
                        else
                            _logger.LogWarning($"Stock price request for {stockAlertRange.StockSymbol.SymbolName} failed"); ;
                    }
                }

                _logger.LogInformation("Checks for all Stock Alerts ended! Next check in 5 minutes from now");
                await Task.Delay(300000, stoppingToken);
                stockAlertRangeList = await _workerService.GetAllStockAlertRangesAsync();
            }
        }
    }
}