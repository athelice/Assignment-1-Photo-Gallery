using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Data;

namespace ProductCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {// host is my host machine
           var host =  CreateWebHostBuilder(args).Build(); // wait until VMs are up

            using (var scope = host.Services.CreateScope()) // give me services to build
            {
                //proactively  destructs memory  once done with the loop
                var services = scope.ServiceProvider; // service providers will be database
               var context =
                    services.GetRequiredService<CatalogContext>();
                CatalogSeed.Seed(context);
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //open port in firewall
                .UseStartup<Startup>();
    }
}
