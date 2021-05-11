using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggingSample
{
  class Program
  {
    static void Main(string[] args)
    {
      //   var host = AppStartup();
      //   var dataService = ActivatorUtilities.CreateInstance<DataService>(host.Services);

      //   dataService.Connect();
      var logger = new LoggerHelper();
      logger.Log("易龙");
      logger.Log("is one the top of the world");

    }





    // static void ConfigSetup(IConfigurationBuilder builder)
    // {
    //   builder.SetBasePath(Directory.GetCurrentDirectory())
    //       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //       .AddEnvironmentVariables();
    // }

    // static IHost AppStartup()
    // {
    //   var builder = new ConfigurationBuilder();
    //   ConfigSetup(builder);

    //   //defining Serilog configs
    //   Log.Logger = new LoggerConfiguration()
    //       .ReadFrom.Configuration(builder.Build())
    //       .Enrich.FromLogContext()
    //       .WriteTo.Console()
    //       .CreateLogger();

    //   // INitiated the dependency injection container
    //   var host = Host.CreateDefaultBuilder()
    //             .ConfigureServices((context, services) =>
    //             {
    //               services.AddTransient<IDataService, DataService>();
    //             })
    //             .UseSerilog()
    //             .Build();
    //   return host;

    // }
  }
}
