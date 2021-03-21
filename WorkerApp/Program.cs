using Microsoft.Extensions.DependencyInjection;
using System;
using WorkerApp.Factory;
using WorkerApp.Factory.Interfaces;
using WorkerApp.Services;
using WorkerApp.Services.Interfaces;

namespace WorkerApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var servicesCollection = new ServiceCollection();

            ConfigureServices(servicesCollection);

            var provider = servicesCollection.BuildServiceProvider();
            var consumer = provider.GetRequiredService<IConsumerService>();
            var factory = provider.GetRequiredService<IRabbitMqConnectionFactory>();

            var connection = factory.Create();

            using var channel = connection.CreateModel();

            consumer.ConsumeOrder(channel);

            Console.WriteLine("Press enter to quit!");
            Console.ReadLine();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRabbitMqConnectionFactory, RabbitMqConnectionFactory>();
            services.AddScoped<IConsumerService, ConsumerService>();
        }
    }
}
