namespace RacoonNotes.Errors.Exceptions
{
    public class UserAlreadyExistsException : CodedException
    {
        public UserAlreadyExistsException() : base() { }
        public UserAlreadyExistsException(string message) : base(message) { }
        public UserAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}