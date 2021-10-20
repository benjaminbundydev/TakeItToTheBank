using System;
using System.Runtime.Serialization;

namespace TakeItToTheBank.Exceptions
{
    public class BalanceTooLowToTransferException : BusinessException
    {
        public BalanceTooLowToTransferException()
        {
        }

        public BalanceTooLowToTransferException(string message) : base(message)
        {
        }

        public BalanceTooLowToTransferException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BalanceTooLowToTransferException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
