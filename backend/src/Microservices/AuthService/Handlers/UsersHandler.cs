namespace AuthService.Handlers
{
    using AuthService.Constants;
    using AuthService.Models.Messages;
    using AuthService.Services;
    using RacoonNotes.MessageBroker;
    using RacoonNotes.MessageBroker.Constants;

    public class UsersHandler
    {
        private readonly IServiceProvider _provider;
        private readonly IMessageBroker _messageBroker;

        public UsersHandler(IServiceProvider serviceProvider, IMessageBroker messageBroker)
        {
            _provider = serviceProvider;
            _messageBroker = messageBroker;

        }
        public async Task HandleUserCreatedAsync(CreateUserRequestMessage message, string replyTo, string correlationId)
        {
            using var scope = _provider.CreateScope();
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

            var userId = await userService.AddNewUserAsync(message);
            var response = new CreateUserResponseMessage()
            {
                UserId = userId,
            };
            await _messageBroker.PublishAsync(response, "", replyTo, correlationId);
        }

        public async Task HandleGetUserByIdAsync(GetUserByIdRequestMessage message, string replyTo, string correlationId)
        {
            using var scope = _provider.CreateScope();
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

            var response = await userService.GetUserByIdAsync(message);
            await _messageBroker.PublishAsync(response, "", replyTo, correlationId);
        }
    }
}
