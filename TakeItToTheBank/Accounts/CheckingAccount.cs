using System;

namespace TakeItToTheBank.Accounts
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string owner, decimal balance)
            : base(owner, balance)
        {
        }
    }
}
