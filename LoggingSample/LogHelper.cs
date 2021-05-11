using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggingSample
{
  public abstract class LogBase
  {
    public abstract void Log(string Messsage);
  }


  public class LoggerHelper : LogBase
  {
    private string CurrentDirectory { get; set; }
    private string FileName { get; set; }
    private string FilePath { get; set; }

    public LoggerHelper()
    {
      this.CurrentDirectory = Directory.GetCurrentDirectory();
      this.FileName = "Log.txt";
      this.FilePath = this.CurrentDirectory + "/" + this.FileName;
    }

    public override void Log(string Message)
    {
      using (System.IO.StreamWriter writer = System.IO.File.AppendText(this.FilePath))
      {
        writer.Write("\r\nLog Entry:");
        writer.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
        writer.WriteLine($" :{Message}");
        writer.WriteLine("------------------------------------------");
      }
    }

  }
}
