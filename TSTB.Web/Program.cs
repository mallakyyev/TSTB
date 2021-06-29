using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TSTB.DAL.Data;

namespace TSTB.Web
{
    public class Program
    {                
        public static void Main(string[] args)                                                                                          
        {
            var host = CreateHostBuilder(args).Build();            
            CreateAdminData.CreateDataTask(host).GetAwaiter().GetResult();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {                      
                    webBuilder.UseStartup<Startup>();
                });
    }
}
