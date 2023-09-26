using Microsoft.Extensions.Logging.EventLog;
using Stockwatch.Business;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
     .ConfigureLogging(logging =>
     {
         logging.AddEventLog(config =>
         {
             config.SourceName = "Stockwatch";
             config.LogName = "Stockwatch log";
         }) ;
     })
     .Build();

await host.RunAsync();
