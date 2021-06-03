using System;

namespace KolmeoProductApi.Services.Exceptions
{
    /// <summary>
    /// Represents errors when an invalid value is given for a field.
    /// </summary>
    public class InvalidFieldException : Exception
    {
        public InvalidFieldException()
        {
        }

        public InvalidFieldException(string message)
            : base(message)
        {
        }

        public InvalidFieldException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
