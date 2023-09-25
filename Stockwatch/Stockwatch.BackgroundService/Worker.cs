using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.Background
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Ticker has started!");
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger?.LogInformation("Ticker has stopped!");
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var stksymb = new StockSymbol { SymbolName = "Appl" }; ;
                var stk = new StockData { StockSymbol = stksymb, SymbolId = stksymb.Id, UpperLimit = 200, LowerLimit = 50 };
                var stkdata = new StockPriceService();
                var stkret = stkdata.GetStockPrice(stk);
                await Task.Delay(300000, stoppingToken);
            }
        }
    }
}