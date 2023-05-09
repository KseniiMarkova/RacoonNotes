namespace RacoonNotes.MessageBroker
{
    using RacoonNotes.Errors.Exceptions;
    using RacoonNotes.MessageBroker.Models;
    using System;
    using System.Threading.Tasks;

    public class MessageHandlerWrapper<TMessage>
    {
        private readonly Func<TMessage, string, string, Task> _handler;
        private readonly IMessageBroker _messageBroker;

        public MessageHandlerWrapper(Func<TMessage, string, string, Task> handler, IMessageBroker messageBroker)
        {
            _handler = handler;
            _messageBroker = messageBroker;
        }

        public async Task HandleMessageAsync(TMessage message, string replyTo, string correlationId)
        {
            var response = new ErrorMessageResponse();

            try
            {
                await _handler(message, replyTo, correlationId);
            }
            catch (UserAlreadyExistsException ex)
            {
                response.ErrorMessage = ex.Message;
                Console.WriteLine($"UserAlreadyExistsException: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                response.ErrorMessage = ex.Message;
                Console.WriteLine($"ArgumentException: {ex.Message}");
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                {
                    await _messageBroker.PublishAsync(response, "", replyTo, correlationId);
                }
            }
        }
    }
}
