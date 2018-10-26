using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = ConfirmationLabsTests.Helpers.Assert;

namespace ConfirmationLabsTests.GUI.Application.Compaund
{
    class MainPageCompaund
    {

        //Elements

        private static readonly By TermsAndCOnditionsCheckBox = By.CssSelector("div.terms-checkbox > label > input");
        private static readonly By Continuebtn = By.CssSelector("button.btn-green");
        private static readonly By Table = By.CssSelector(".content-table-row");
        private static readonly By AssetsNames = By.CssSelector(".content-table-cell:nth-child(1) .top-cell");
        private static readonly By Price = By.CssSelector(".w-10 .bottom-cell");
        private static readonly By Lendbtn = By.CssSelector(".btn-red");
        private static readonly By Borrowed = By.CssSelector(".btn-green");
        private static readonly By Balancetable = By.CssSelector(".balances-table__table-wrapper");
        static string Env = "";

        //Methods

        public static void OpenCompaund()
        {
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();

            string Env = Helpers.TestData.DefineBaseUrlDependingOnEnvironment();
            if (Env == "PROD")
            {
                Console.WriteLine("running tests on PROD " + TestData.Urls.CompaundProd);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.CompaundProd);
            }
            else
            {
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.CompaundKovan);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.CompaundKovan);
            }

            Browser.MiddlePause();

        }



        public static void TermsandConditionAceptance()
        {
            IWebElement termschecbox = Browser.CurrentBrowser.FindElement(TermsAndCOnditionsCheckBox);
            termschecbox.Click();
            Browser.ShortPause();

            IList<IWebElement> continuebtns = Browser.CurrentBrowser.FindElements(By.CssSelector("button.btn-green"));

            foreach(var con in continuebtns)
            {
                if(con.Text.Contains("Continue"))
                {
                    con.Click();
                    break;
                }
            }
        }


        //Tests

        public static void VerifyPageisOpened()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement table = Browser.CurrentBrowser.FindElement(Table);
            Assert.IsTrue(table.Displayed, "[" + Env + "] COMPOUND", "Compound page is not loaded properly");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "COMPOUND", exception);
            }
        }

        public static void VerifyAssetsDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement assets = Browser.CurrentBrowser.FindElement(AssetsNames);

            Assert.IsTrue(assets.Displayed, "[" + Env + "] COMPOUND", "Assets are not displayed properly");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "COMPOUND", exception);
            }


        }

        public static void VerifyPriceDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IList<IWebElement> prices = Browser.CurrentBrowser.FindElements(Price);
            foreach (var price in prices)
            {
                Assert.IsTrue(price.Text.Contains("USD"), "[" + Env + "] COMPOUND", "Prices are displayed not properly");
            }
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "COMPOUND", exception);
            }
        }

        public static void VerifyLendBtnDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement lend = Browser.CurrentBrowser.FindElement(Lendbtn);

            Assert.IsTrue(lend.Displayed, "[" + Env + "] COMPOUND", "Lend button is not displayed");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "COMPOUND", exception);
            }
        }

        public static void VerifyBorrowdBtnDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement borrow = Browser.CurrentBrowser.FindElement(Borrowed);
            Assert.IsTrue(borrow.Displayed, "[" + Env + "] COMPOUND", "Borrow button is not displayed");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "COMPOUND", exception);
            }
        }

        public static void VerifyBalanceTableDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();

            IWebElement balance = Browser.CurrentBrowser.FindElement(Balancetable);
            Assert.IsTrue(balance.Displayed, "[" + Env + "] COMPOUND", "Balance table is not displayed");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "COMPOUND", exception);
            }
        }

    }
}
