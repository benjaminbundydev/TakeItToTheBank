namespace TakeItToTheBank.Accounts
{
    public class CorporateAccount : CheckingAccount
    {
        public CorporateAccount(string owner, decimal balance) 
            : base(owner, balance)
        {
        }
    }
}
