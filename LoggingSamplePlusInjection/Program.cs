using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggingSamplePlusInjection
{
    class Program
    {

        static void Main(string[] args)
        {
            // var logger = new LoggerHelper();
            // logger.Log("易龙");
            // logger.Log("is one the top of the world");


            var serviceProvider = new ServiceCollection()
                  .AddLogging(config => config.ClearProviders().AddConsole().SetMinimumLevel(LogLevel.Debug))
                  .AddSingleton<ILoggerHelper, LoggerHelper>()
                  .AddSingleton<IBarService, BarService>()
                  .AddSingleton<IFooService, FooService>()
                  .BuildServiceProvider();

            // var logger = serviceProvider.GetService<ILoggerFactory>()
            //   .CreateLogger<Program>();
            // logger.LogDebug("Starting application");

            //do the actual work here
            // var bar = serviceProvider.GetService<IBarService>();
            // bar.DoSomeRealWork();
            // var foo = serviceProvider.GetService<IFooService>();
            // foo.DoThing(10);
            var log = serviceProvider.GetService<ILoggerHelper>();
            log.LogStart();
            log.Log("This is log service.");
            log.LogEnd();

            // logger.LogDebug("All done!");



            // var host = AppStartup();
            // var dataService = ActivatorUtilities.CreateInstance<DataService>(host.Services);

            // dataService.Connect();
        }

        static void ConfigSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            ConfigSetup(builder);

            //defining Serilog configs
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .CreateLogger();

            // INitiated the dependency injection container
            var host = Host.CreateDefaultBuilder()
                      .ConfigureServices((context, services) =>
                      {
                          services.AddTransient<IDataService, DataService>();
                      })
                      .UseSerilog()
                      .Build();
            return host;

        }
        public interface IFooService
        {
            void DoThing(int number);
        }

        public interface IBarService
        {
            void DoSomeRealWork();
        }

        public class BarService : IBarService
        {
            private readonly IFooService _fooService;
            public BarService(IFooService fooService)
            {
                _fooService = fooService;
            }

            public void DoSomeRealWork()
            {
                for (int i = 0; i < 3; i++)
                {
                    _fooService.DoThing(i);
                }
            }
        }

        public class FooService : IFooService
        {
            private readonly ILogger<FooService> _logger;
            public FooService(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<FooService>();
            }

            public void DoThing(int number)
            {
                _logger.LogInformation($"Doing the thing {number}");
            }
        }
    }
}
