using RabbitMQ.Client;

namespace WorkerApp.Services.Interfaces
{
    public interface IConsumerService
    {
        void ConsumeOrder(IModel channel);
    }
}
