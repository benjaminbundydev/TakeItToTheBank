using System.Collections.Generic;
using System.Linq;
using TakeItToTheBank.Accounts;
using TakeItToTheBank.Exceptions;
using TakeItToTheBank.Factories;
using TakeItToTheBank.Factories.Enums;

namespace TakeItToTheBank
{
    public class Bank
    {
        public string Name { get; set; }

        public IList<Account> Accounts { get; private set; } = new List<Account>();

        private Account GetAccount(string owner)
        {
            return this.Accounts.FirstOrDefault(a => a.Owner == owner) 
                ?? throw new AccountNotFoundException($"Could not find {owner}. Please check spelling and try again");
        }

        public void CreateAccount(string owner, decimal balance, AccountTypes accountType)
        {
            var newAccount = AccountFactory.CreateAccount(accountType, owner, balance);
            this.Accounts.Add(newAccount);
        }

        public Account Deposit(decimal amountToDeposit, string owner)
        {
            var accountToDepositInto = this.GetAccount(owner);
            accountToDepositInto.Deposit(amountToDeposit);

            return accountToDepositInto;
        }

        public Account Transfer(decimal amountToTransfer, string ownerToTransferFrom, string ownerToTransferTo)
        {
            var accountToTransferFrom = this.GetAccount(ownerToTransferFrom);
            var accountToTransferTo = this.GetAccount(ownerToTransferTo);
            accountToTransferFrom.Transfer(amountToTransfer, accountToTransferTo);

            return accountToTransferFrom;
        }

        public Account Withdraw(decimal amountToWithdraw, string owner)
        {
            var accountToWithdrawFrom = this.GetAccount(owner);
            accountToWithdrawFrom.Withdraw(amountToWithdraw);

            return accountToWithdrawFrom;
        }
    }
}
