using Backend;
using Backend.Model.PharmacyModel;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace IntegrationAdapter.RabbitMQServiceSupport
{
    public class TimerService : BackgroundService
    {
        System.Timers.Timer collectTimer = new System.Timers.Timer();

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            collectTimer.Elapsed += new ElapsedEventHandler(CollectMessage);
            collectTimer.Interval = 5000; //number in miliseconds  
            collectTimer.Enabled = true;

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        private void CollectMessage(object source, ElapsedEventArgs e)
        {
            foreach (ActionBenefit message in Program.NewsMessages)
            {
                AppResources.getInstance().actionBenefitService.Create(message);
            }
            Program.NewsMessages.Clear();
        }

    }
}
