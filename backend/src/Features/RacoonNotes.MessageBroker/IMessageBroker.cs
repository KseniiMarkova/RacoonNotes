namespace RacoonNotes.MessageBroker
{

    public interface IMessageBroker
    {
        Task PublishAsync<T>(T message, string exchangeName, string routingKey, string? correlationId = null);
        void Subscribe<T>(string queueName, string exchangeName, string routingKey, Func<T, string, string, Task> handleMessage);
        void SubscribeHandlerWithWrapper<T>(string queueName, string exchangeName, string routingKey, Func<T, string, string, Task> handler);
    }
}
