using RabbitMQ.Client;
using WorkerApp.Factory.Interfaces;

namespace WorkerApp.Factory
{
    public class RabbitMqConnectionFactory : IRabbitMqConnectionFactory
    {
        public IConnection Create()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            return connectionFactory.CreateConnection();
        }
    }
}
