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
                        services.Configure<ApiOptions>(context.Configuration.GetSection(nameof(ApiOptions.AlphaVantageAPI)));
                        services.AddTransient<StockPage>();
                        services.AddHttpClient<IStockPriceService,StockPriceService>();
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
                            options.UseSqlite($"Data Source={DbFileLocation.GetDbFileLocation()}");
                        });
                    })
                    .ConfigureAppConfiguration(context =>
                    {
                        context.AddEnvironmentVariables();
                         context.AddUserSecrets<StockPage>();
                        context.AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
                    })
                    .Build();

            //using IServiceScope serviceScope = CurrentHost.Services.CreateScope();
            //{
            //    var dbContext = serviceScope.ServiceProvider.GetRequiredService<StockwatchDbContext>();
            //}
            Application.Run(CurrentHost.Services.CreateScope().ServiceProvider.GetRequiredService<StockPage>());
        }
    }
}