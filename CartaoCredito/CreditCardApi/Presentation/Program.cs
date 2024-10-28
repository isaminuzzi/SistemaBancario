using Application.DependencyInjection;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMq.DependencyInjection;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureServices((_, services) =>
                {
                    var serviceProvider = services.BuildServiceProvider();
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                    var serviceCollectionBusConfigurator =
                        serviceProvider.GetRequiredService<Action<IServiceCollectionBusConfigurator>>();
                    
                    services.AddProducersAndConsumers(configuration);
                    
                    services.AddMessageService(serviceCollectionBusConfigurator);
                });
    }
}