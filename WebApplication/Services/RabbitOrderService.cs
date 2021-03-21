using System.Text;
using System.Text.Json;
using WebApplication.Domain;
using WebApplication.Factory.Interfaces;
using WebApplication.Services.Interfaces;

namespace WebApplication.Services
{
    public class RabbitOrderService : IRabbitOrderService
    {
        private readonly IRabbitMqConnectionFactory _factory;
        private readonly IQueueService _queueService;
        private const string _queueName = "orderQueue";

        public RabbitOrderService(
            IRabbitMqConnectionFactory factory, 
            IQueueService queueService
        )
        {
            _factory = factory;
            _queueService = queueService;
        }

        public void PublishOrder(Order order)
        {
            var connection = _factory.Create();

            _queueService.CreateQueue(
                _queueName,
                connection
            );

            var message = JsonSerializer.Serialize(order);
            var body = Encoding.ASCII.GetBytes(message);

            _queueService.WriteMessageOnQueue(
                body,
                _queueName,
                connection
            );
        }
    }
}
