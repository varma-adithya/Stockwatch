using Microsoft.Extensions.Options;
using Stockwatch.Business;
using Stockwatch.Model;
using Stockwatch.Model.Dto;

namespace Stockwatch.Background
{
    public class Worker : BackgroundService
    {

        private ILogger<Worker> _logger;
        private IConfiguration _configuration;
        private AlphaVantageAPI _options;
        private IStockWorkerService _workerService;
        private IStockPriceService _priceService;
        public Worker(IStockPriceService priceService, IServiceProvider serviceProvider, IConfiguration configuration, ILogger<Worker> logger, IOptions<AlphaVantageAPI> options)
        {
            _priceService = priceService;
            _workerService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IStockWorkerService>();
            _options = options.Value;
            _configuration = configuration;
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
                _options.ApiKey = _configuration["APIKey"];
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var checkSymbolList = _workerService.GetAll();
                if (checkSymbolList.Count != 0)
                {
                    _logger.LogInformation("Stock Ranges found");
                    foreach (var checkSymbol in checkSymbolList)
                    {
                        _options.SymbolName = checkSymbol.StockSymbol.SymbolName;
                        var stockPrice = _priceService.GetStockPrice(_options);

                        if (stockPrice.Result != null)
                        {
                            IntraStockPrice currentPrice = stockPrice.Result;
                            _workerService.CheckAndNotifyStockRange(currentPrice, checkSymbol);
                        }
                    }
                    await Task.Delay(300000, stoppingToken);
                }
                else
                {
                    _logger.LogInformation("No Stock Range in database! Please add stock range to get alerts");
                    await Task.Delay(100000, stoppingToken);
                }

            }
        }
    }
}