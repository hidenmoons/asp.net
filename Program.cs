using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // CreateWebHostBuilder(args).Build().Run();
            var host =CreateWebHostBuilder(args).Build();
            var scope = host.Services.CreateScope();
            var servicios = scope.ServiceProvider;
           
            try
            {
                var context = servicios.GetRequiredService<EscuelaConexto>();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                
                  var logger = servicios.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ocurrio un error");
                

            }
          
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
