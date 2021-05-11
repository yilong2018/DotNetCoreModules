using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggingSample
{
  public class DataService : IDataService
  {
    private readonly ILogger<DataService> _log;
    private readonly IConfiguration _config;

    public DataService(ILogger<DataService> logger, IConfiguration config)
    {
      _log = logger;
      _config = config;
    }

    public void Connect()
    {
      //Reading connection string
      var cs = _config.GetValue<string>("ConnectionStrings:DefaultConnection");
      _log.LogInformation("Connection String {cs}", cs);
    }
  }
}