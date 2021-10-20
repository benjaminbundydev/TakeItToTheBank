using TakeItToTheBank.Exceptions;

namespace TakeItToTheBank.Accounts
{
    public abstract class Account
    {
        public Account(string owner, decimal balance)
        {
            this.Owner = owner;
            this.Balance = balance;
        }

        public string Owner { get; }

        public decimal Balance { get; private set; }

        public virtual void Deposit(decimal amountToDeposit)
        {
            this.Balance += amountToDeposit;
        }

        public virtual void Transfer(decimal amountToTransfer, Account accountToTransferTo)
        {
            if (amountToTransfer > this.Balance)
            {
                throw new BalanceTooLowToTransferException($"{ this.Owner } only has a balance of { this.Balance}. Please enter a value lower than { this.Balance}");
            }

            this.Balance -= amountToTransfer;
            accountToTransferTo.Balance += amountToTransfer;
        }

        public virtual void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > this.Balance)
            {
                throw new BalanceTooLowToWithdrawException($"{this.Owner} only has a balance of {this.Balance}. Please enter a value lower than {this.Balance}");
            }

            this.Balance -= amountToWithdraw;
        }
    }
}
