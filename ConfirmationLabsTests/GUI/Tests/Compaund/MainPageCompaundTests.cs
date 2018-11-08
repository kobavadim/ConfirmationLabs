using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Application.Compaund;


namespace ConfirmationLabsTests.GUI.Tests.Compaund
{

    [TestFixture]
    class MainPageCompaundTests
    {

        [SetUp]
        public void TestInitialize()
        {
            Browser.StartFirefox();
            Browser.StartWithExstension(); 
        }

        [Category("Compound")]
        [Test]
        public void LendToLiquidityTableAvailabilityTest()
        {
            MainPageCompaund.VerifyLendToLiquidityPoolTableisOpened();
        }

        [Category("Compound")]
        [Test]
        public void LendToLiquidityPoolFinctionaltityTest()
        {
            MainPageCompaund.VerifyTokenCanbeLounedtoLiquidityPool();
        }

        [Category("Compound")]
        [Test]
        public void WithdrawFinctionaltityTest()
        {
            MainPageCompaund.VerifyTokensCanBeWithdrawn();
        }

        [Category("Compound")]
        [Test]
        public void BorrowFinctionaltityTest()
        {
            MainPageCompaund.VerifyBorrowFunctionality();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

    }
}
