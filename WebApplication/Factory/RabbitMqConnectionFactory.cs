using RabbitMQ.Client;
using WebApplication.Factory.Interfaces;

namespace WebApplication.Factory
{
    public class RabbitMqConnectionFactory : IRabbitMqConnectionFactory
    {
        public IConnection Create()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            return connectionFactory.CreateConnection();
        }
    }
}
