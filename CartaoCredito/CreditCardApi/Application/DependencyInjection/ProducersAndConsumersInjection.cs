using Application.Consumers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;

namespace Application.DependencyInjection;

public static class ProducersAndConsumersInjection
{
    public static void AddProducersAndConsumers(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<RequestCreditCardConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], h =>
                {
                    h.Username(configuration["RabbitMq:Username"]);
                    h.Password(configuration["RabbitMq:Password"]);
                });

                cfg.ReceiveEndpoint("request-credit-card-queue",
                    e => { e.ConfigureConsumer<RequestCreditCardConsumer>(context); });
            });
        });

        services.AddMassTransitHostedService();
    }
}