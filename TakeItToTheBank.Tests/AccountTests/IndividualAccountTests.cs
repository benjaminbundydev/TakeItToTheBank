using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeItToTheBank.Accounts;
using TakeItToTheBank.Exceptions;

namespace TakeItToTheBank.Tests.AccountTests
{
    [TestClass]
    public class IndividualAccountTests
    {
        [TestMethod]
        public void Withdraw_WhenAmountToWithdrawIsGreaterThan1000_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new IndividualAccount("Tom", 10000);

            // Act
            try
            {
                // Assert
                account.Withdraw(501);
                Assert.Fail("Expected an argument exception, but instead succeeded.");
            }
            catch (WithdrawalLimitException expectedException)
            {
                Assert.AreEqual(
                    "Individual accounts have a withdrawal limit of $500. Please enter a number less than 500",
                    expectedException.Message);
            }
        }

        [TestMethod]
        public void Withdraw_WhenAmountToWithdrawIsGreaterThanAccountBalance_ShouldWithdrawAmountFromAccountBalance()
        {
            // Arrange
            var account = new IndividualAccount("Tom", 400);

            // Act
            try
            {
                // Assert
                account.Withdraw(401);
                Assert.Fail("Expected a BalanceTooLowToWithdrawException, but instead succeeded.");
            }
            catch (BalanceTooLowToWithdrawException expectedException)
            {
                Assert.AreEqual(
                    $"{account.Owner} only has a balance of {account.Balance}. Please enter a value lower than {account.Balance}",
                    expectedException.Message);
            }
        }

        [TestMethod]
        public void Withdraw_WhenAmountToWithdrawIsLessThan1000AndLessThanAccountBalance_ShouldWithdrawAmountFromAccountBalance()
        {
            // Arrange
            var account = new IndividualAccount("Tom", 600);

            // Act
            account.Withdraw(500);

            // Assert
            Assert.AreEqual(100, account.Balance);
        }
    }
}
