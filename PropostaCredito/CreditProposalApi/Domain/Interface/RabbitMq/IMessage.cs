namespace Domain.Interface.RabbitMq;

public interface IMessage
{
    Task SendAsync<T>(T value) where T : class;
}