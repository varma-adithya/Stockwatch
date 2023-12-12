using Microsoft.EntityFrameworkCore;
using Stockwatch.Background;
using Stockwatch.Business;
using Stockwatch.Model;

string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string stockWatchFolder = Path.Combine(appDataPath, "StockWatch");
string stockDatabasePath = Path.Combine(stockWatchFolder, "stock_database.db");

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
     config.AddUserSecrets<Program>();
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.Configure<ApiOptions>(hostContext.Configuration.GetSection(nameof(ApiOptions.AlphaVantageAPI)));
        services.AddHttpClient<IStockPriceService,StockPriceService>();
        services.AddTransient<IStockPriceService, StockPriceService>();
        services.AddTransient<IStockWorkerService, StockWorkerService>();
        services.AddTransient<IStockAlertRangeService, StockAlertRangeService>();
        services.AddDbContext<StockwatchDbContext>(options =>
        {
            options.UseSqlite($"Data Source={stockDatabasePath}");
        });

    })
     .ConfigureLogging(logging =>
     {
         logging.AddEventLog(config =>
         {
             config.SourceName = "Stockwatch";
             config.LogName = "Stockwatch log";
         });
     })
     .Build();

CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken cancellationToken = cts.Token;

await host.RunAsync(cancellationToken);
