using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeItToTheBank.Exceptions;
using TakeItToTheBank.Factories.Enums;

namespace TakeItToTheBank.Tests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void CreateAccount_WhenCalled_ShouldCreateAccountAndAddToListOfAccounts()
        {
            // Arrange
            var bank = new Bank();
            bank.Name = "TestBank";

            // Act
            bank.CreateAccount("Tom", 400, AccountTypes.Checking);

            // Assert
            Assert.AreEqual(1, bank.Accounts.Count);
            Assert.AreEqual("Tom", bank.Accounts[0].Owner);
            Assert.AreEqual(400, bank.Accounts[0].Balance);
        }

        [TestMethod]
        public void Deposit_WhenOwnerNotInAccounts_ShouldThrowAccountNotFoundException()
        {
            // Arrange
            var bank = new Bank();
            bank.CreateAccount("Tom", 400, AccountTypes.Checking);

            // Act
            try
            {
                bank.Deposit(500, "Jerry");
                Assert.Fail("Expected an AccountNotFoundException, but instead succeeded.");
            }
            catch (AccountNotFoundException expectedException)
            {
                Assert.AreEqual(
                    $"Could not find Jerry. Please check spelling and try again",
                    expectedException.Message);
            }
        }

        [TestMethod]
        public void Deposit_When300DepositedIntoAccount_ShouldIncreaseAccountBalanceBy300()
        {
            // Arrange
            var bank = new Bank();
            bank.CreateAccount("Tom", 1000, AccountTypes.Checking);

            // Act
            bank.Deposit(300, "Tom");

            // Assert
            Assert.AreEqual(1300, bank.Accounts[0].Balance);
        }

        [TestMethod]
        public void Withdraw_When300WithdrawnFromAccount_ShouldDecreaseAccountBalanceBy300()
        {
            // Arrange
            var bank = new Bank();
            bank.CreateAccount("Tom", 1000, AccountTypes.Checking);

            // Act
            bank.Withdraw(300, "Tom");

            // Assert
            Assert.AreEqual(700, bank.Accounts[0].Balance);
        }

        [TestMethod]
        public void Withdraw_WhenWithdrawAmountTooGreat_ShouldThrowBalanceTooLowToWithdrawException()
        {
            // Arrange
            var bank = new Bank();
            bank.CreateAccount("Tom", 1000, AccountTypes.Checking);

            // Act
            try
            {
                // Assert
                bank.Withdraw(100000, "Tom");
            }
            catch (BalanceTooLowToWithdrawException expectedException)
            {
                Assert.AreEqual(
                    $"{bank.Accounts[0].Owner} only has a balance of {bank.Accounts[0].Balance}. Please enter a value lower than {bank.Accounts[0].Balance}",
                    expectedException.Message);
            }
        }

        [TestMethod]
        public void Withdraw_WhenIndividualAccountWithdrawalLimitIsPassed_ShouldThrowWithdrawalLimitException()
        {
            // Arrange
            var bank = new Bank();
            bank.CreateAccount("Tom", 1000, AccountTypes.Individual);

            // Act
            try
            {
                // Assert
                bank.Withdraw(501, "Tom");
            }
            catch (WithdrawalLimitException expectedException)
            {
                Assert.AreEqual(
                    "Individual accounts have a withdrawal limit of $500. Please enter a number less than 500",
                    expectedException.Message);
            }
        }

        [TestMethod]
        public void Transfer_When300Transferred_ShouldTransfer300FromAccountAToAccountB()
        {
            // Arrange
            var bank = new Bank();
            bank.CreateAccount("Tom", 400, AccountTypes.Checking);
            bank.CreateAccount("Jerry", 400, AccountTypes.Checking);

            // Act
            bank.Transfer(300, "Tom", "Jerry");

            // Assert
            Assert.AreEqual(100, bank.Accounts[0].Balance);
            Assert.AreEqual(700, bank.Accounts[1].Balance);
        }

        [TestMethod]
        public void Transfer_WhenTransferAmountIsTooGreat_ShouldThrowBalanceTooLowToTransferException()
        {
            // Arrange
            var bank = new Bank();
            bank.CreateAccount("Tom", 400, AccountTypes.Checking);
            bank.CreateAccount("Jerry", 400, AccountTypes.Checking);

            // Act
            try
            {
                bank.Transfer(100000, "Tom", "Jerry");
                Assert.Fail("Expected a BalanceTooLowToTransferException, but instead succeeded.");
            }
            catch (BalanceTooLowToTransferException expectedException)
            {
                Assert.AreEqual(
                    $"{ bank.Accounts[0].Owner } only has a balance of { bank.Accounts[0].Balance}. Please enter a value lower than { bank.Accounts[0].Balance}",
                    expectedException.Message);
            }
        }
    }
}
