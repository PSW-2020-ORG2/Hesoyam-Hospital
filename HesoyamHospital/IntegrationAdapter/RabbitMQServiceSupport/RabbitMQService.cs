using Backend.Model.PharmacyModel;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace IntegrationAdapter.RabbitMQServiceSupport
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        ConcurrentQueue<ActionBenefit> _queue;
        public RabbitMQService(ConcurrentQueue<ActionBenefit> queue)
        {
            _queue = queue;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "news",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                ActionBenefit message;
                try
                {
                    message = JsonConvert.DeserializeObject<ActionBenefit>(jsonMessage);
                }
                catch (Exception)
                {
                    message = JsonConvert.DeserializeObject<ActionBenefit>(jsonMessage, new MyDateTimeConverter());
                }
                message.Approved = false;
                _queue.Enqueue(message);
            };
            channel.BasicConsume(queue: "news",
                                    autoAck: true,
                                    consumer: consumer);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

    }
}
