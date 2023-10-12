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
      
        private string GetApiUrl(string symbolName)
        {
            string apiKey = _configuration["APIKey"];
            string apiUrlTemplate = _configuration["ApiSettings:ApiUrl"];
            string apiUrl = apiUrlTemplate
                .Replace("YOUR_SYMBOL_NAME", symbolName)
                .Replace("YOUR_API_KEY", apiKey);
            return apiUrl;
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
                var checkSymbolList = _workerService.GetAll();
                foreach (var checkSymbol in checkSymbolList)
                {
                    _options.SymbolName = checkSymbol.StockSymbol.SymbolName;
                    var StockPrice = _priceService.GetStockPrice(_options);

                    if (StockPrice.Result != null)
                    {
                        IntraStockPrice currentPrice = StockPrice.Result;
                        int res = _workerService.CheckStockRange(currentPrice, checkSymbol);
                        Console.WriteLine(res);
                    }
                }



                await Task.Delay(300000, stoppingToken);
            }
        }
    }
}