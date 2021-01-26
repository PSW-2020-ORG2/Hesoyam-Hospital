using ActionsAndBenefits.Model;
using ActionsAndBenefits.Service.Abstract;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ActionsAndBenefits.Service.Background
{
    public class TimerService : BackgroundService
    {
        System.Timers.Timer collectTimer = new System.Timers.Timer();
        ConcurrentQueue<ActionBenefit> _queue;
        private readonly IActionBenefitService _actionBenefitService;
        public TimerService(ConcurrentQueue<ActionBenefit> queue, IActionBenefitService actionBenefitService)
        {
            _queue = queue;
            _actionBenefitService = actionBenefitService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            collectTimer.Elapsed += new ElapsedEventHandler(CollectMessage);
            collectTimer.Interval = 5000; 
            collectTimer.Enabled = true;

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
        private void CollectMessage(object source, ElapsedEventArgs e)
        {
            while (_queue.Count > 0)
            {
                ActionBenefit message;
                
                if(_queue.TryDequeue(out message))
                {
                    _actionBenefitService.Create(message);
                }
            }
        }
    }
}
