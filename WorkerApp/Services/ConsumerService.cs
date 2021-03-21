using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using WorkerApp.Domain;
using WorkerApp.Services.Interfaces;

namespace WorkerApp.Services
{
    public class ConsumerService : IConsumerService
    {
        private const string _queueName = "orderQueue";

        public void ConsumeOrder(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.ASCII.GetString(body);
                var order = JsonSerializer.Deserialize<Order>(message);

                Console.WriteLine($"Order: [{order.Number}]|[{order.Name}]|[{order.Price}]");
            };

            var args = ImmutableDictionary<string, object>.Empty;

            channel.BasicConsume(
                queue: _queueName,
                autoAck: true,
                consumerTag: "consumer",
                noLocal: false,
                exclusive: false,
                arguments: null,
                consumer: consumer
            );
        }
    }
}
