using Backend.Model.PharmacyModel;
using IntegrationAdapter.RabbitMQServiceSupport;
using IntegrationAdapter.SFTPServiceSupport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;

namespace IntegrationAdapter
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    ConcurrentQueue<ActionBenefit> NewsMessages = new ConcurrentQueue<ActionBenefit>();
                    services.AddSingleton<IHostedService>(provider => new TimerService(NewsMessages));
                    services.AddSingleton<IHostedService>(provider => new RabbitMQService(NewsMessages));
                    
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }
                );
    }
}
