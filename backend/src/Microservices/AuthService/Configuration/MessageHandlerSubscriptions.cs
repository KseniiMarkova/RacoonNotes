namespace AuthService.Configuration
{
    using AuthService.Constants;
    using AuthService.Handlers;
    using AuthService.Models.Messages;
    using RacoonNotes.MessageBroker;

    public static class MessageHandlerSubscriptions
    {
        public static void ConfigureMessageBroker(IApplicationBuilder app)
        {
            var messageBroker = app.ApplicationServices.GetService<IMessageBroker>();
            var userMessageHandler = app.ApplicationServices.GetService<UsersHandler>();
            if (userMessageHandler != null && messageBroker != null)
            {
                SubscribeUserMessageHandlers(messageBroker, userMessageHandler);
            }
        }
        public static void SubscribeUserMessageHandlers(IMessageBroker messageBroker, UsersHandler userMessageHandler)
        {
            messageBroker.SubscribeHandlerWithWrapper<CreateUserRequestMessage>(AuthBrokerMessages.UserCreateQueue,
                AuthBrokerMessages.UserExchange,
                AuthBrokerMessages.UserCreated,
                userMessageHandler.HandleUserCreatedAsync);

            messageBroker.SubscribeHandlerWithWrapper<GetUserByIdRequestMessage>(AuthBrokerMessages.UserGetQueue,
                AuthBrokerMessages.UserExchange,
                AuthBrokerMessages.UserGotten,
                userMessageHandler.HandleGetUserByIdAsync);
        }
    }
}
