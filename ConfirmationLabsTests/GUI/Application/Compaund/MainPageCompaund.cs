using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using NUnit.Framework;
using OpenQA.Selenium;

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
        private static readonly By Lendbtn = By.ClassName(".btn-red");
        private static readonly By Borrowed = By.CssSelector(".btn-green");
        private static readonly By Balancetable = By.CssSelector(".balances-table__table-wrapper");

        //Methods

        public static void OpenCompaund()
        {
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();

            string Env = Helpers.TestData.DefineBaseUrlDependingOnEnvironment();
            if (Env == "PROD")
            {
                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.CompaundProd);
                //var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
                //Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
                //Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.CompaundProd);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.CompaundProd);
            }
            else
            {
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.CompaundKovan);
                //var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
                //Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
                ////Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.MetaMaskWeb);
                ////Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[2]);
                //Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardProd);

                //Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, TestData.Urls.CompaundKovan);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.CompaundKovan);


            }

            Browser.MiddlePause();

        }



        public static void TermsandConditionAceptance()
        {
            IWebElement termschecbox = Browser.CurrentBrowser.FindElement(TermsAndCOnditionsCheckBox);
            termschecbox.Click();
            Browser.ShortPause();

            IList<IWebElement> continuebtns = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector("button.btn-green"));

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
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement table = Browser.CurrentBrowser.FindElement(Table);
            Assert.IsTrue(table.Displayed);
        }

        public static void VerifyAssetsDisplayed()
        {
            OpenCompaund();
            TermsandConditionAceptance();
            IList<IWebElement> assets = Browser.CurrentBrowser.FindElements(AssetsNames);

            Assert.IsTrue(assets[0].Text.Contains("wETH"));
            Assert.IsTrue(assets[1].Text.Contains("BAT"));
            Assert.IsTrue(assets[2].Text.Contains("REP"));
            Assert.IsTrue(assets[3].Text.Contains("ZRX"));


        }

        public static void VerifyPriceDisplayed()
        {
            OpenCompaund();
            TermsandConditionAceptance();
            IList<IWebElement> prices = Browser.CurrentBrowser.FindElements(Price);
            foreach (var price in prices)
            {
                Assert.IsTrue(price.Text.Contains("USD"));
            }
        }

        public static void VerifyLendBtnDisplayed()
        {
            OpenCompaund();
            TermsandConditionAceptance();
            IList<IWebElement> lend = Browser.CurrentBrowser.FindElements(Lendbtn);
            Assert.IsTrue(lend.Count.Equals(4));
        }

        public static void VerifyBorrowdBtnDisplayed()
        {
            OpenCompaund();
            TermsandConditionAceptance();
            IList<IWebElement> borrow = Browser.CurrentBrowser.FindElements(Borrowed);
            Assert.IsTrue(borrow.Count.Equals(4));
        }

        public static void VerifyBalanceTableDisplayed()
        {
            OpenCompaund();
            TermsandConditionAceptance();

            IWebElement balance = Browser.CurrentBrowser.FindElement(Balancetable);
            Assert.IsTrue(balance.Displayed);

        }

    }
}
