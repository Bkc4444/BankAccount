using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Data;

namespace BankAccount.Tests
{
    [TestClass()]
    

    public class AccountTests
    {
        private Account acc; // this TestInitializer needs to be private while the function its in needs to be public
        
        [TestInitialize]// This initializes the variable that is above it and below it
        public void CreateDefaultAccount()
        {
            acc = new Account("J, Doe");
        }
        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.999)]
        [DataRow(9_999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);

        }
        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert
            // Arrange
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);
            
            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]//these data rows are now data being put into the function below
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add

            //Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));
            
        }

        // Withdrawing a positive amount - decreases balance
        // Withdrawing 0 - Throws ArgumentOutRangeException
        // Withdrawing a negative amount - Throws argumentOutRange exception
        // Withdrawing more than balance - Throws argumentOutRange exception

        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawAmount = 50;
            double expectedBalance = initialDeposit - withdrawAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void Withdraw_positiveAmount_ReturnsUpdatedBalance()
        {
            Assert.Fail();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            Assert.Fail();
        }
    }
    
    
}