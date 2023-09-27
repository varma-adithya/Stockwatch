using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<StockPage>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IStockSymbolPage, StockSymbolPage>();
                    services.AddTransient<IStockSymbolService, StockSymbolService>();
                    services.AddTransient<IStockPriceService, StockPriceService>();
                    services.AddTransient<IStockAlertRangeservice, StockAlertRangeservice>();
                    services.AddTransient<StockPage>();
                    services.AddDbContext<StockwatchDbContext>(options =>
                    {
                        options.UseSqlite("Data Source=D:/Projects/Random/StockTicker/Stockwatch/stock_database.db");
                    });
                });
        }

    }
}