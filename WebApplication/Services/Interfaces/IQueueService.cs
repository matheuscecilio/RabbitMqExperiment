using RabbitMQ.Client;

namespace WebApplication.Services.Interfaces
{
    public interface IQueueService
    {
        QueueDeclareOk CreateQueue(
            string queueName, 
            IConnection connection
        );

        bool WriteMessageOnQueue(
            byte[] message,
            string queueName,
            IConnection connection
        );
    }
}
