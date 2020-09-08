using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Skinet.Infrastructure.Data;

namespace skinetAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Applying any migreation and create any dtabase  that does not exist
            // CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            
            using(var scope = host.Services.CreateScope()){
                 var services = scope.ServiceProvider;
                 var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                 try
                 {
                     var context = services.GetRequiredService<StoreContext>();
                     await context.Database.MigrateAsync();
                     await StoreContextSeed.SeedAsync(context,loggerFactory);
                 }
                 catch (System.Exception ex)
                 {
                     var logger = loggerFactory.CreateLogger<Program>();
                     logger.LogError(ex,"An error occured during migration");
                     
                     
                 }   
            }

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
