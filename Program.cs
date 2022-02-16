using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCShopERP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DataManagement.SaveCPUs(new Models.CPU() { Id = "i8", Maker = "Intel", Cores = 6, GHz = 2.8, PurchasePrice = 1300, RetailPrice = 1600 });
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
