using Microsoft.EntityFrameworkCore;
using Stockwatch.Background;
using Stockwatch.Business;
using Stockwatch.Model;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.Configure<ApiOptions>(hostContext.Configuration.GetSection(nameof(ApiOptions.AlphaVantageAPI)));
        services.AddHttpClient<IStockPriceService,StockPriceService>();
        services.AddTransient<IStockPriceService, StockPriceService>();
        services.AddTransient<IStockWorkerService, StockWorkerService>();
        services.AddTransient<IStockAlertRangeService, StockAlertRangeService>();
        services.AddTransient<IStockNotificationService, StockNotificationService>();
        services.AddDbContext<StockwatchDbContext>(options =>
        {
            options.UseSqlite($"Data Source={DbFileLocation.GetDbFileLocation()}");
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

await host.RunAsync();
