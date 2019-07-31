using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventCatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build(); //builds a vm
            //using is overloaded for memory destruction after it is used
            using (var scope = host.Services.CreateScope()) // give me all the services
            { //look for host m/c. within that looking for services within scope, within scope, look for context
                var services = scope.ServiceProvider;// all services in scope catalog db context
                //get me required service with name catalogContext
                var context =
                    services.GetRequiredService<EventContext>();
                EventSeed.Seed(context);
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
