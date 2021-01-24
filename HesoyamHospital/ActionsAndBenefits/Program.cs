using ActionsAndBenefits.Model;
using ActionsAndBenefits.Repository.SQLRepository.Base;
using ActionsAndBenefits.Service;
using ActionsAndBenefits.Service.Abstract;
using ActionsAndBenefits.Service.Background;
using Backend.Repository.MySQLRepository.MiscRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;

namespace ActionsAndBenefits
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

                    ActionBenefitService actionBenefitService = new ActionBenefitService(new ActionBenefitRepository(new SQLStream<ActionBenefit>()));
                    services.AddSingleton<IActionBenefitService, ActionBenefitService>(service => actionBenefitService);
                    services.AddSingleton<IHostedService>(provider => new TimerService(NewsMessages, actionBenefitService));
                    services.AddSingleton<IHostedService>(provider => new RabbitMQService(NewsMessages));

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
