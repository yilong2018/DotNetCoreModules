using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ReadJsonFile
{
    class Program
    {
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var builder = new ConfigurationBuilder()  //Microsoft.Extensions.Configuration
                .SetBasePath(Directory.GetCurrentDirectory()) //using System.IO;
                .AddJsonFile("appsettings.json"); //Microsoft.Extensions.Configuration.Json

            _configuration = builder.Build();
            Console.WriteLine($"ServerCode: {_configuration["ServerCode"]}");
            Console.WriteLine("ServerCode: " +  _configuration.GetValue<string>("ServerCode"));


            UserInfo user1 = new UserInfo();
            UserInfo user2 = new UserInfo();
            _configuration.GetSection("section0").Bind(user1); //Microsoft.Extensions.Configuration.Binder
            _configuration.GetSection("section1").Bind(user2);
        }


        public class UserInfo
        {
            public long UserId { get; set; }
            public string UserName { get; set; }

            public override string ToString()
            {
                return string.Format($"UserId:{UserId}, UserName:{UserName}");
            }
        }
    }
}
