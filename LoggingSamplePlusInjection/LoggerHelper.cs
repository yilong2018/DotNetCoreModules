using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace LoggingSamplePlusInjection
{
    public class LoggerHelper : ILoggerHelper
    {
        private string CurrentDirectory { get; set; }
        private string FileName { get; set; }
        private string FilePath { get; set; }
        private string DateTimeOutput {get; set;}
        private readonly ILogger<LoggerHelper> _logger;

        public LoggerHelper(ILoggerFactory loggerFactory)
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
            this.DateTimeOutput = DateTime.Now.ToString(" yyyyMMdd HH:mm:ss");
            // this.DateTimeOutput = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}";
            _logger = loggerFactory.CreateLogger<LoggerHelper>();
        }

        public void LogStart()
        {
            using (System.IO.StreamWriter writer = System.IO.File.AppendText(this.FilePath))
            {
                writer.Write("\r\n### Log Start: ");
                writer.WriteLine(DateTimeOutput);
                _logger.LogInformation(DateTimeOutput);
            }
        }
        public void Log(string Message)
        {
            using (System.IO.StreamWriter writer = System.IO.File.AppendText(this.FilePath))
            {
                writer.WriteLine($" --- {Message}");
                _logger.LogInformation($" --- {Message}");

            }
        }

        public void LogEnd()
        {
            using (System.IO.StreamWriter writer = System.IO.File.AppendText(this.FilePath))
            {
                writer.Write("### Log End: ");
                writer.WriteLine(DateTimeOutput);
                _logger.LogInformation(DateTimeOutput);
                writer.WriteLine("------------------------------------------");
            }
        }

    }
}
