using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
                        services.Configure<ApiOptions>(options =>
                        {
                            options.ApiKey = Environment.GetEnvironmentVariable("ALPHA_VANTAGE_API_KEY");
                            options.ApiUrl = Environment.GetEnvironmentVariable("ALPHA_VANTAGE_API_URL");
                        });
                        services.AddTransient<StockPage>();
                        services.AddHttpClient<IStockPriceService, StockPriceService>();
                        services.AddTransient<IStockSymbolService, StockSymbolService>();
                        services.AddTransient<Business.IStockSymbolService, Business.StockSymbolService>();
                        services.AddTransient<IStockPriceService, StockPriceService>();
                        services.AddTransient<IStockAlertRangeDisplayService, StockAlertRangeDisplayService>();
                        services.AddTransient<IStockAlertRangeService, StockAlertRangeService>();
                        services.AddLogging(builder =>
                        {
                            builder.AddEventLog();
                        });
                        services.AddDbContext<StockwatchDbContext>(options =>
                        {
                            options.UseSqlite($"Data Source={DbFileLocation.GetDbFileLocation()}");
                        });
                    })
                    .ConfigureAppConfiguration(context =>
                    {
                        context.AddEnvironmentVariables();
                        context.AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
                    })
                    .Build();

            Application.Run(CurrentHost.Services.CreateScope().ServiceProvider.GetRequiredService<StockPage>());
        }
    }
}