﻿namespace RacoonNotes.Errors.Exceptions
{
    public class NotFoundException : CodedException
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

    }
}
