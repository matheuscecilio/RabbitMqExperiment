using WebApplication.Domain;

namespace WebApplication.Services.Interfaces
{
    public interface IRabbitOrderService
    {
        void PublishOrder(Order order);
    }
}
