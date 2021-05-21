using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MicroMachines.Shopping.API.Extensions;
using MicroMachines.Shopping.Infrastructure.Data;

namespace MicroMachines.Shopping.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDatabase<OrderContext>((context, services) =>
            {
                OrderContextSeed.SeedAsync(context).Wait();
            });
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
