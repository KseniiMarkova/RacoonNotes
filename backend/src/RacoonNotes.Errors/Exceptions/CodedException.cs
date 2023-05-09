namespace RacoonNotes.Errors.Exceptions
{
    public class CodedException : Exception
    {
        public string CustomCode { get; set; }
        public CodedException() : base() { }
        public CodedException(string message) : base(message) { }
        public CodedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
