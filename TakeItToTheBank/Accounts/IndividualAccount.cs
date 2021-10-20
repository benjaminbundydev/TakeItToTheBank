using TakeItToTheBank.Exceptions;

namespace TakeItToTheBank.Accounts
{
    public class IndividualAccount : CheckingAccount
    {
        public IndividualAccount(string owner, decimal balance)
            : base(owner, balance)
        {
        }

        public override void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= 500)
            {
                base.Withdraw(amountToWithdraw);
            }
            else
            {
                throw new WithdrawalLimitException("Individual accounts have a withdrawal limit of $500. Please enter a number less than 500");
            }
        }
    }
}
