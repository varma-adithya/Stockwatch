using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.Background
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private StockPriceService _PriceService = new StockPriceService();
        public Worker(IConfiguration configuration, ILogger<Worker> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private string GetApiUrl(string symbolName)
        {
            string Apikey = _configuration["APIKey"];
            string apiUrlTemplate = _configuration["ApiSettings:ApiUrl"];
            string apiUrl = apiUrlTemplate
                .Replace("YOUR_SYMBOL_NAME", symbolName)
                .Replace("YOUR_API_KEY", Apikey);
            Console.WriteLine(apiUrl);
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
                string SymbolName = "AAPL"; 
                string ApiUrl = GetApiUrl(SymbolName);
                var StockPrice = _PriceService.GetStockPrice(ApiUrl);
                Console.WriteLine(StockPrice.Result.Symbol);
                await Task.Delay(300000, stoppingToken);
            }
        }
    }
}