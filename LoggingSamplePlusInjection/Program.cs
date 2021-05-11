using System;
using Microsoft.Extensions.DependencyInjection;

namespace LoggingSamplePlusInjection
{
  class Program
  {
    static void Main(string[] args)
    {
      var logger = new LoggerHelper();
      logger.Log("易龙");
      logger.Log("is one the top of the world");

      var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IFooService, FooService>()
            .AddSingleton<IBarService, BarService>()
            .BuildServiceProvider();
    }
  }
}
