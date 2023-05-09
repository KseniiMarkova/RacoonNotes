namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.Extensions.Options;
    using RacoonNotes.MessageBroker;
    using RacoonNotes.MessageBroker.Models;

    public static class MessageBrokerCollectionExtensions
    {
        public static IServiceCollection AddMessageBrokerDependencyGroup(
             this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, RabbitMqMessageBroker>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value;
                return new RabbitMqMessageBroker(settings);
            });

            return services;
        }
    }
}