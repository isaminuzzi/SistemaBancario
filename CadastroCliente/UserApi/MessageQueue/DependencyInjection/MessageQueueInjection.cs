using Domain.Interface.RabbitMq;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using RabbitMq.Service;

namespace RabbitMq.DependencyInjection;

public static class MessageQueueInjection
{
    public static void AddMessageService(this IServiceCollection services,
        Action<IServiceCollectionBusConfigurator> serviceCollectionBusConfigurator)
    {
        services.AddMassTransit(serviceCollectionBusConfigurator);

        services.AddMassTransitHostedService(true);

        services.AddTransient<IMessage, Message>();
    }
}