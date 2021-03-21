using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebApplication.Domain;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IRabbitOrderService _rabbitOrderService;

        public OrderController(
            ILogger<OrderController> logger, 
            IRabbitOrderService rabbitOrderService
        )
        {
            _logger = logger;
            _rabbitOrderService = rabbitOrderService;
        }

        [HttpPost]
        public IActionResult Insert(Order order)
        {
            try
            {
                _rabbitOrderService.PublishOrder(order);

                return Accepted(order);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to create a new order", ex);
                return new StatusCodeResult(500);
            }
        }
    }
}
