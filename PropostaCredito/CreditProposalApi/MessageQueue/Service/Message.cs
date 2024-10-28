using Domain.Interface.RabbitMq;
using MassTransit;

namespace RabbitMq.Service;

public class Message(IBus bus) : IMessage
{
    public async Task SendAsync<T>(T value) where T : class
    {
        await bus.Publish(value);
    }
}