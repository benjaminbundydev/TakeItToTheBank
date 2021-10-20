using System;
using System.Runtime.Serialization;

namespace TakeItToTheBank.Exceptions
{
    public class WithdrawalLimitException : BusinessException
    {
        public WithdrawalLimitException()
        {
        }

        public WithdrawalLimitException(string message) : base(message)
        {
        }

        public WithdrawalLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WithdrawalLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
