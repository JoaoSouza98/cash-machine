using System;

namespace CashMachine.Entities.Exceptions
{
    class WithdrawException : Exception
    {
        public WithdrawException(string message) : base(message)
        {
        }
    }
}
