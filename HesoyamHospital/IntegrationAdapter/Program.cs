using Backend.Model.PharmacyModel;
using IntegrationAdapter.RabbitMQServiceSupport;
using IntegrationAdapter.SFTPServiceSupport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace IntegrationAdapter
{
    public class Program
    {
        public static ConcurrentQueue<ActionBenefit> NewsMessages = new ConcurrentQueue<ActionBenefit>();
        //public static RabbitMQService rabbitService = new RabbitMQService();
        //public static TimerService newTimerService = new TimerService(rabbitService);
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<TimerService>();
                    services.AddHostedService<RabbitMQService>();
                    services.AddHostedService<SFTPBackgroundService>();
                    services.AddHostedService<SFTPTimerService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }
                );
    }
}
