using Microsoft.Extensions.Options;
using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.Background
{
    public class Worker : BackgroundService
    {
        private ILogger<Worker> _logger;
        private IConfiguration _configuration;
        private AlphaVantageAPI _options;
        private IStockWorkerService _workerService;
        private IStockPriceService _priceService;
        public Worker(IStockPriceService priceService,IServiceProvider serviceProvider, IConfiguration configuration, ILogger<Worker> logger, IOptions<AlphaVantageAPI> options)
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
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var checksymbollist = _workerService.GetAll();
                foreach (var checksymbol in checksymbollist)
                {
                    _options.SymbolName = checksymbol.StockSymbol.SymbolName;
                    var StockPrice = _priceService.GetStockPrice(_options);

                    if(StockPrice.Result != null)
                    {
                        IntraStockPrice currentPrice = StockPrice.Result;
                        int res = _workerService.CheckStockRange(currentPrice, checksymbol);
                        Console.WriteLine(res);
                    }
                }

                

                await Task.Delay(300000, stoppingToken);
            }
        }
    }
}