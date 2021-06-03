using System;

namespace KolmeoProductApi.Services.Exceptions
{
    /// <summary>
    /// Represents errors when an required field is not specified.
    /// </summary>
    public class RequiredFieldMissingException : Exception
    {
        public RequiredFieldMissingException()
        {
        }

        public RequiredFieldMissingException(string message)
            : base(message)
        {
        }

        public RequiredFieldMissingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
