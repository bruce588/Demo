using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace serilog_demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .WriteTo.Console()
               .WriteTo.File(@"G:\serial.log")
               .WriteTo.Seq("http://localhost:5341")
               .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();//當應用程式有錯誤要將最後的錯誤寫入Log
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();//改使用Serilog
            
    }
}
