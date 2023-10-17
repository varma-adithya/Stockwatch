using Microsoft.EntityFrameworkCore;
using Stockwatch.Background;
using Stockwatch.Business;
using Stockwatch.Model;

IHost host = Host.CreateDefaultBuilder(args)

    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.Configure<AlphaVantageAPI>(hostContext.Configuration.GetSection(nameof(AlphaVantageAPI)));
        services.AddTransient<IStockPriceService, StockPriceService>();
        services.AddTransient<IStockWorkerService, StockWorkerService>();
        services.AddTransient<IStockAlertRangeService, StockAlertRangeService>();
        services.AddDbContext<StockwatchDbContext>(options =>
        {
            options.UseSqlite("Data Source=D:/Projects/Random/StockTicker/Stockwatch/Stockwatch/stock_database.db");
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
