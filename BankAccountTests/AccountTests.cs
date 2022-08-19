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
            acc = new Account("J Doe");
        }
        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.999)]
        [DataRow(9_999.99)]
        //[TestCategory("Deposit")]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);

        }
        [TestMethod]
        //[TestCategory("Deposit")]
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
        //[TestCategory("Deposit")]
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
        //[TestCategory("Withdraw")]
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
        [DataRow(100, 50)]
        [DataRow(100, .99)]
        //[TestCategory("Withdraw")]
        public void Withdraw_positiveAmount_ReturnsUpdatedBalance(double initialDeposit, double withdrawAmount)
        {
            // Arrange
            double expectedBalance = initialDeposit - withdrawAmount;
            acc.Deposit(initialDeposit);
            // Act
            double returnedBalance = acc.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(expectedBalance, returnedBalance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        //[TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawAmount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        //[TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            double withdrawAmount = 1000;                                 
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentExcetion()
        {
            //this is pretty much an if statement when you think about it
            // its just formed differently
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = "   ");
        }

        [TestMethod]
        [DataRow("Brandon")]
        [DataRow("Brandon Carroll")]
        [DataRow("Brandon Kyle Carroll")]
        public void Owner_SetAsUpTp20Characters_SetsSuccessfully(string ownerName)
        {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }
        [TestMethod]
        [DataRow("Brandon 3rd")]
        [DataRow("Brandon Kyle Carroll this is over twenty one chars")]
        [DataRow("#$%^")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}