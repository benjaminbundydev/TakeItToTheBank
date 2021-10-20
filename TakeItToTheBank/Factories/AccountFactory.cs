using TakeItToTheBank.Accounts;
using TakeItToTheBank.Exceptions;
using TakeItToTheBank.Factories.Enums;

namespace TakeItToTheBank.Factories
{
    public static class AccountFactory
    {
        public static Account CreateAccount(AccountTypes accountType, string owner, decimal balance)
        {
            switch (accountType)
            {
                case AccountTypes.Individual:
                    return new IndividualAccount(owner, balance);
                case AccountTypes.Corporate:
                    return new CorporateAccount(owner, balance);
                case AccountTypes.Saving:
                    return new SavingAccount(owner, balance);
                default:
                    return new CheckingAccount(owner, balance);
            }
        }
    }
}
