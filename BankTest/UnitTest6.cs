using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class AccountFrozen
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Credit_WhenAccountIsFrozen_ShouldThrowException()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.FreezeAccountTest();
            account.Credit(creditAmount);

            // assert is handled by ExpectedException
            try
            {
                account.Credit(creditAmount);
            }
            catch (Exception e)
            {
                // assert
                StringAssert.Contains(e.Message, "Account frozen");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
