using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stockwatch.Business;
using Stockwatch.Model;
using System.Net.Sockets;
using System.Reflection;

namespace Stockwatch.WindowsApp
{
    internal static class Program
    {
        public static IHost? CurrentHost { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string stockWatchFolder = Path.Combine(appDataPath, "StockWatch");
            string stockDatabasePath = Path.Combine(stockWatchFolder, "stock_database.db");

            if (!Directory.Exists(stockWatchFolder))
            {
                Directory.CreateDirectory(stockWatchFolder);
            }

            CurrentHost = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {

                        services.Configure<AlphaVantageAPI>(context.Configuration.GetSection(nameof(AlphaVantageAPI)));
                        services.AddTransient<StockPage>();
                        services.AddHttpClient();
                        services.AddTransient<IStockSymbolPage, StockSymbolPage>();
                        services.AddTransient<IStockSymbolService, StockSymbolService>();
                        services.AddTransient<IStockPriceService, StockPriceService>();
                        services.AddTransient<IStockPriceUpdates, StockPriceUpdates>();
                        services.AddTransient<IStockAlertRangeDisplayService, StockAlertRangeDisplayService>();
                        services.AddTransient<IStockAlertRangeService, StockAlertRangeService>();
                        services.AddLogging(builder =>
                        {
                            builder.AddEventLog();
                        });
                        services.AddDbContext<StockwatchDbContext>(options =>
                        {
                            options.UseSqlite($"Data Source={stockDatabasePath}");
                        });
                    })
                    .ConfigureAppConfiguration(context =>
                    {
                        context.AddEnvironmentVariables();
                         context.AddUserSecrets<StockPage>();
                        context.AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
                    })
                    .Build();

            using IServiceScope serviceScope = CurrentHost.Services.CreateScope();
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<StockwatchDbContext>();
                await dbContext.Database.MigrateAsync();
            }
            Application.Run(serviceScope.ServiceProvider.GetRequiredService<StockPage>());
        }
    }
}