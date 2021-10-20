using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeItToTheBank.Accounts;
using TakeItToTheBank.Exceptions;

namespace TakeItToTheBank.Tests.AccountTests
{
    [TestClass]
    public class CorporateAccountTests
    {
        [TestMethod]
        public void Deposit_WhenCalled_ShouldAddAppropriateDepositAmountToAccountBalance()
        {
            // Arrange
            var account = new CorporateAccount("Tom", 200);

            // Act
            account.Deposit(200);

            // Assert
            Assert.AreEqual(400, account.Balance);
        }

        [TestMethod]
        public void Withdraw_WhenAmountToWithdrawIsLessThanAccountBalance_ShouldWithdrawAmountFromAccountBalance()
        {
            // Arrange
            var account = new CorporateAccount("Tom", 300);

            // Act
            account.Withdraw(200);

            // Assert
            Assert.AreEqual(100, account.Balance);
        }

        [TestMethod]
        public void Withdraw_WhenAmountToWithdrawIsGreaterThanAccountBalance_ShouldThrowArgumentException()
        {
            // Arrange
            var account = new CorporateAccount("Tom", 100);

            // Act
            try
            {
                // Assert
                account.Withdraw(500);
                Assert.Fail("Expected an argument exception, but instead succeeded.");
            }
            catch (BalanceTooLowToWithdrawException expectedException)
            {
                Assert.AreEqual(
                    $"{account.Owner} only has a balance of {account.Balance}. Please enter a value lower than {account.Balance}",
                    expectedException.Message);
            }
        }

        [TestMethod]
        public void Transfer_WhenAmountToTransferIsLessThanAccountBalance_ShouldTransferAmountFromAccount1ToAccount2()
        {
            // Arrange
            var accountToTransferFrom = new CorporateAccount("Tom", 300);
            var accountToTransferTo = new CorporateAccount("Jerry", 300);

            // Act
            accountToTransferFrom.Transfer(200, accountToTransferTo);

            // Assert
            Assert.AreEqual(100, accountToTransferFrom.Balance);
            Assert.AreEqual(500, accountToTransferTo.Balance);
        }

        [TestMethod]
        public void Transfer_WhenAmountToTransferIsGreaterThanAccountBalance_ShouldThrowArgumentException()
        {
            // Arrange
            var accountToTransferFrom = new CorporateAccount("Tom", 300);
            var accountToTransferTo = new CorporateAccount("Jerry", 300);

            // Act
            try
            {
                // Assert
                accountToTransferFrom.Transfer(400, accountToTransferTo);
                Assert.Fail("Expected an argument exception, but instead succeeded.");
            }
            catch (BalanceTooLowToTransferException expectedException)
            {
                Assert.AreEqual(
                    $"{accountToTransferFrom.Owner} only has a balance of {accountToTransferFrom.Balance}. Please enter a value lower than {accountToTransferFrom.Balance}",
                    expectedException.Message);
            }
        }
    }
}
