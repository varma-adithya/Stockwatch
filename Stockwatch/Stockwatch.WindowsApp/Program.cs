using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    internal static class Program
    {
        public static IHost? CurrentHost { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            CurrentHost = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {

                        services.Configure<AlphaVantageAPI>(context.Configuration.GetSection(nameof(AlphaVantageAPI)));
                        services.AddTransient<StockPage>();
                        services.AddTransient<IStockSymbolPage, StockSymbolPage>();
                        services.AddTransient<IStockSymbolService, StockSymbolService>();
                        services.AddTransient<IStockPriceService, StockPriceService>();
                        services.AddTransient<IStockPriceUpdates, StockPriceUpdates>();
                        services.AddTransient<IStockAlertRangeservice, StockAlertRangeservice>();
                        services.AddDbContext<StockwatchDbContext>(options =>
                        {
                            options.UseSqlite("Data Source=D:/Projects/Random/StockTicker/Stockwatch/Stockwatch/stock_database.db");
                        });
                    })
                    .ConfigureAppConfiguration(context =>
                    {
                     context.AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
                    })
                    .Build();

            using IServiceScope serviceScope = CurrentHost.Services.CreateScope();
            Application.Run(serviceScope.ServiceProvider.GetRequiredService<StockPage>());
        }

    }
}