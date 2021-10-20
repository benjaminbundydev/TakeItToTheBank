using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeItToTheBank.Accounts;
using TakeItToTheBank.Factories;
using TakeItToTheBank.Factories.Enums;

namespace TakeItToTheBank.Tests.FactoryTests
{
    [TestClass]
    public class AccountFactoryTests
    {
        [TestMethod]
        public void CreateAccount_WhenCheckingAccountTypeIsCalledFor_ShouldReturnCheckingAccountInstance()
        {
            // Arrange
            var checkingAccount = AccountFactory.CreateAccount(AccountTypes.Checking, "Tom", 2000);

            // Act
            // Assert
            Assert.IsInstanceOfType(checkingAccount, typeof(CheckingAccount));
        }

        [TestMethod]
        public void CreateAccount_WhenSavingAccountTypeIsCalledFor_ShouldReturnSavingAccountInstance()
        {
            // Arrange
            var savingAccount = AccountFactory.CreateAccount(AccountTypes.Saving, "Tom", 2000);

            // Act
            // Assert
            Assert.IsInstanceOfType(savingAccount, typeof(SavingAccount));
        }

        [TestMethod]
        public void CreateAccount_WhenIndividualAccountTypeIsCalledFor_ShouldReturnIndividualAccountInstance()
        {
            // Arrange
            var individualAccount = AccountFactory.CreateAccount(AccountTypes.Individual, "Tom", 2000);

            // Act
            // Assert
            Assert.IsInstanceOfType(individualAccount, typeof(IndividualAccount));
        }

        [TestMethod]
        public void CreateAccount_WhenMoneyMarketAccountTypeIsCalledFor_ShouldReturnMoneyMarketAccountInstance()
        {
            // Arrange
            var corporateAccount = AccountFactory.CreateAccount(AccountTypes.Corporate, "Tom", 2000);

            // Act
            // Assert
            Assert.IsInstanceOfType(corporateAccount, typeof(CorporateAccount));
        }
    }
}
