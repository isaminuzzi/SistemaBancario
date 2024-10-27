namespace RabbitMq;

public class Message (IRabbit rabbit): IMessage
{
    public async Task SendAsync<T>(T value) where T : class
    {
        await rabbit.Publish(value);
    }
}