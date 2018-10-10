using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using NUnit.Framework;
using OpenQA.Selenium;


namespace ConfirmationLabsTests.GUI.Application.BloqBoard
{
    class MainPageBB
    {
        //Elements

        private static readonly By TermsAndCOnditionsCheckBox = By.CssSelector("div.terms-checkbox > label > input");
        private static readonly By Continuebtn = By.CssSelector("button.btn-green");
        private static readonly By MyBorrowedTokens = By.CssSelector(".app__small-table:nth-child(2) .undefined");
        private static readonly By BalanceTable = By.CssSelector(".balances-table__table-wrapper");
        private static readonly By RequesttoBorrowTable = By.CssSelector(".app__content-sub .col-sm:nth-child(1)");
        private static readonly By MyRequestsToBorrowTable = By.CssSelector(".tabs__container .undefined");
        private static readonly By MyLoanedTokens = By.CssSelector(".app__small-table~ .app__small-table+ .app__small-table");
        private static readonly By WethBtn = By.CssSelector(".wallet-info__currency_active+ .wallet-info__currency");
        private static readonly By AmountInput = By.CssSelector(".wallet-info__value-input");
        private static readonly By Wrap = By.CssSelector(".wallet-info__exchange-button+ .wallet-info__exchange-button");






        //Methods

        public static void OpenBloqBoard()
        {
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();

            string Env = Helpers.TestData.DefineBaseUrlDependingOnEnvironment();
            if (Env == "PROD")
            {
                //Browser.ShortPause();
                //IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));

                //IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                //Browser.ShortPause();
                //values[5].Click();

                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.BloqBoardProd);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardProd);
                //var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
                //Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
                //Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.BloqBoardProd);

            }
            else
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                values[5].Click();

                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.BloqBoardKovan);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardKovan);
                //Browser.CurrentBrowser.WindowHandles[0]
                //var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
                //Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
                //Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.MetaMaskWeb);
                //Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[2]);

                //Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.BloqBoardKovan);

            }

            Engine.Browser.LongPause();

        }

        public static void OpenNewTab()
        {
            var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
            Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, ""); // url is OK  
            Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[0]); // close the tab
            Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[1]); // get back to the main window

        }

        public static void TermsandConditionAceptance()
        {
            IWebElement termschecbox = Browser.CurrentBrowser.FindElement(TermsAndCOnditionsCheckBox);
            termschecbox.Click();
            Browser.LongPause();
            IWebElement continuebtn = Browser.CurrentBrowser.FindElement(Continuebtn);
            continuebtn.Click();
            Browser.LongPause();
        }

      


        //Tests

        public static void VerifyPageisOpened()
        {
            OpenBloqBoard();
            TermsandConditionAceptance();
            IWebElement table = Browser.CurrentBrowser.FindElement(MyBorrowedTokens);
            Assert.IsTrue(table.Displayed);
        }

        public static void VerifyBalanceTableDisplayed()
        {
            OpenBloqBoard();
            TermsandConditionAceptance();
            IWebElement balancetable = Browser.CurrentBrowser.FindElement(BalanceTable);
            Assert.IsTrue(balancetable.Displayed);
        }

        public static void VerifyMyRequestsToBorrowTableDisplayed()
        {
            OpenBloqBoard();
            TermsandConditionAceptance();
            IWebElement requestsTable = Browser.CurrentBrowser.FindElement(MyRequestsToBorrowTable);
            Assert.IsTrue(requestsTable.Displayed);
        }

        public static void VerifyRequestsToBorrowTableDisplayed()
        {
            OpenBloqBoard();
            TermsandConditionAceptance();
            IWebElement requestsTable = Browser.CurrentBrowser.FindElement(RequesttoBorrowTable);
            Assert.IsTrue(requestsTable.Displayed);
        }

        public static void VerifyMyLoanedTokensTableDisplayed()
        {
            OpenBloqBoard();
            TermsandConditionAceptance();
            IWebElement loanedtable = Browser.CurrentBrowser.FindElement(MyLoanedTokens);
            Assert.IsTrue(loanedtable.Displayed);
        }

        public static void VerifyUnwrapbtnDisplayed()
        {
            OpenBloqBoard();
            TermsandConditionAceptance();
            IWebElement weth = Browser.CurrentBrowser.FindElement(WethBtn);
            weth.Click();
            Browser.MiddlePause();

            
            IWebElement wrapbtn = Browser.CurrentBrowser.FindElement(Wrap);
            Assert.IsTrue(wrapbtn.Text.Contains("UNWRAP"));
        }




    }
}
