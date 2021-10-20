using System;
using System.Runtime.Serialization;

namespace TakeItToTheBank.Exceptions
{
    public class AccountTypeDoesNotExistException : TechnicalException
    {
        public AccountTypeDoesNotExistException()
        {
        }

        public AccountTypeDoesNotExistException(string message) : base(message)
        {
        }

        public AccountTypeDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountTypeDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
