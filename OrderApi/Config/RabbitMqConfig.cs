using OrderApi.Job;
using Quartz;
using RabbitMQ.Client;

namespace OrderApi.Config;

public static class RabbitMqConfig
{
    public static void AddRabbitMq(this IServiceCollection service,ConfigurationManager configuration)
    {
        service.AddSingleton<IConnection>(option =>
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration.GetSection("RabbitMqConfig:HostName").Value,
                UserName = configuration.GetSection("RabbitMqConfig:UserName").Value,
                Password = configuration.GetSection("RabbitMqConfig:Password").Value,
                VirtualHost = configuration.GetSection("RabbitMqConfig:VHost").Value,
                Port = int.Parse(configuration.GetSection("RabbitMqConfig:Port").Value!),
            };

            return factory.CreateConnection();
        });
    }
}