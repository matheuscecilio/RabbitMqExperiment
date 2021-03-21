using RabbitMQ.Client;

namespace WorkerApp.Factory.Interfaces
{
    public interface IRabbitMqConnectionFactory
    {
        IConnection Create();
    }
}
