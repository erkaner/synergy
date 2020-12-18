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
using Synergy.Models;

namespace Synergy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            // create web host
            var host = CreateWebHostBuilder(args).Build();

            // create service scope for seeding the database
            using (var scope = host.Services.CreateScope())
            {
                // retrieve the sample data service
                var sampleData = scope.ServiceProvider.GetRequiredService<ISampleData>();

                // run your sample data initialization
                sampleData.Initialize();
            }

            // run the application
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
