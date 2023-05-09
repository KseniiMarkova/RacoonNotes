namespace RacoonNotes.MessageBroker
{
    using RabbitMQ.Client.Events;
    using RabbitMQ.Client;
    using RacoonNotes.MessageBroker.Models;
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class RabbitMqMessageBroker: IMessageBroker, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqMessageBroker(MessageBrokerSettings settings)
        {
            var factory = new ConnectionFactory()
            {
                HostName = settings.HostName,
                Port = settings.Port,
                UserName = settings.UserName,
                Password = settings.Password,
                VirtualHost = string.IsNullOrEmpty(settings.VirtualHost) ? "/" : settings.VirtualHost,
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task PublishAsync<T>(T message, string exchangeName, string routingKey, string? correlationId = null)
        {
            if (!string.IsNullOrEmpty(exchangeName))
            {
                _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true);
            }

            var properties = _channel.CreateBasicProperties();
            properties.CorrelationId = correlationId;

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            await Task.Run(() => _channel.BasicPublish(exchangeName, routingKey, properties, body));
        }

        public void Subscribe<T>(string queueName, string exchangeName, string routingKey, Func<T, string, string, Task> handleMessage)
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true);
            _channel.QueueDeclare(queueName, true, false, false);
            _channel.QueueBind(queueName, exchangeName, routingKey);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body));
                _channel.BasicAck(ea.DeliveryTag, false);

                await handleMessage(message, ea.BasicProperties.ReplyTo, ea.BasicProperties.CorrelationId);
            };

            _channel.BasicConsume(queueName, false, consumer);
        }

        public void SubscribeHandlerWithWrapper<T>(
            string queueName,
            string exchangeName,
            string routingKey,
            Func<T, string, string, Task> handler)
        {
            var wrappedHandler = new MessageHandlerWrapper<T>(handler, this);
            Subscribe<T>(queueName, exchangeName, routingKey, wrappedHandler.HandleMessageAsync);
        }


        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
