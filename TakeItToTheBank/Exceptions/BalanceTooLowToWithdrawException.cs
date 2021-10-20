using System;
using System.Runtime.Serialization;

namespace TakeItToTheBank.Exceptions
{
    public class BalanceTooLowToWithdrawException : BusinessException
    {
        public BalanceTooLowToWithdrawException()
        {
        }

        public BalanceTooLowToWithdrawException(string message) : base(message)
        {
        }

        public BalanceTooLowToWithdrawException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BalanceTooLowToWithdrawException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
