using Backend.Model.PharmacyModel;
using IntegrationAdapter.RabbitMQServiceSupport;
using IntegrationAdapter.SFTPServiceSupport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace IntegrationAdapter
{
    public class Program
    {
        public static readonly List<ActionBenefit> NewsMessages = new List<ActionBenefit>();
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
