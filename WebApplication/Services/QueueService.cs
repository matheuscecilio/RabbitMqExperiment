using RabbitMQ.Client;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class QueueService : IQueueService
    {
        public QueueDeclareOk CreateQueue(
            string queueName, 
            IConnection connection
        )
        {
            QueueDeclareOk queue;

            using (var channel = connection.CreateModel())
            {
                queue = channel.QueueDeclare(
                    queue: queueName, 
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null
                );
            }

            return queue;
        }

        public bool WriteMessageOnQueue(
            byte[] message, 
            string queueName, 
            IConnection connection
        )
        {
            using (var channel = connection.CreateModel())
            {
                channel.BasicPublish(
                    exchange: string.Empty, 
                    routingKey: queueName, 
                    basicProperties: null, 
                    body: message
                );
            }

            return true;
        }
    }
}
