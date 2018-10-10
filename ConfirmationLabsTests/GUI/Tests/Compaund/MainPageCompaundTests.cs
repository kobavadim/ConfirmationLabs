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
            Browser.Start();
        }

        [Category("Compound")]
        [Test]
        public void PageisOpenedTest()
        {
            MainPageCompaund.VerifyPageisOpened();
        }

        [Category("Compound")]
        [Test]
        public void AssetsDisplayTest()
        {
            MainPageCompaund.VerifyAssetsDisplayed();
        }

        [Category("Compound")]
        [Test]
        public void PriceDisplayedTest()
        {
            MainPageCompaund.VerifyPriceDisplayed();
        }

        [Category("Compound")]
        [Test]
        public void LendButtonsDisplayedTest()
        {
            MainPageCompaund.VerifyLendBtnDisplayed();
        }

        [Category("Compound")]
        [Test]
        public void BorrowButtonsDisplayedTest()
        {
            MainPageCompaund.VerifyBorrowdBtnDisplayed();
        }

        [Category("Compound")]
        [Test]
        public void BalanceTableDisplayTest()
        {
            MainPageCompaund.VerifyBalanceTableDisplayed();
        }



        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

    }
}
