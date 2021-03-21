using RabbitMQ.Client;

namespace WebApplication.Factory.Interfaces
{
    public interface IRabbitMqConnectionFactory
    {
        IConnection Create();
    }
}
