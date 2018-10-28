﻿using System;
using System.Collections.Generic;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

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
        static string Env = "";

        private static readonly By NewRequest = By.CssSelector(".loan-table__header-btn");
        private static readonly By AmountInputbyNewRequest = By.CssSelector("[name='amount']");
        private static readonly By InterestInputByNewRequest = By.CssSelector("[name='interestRate']");
        private static readonly By CollateralAmountNewRequest = By.CssSelector("[name='collateralAmount']");
        private static readonly By AddRequestBtn = By.CssSelector("button.loan-request-form__place-btn");



        //Methods
        public static void OpenBloqBoard()
        {
            Console.WriteLine("Logging Metamask");
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();

            string Env = Helpers.TestData.DefineBaseUrlDependingOnEnvironment();
            if (Env == "PROD")
            {
                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.BloqBoardProd);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardProd);
            }
            else
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach(var val in values)
                {
                    if(val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }
 
                Browser.MiddlePause();
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.BloqBoardKovan);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardKovan);
            }

            Engine.Browser.LongPause();

        }

        public static void OpenNewTab()
        {
            var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
            //Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
            //Assert.IsTrue(Browser.CurrentBrowser.SwitchTo().Window(popup).Url == ""); // url is OK  
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

        public static void CreateNewRequest()
        {

            IWebElement createrequestbtn = Browser.CurrentBrowser.FindElement(NewRequest);
            createrequestbtn.Click();

            IWebElement amount = Browser.CurrentBrowser.FindElement(AmountInputbyNewRequest);
            amount.SendKeys("0.005");

            IWebElement interest = Browser.CurrentBrowser.FindElement(InterestInputByNewRequest);
            interest.SendKeys("5");

            IWebElement collateral = Browser.CurrentBrowser.FindElement(CollateralAmountNewRequest);
            collateral.SendKeys("0.05");



            Browser.CurrentBrowser.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");


            IWebElement create = Browser.CurrentBrowser.FindElement(AddRequestBtn);
            create.Click();




            string BaseWindow = Browser.CurrentBrowser.CurrentWindowHandle;
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;


            
            var popup1 = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
            NUnit.Framework.Assert.IsTrue(!string.IsNullOrEmpty(popup1)); // tab was opened
            NUnit.Framework.Assert.IsTrue(Browser.CurrentBrowser.SwitchTo().Window(popup1).Url == ""); // url is OK  
            Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[0]); // close the tab
            Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[1]);


   









            Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");


        }


        //Tests
        public static void VerifyPageisOpened()
        {
            try
            {
                OpenBloqBoard();
                TermsandConditionAceptance();
                IWebElement table = Browser.CurrentBrowser.FindElement(MyBorrowedTokens);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "BloqBoard page is not loaded correctly");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyBalanceTableDisplayed()
        {
            try
            {
                OpenBloqBoard();
                TermsandConditionAceptance();
                IWebElement balancetable = Browser.CurrentBrowser.FindElement(BalanceTable);
                Assert.IsTrue(balancetable.Displayed, "[" + Env + "] BLOQBOARD", "Balance Table is not loaded properly");
            
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyMyRequestsToBorrowTableDisplayed()
        {
            try
            {
                OpenBloqBoard();
                TermsandConditionAceptance();
                IWebElement requestsTable = Browser.CurrentBrowser.FindElement(MyRequestsToBorrowTable);
                Assert.IsTrue(requestsTable.Displayed, "[" + Env + "] BLOQBOARD", "My Requests to Borrow table is not loaded properly");
            
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyRequestsToBorrowTableDisplayed()
        {
            try
            {
                OpenBloqBoard();
                TermsandConditionAceptance();
                IWebElement requestsTable = Browser.CurrentBrowser.FindElement(RequesttoBorrowTable);
                Assert.IsTrue(requestsTable.Displayed, "[" + Env + "] BLOQBOARD", "Requests to borro table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyMyLoanedTokensTableDisplayed()
        {
            try
            {
                OpenBloqBoard();
                TermsandConditionAceptance();
                IWebElement loanedtable = Browser.CurrentBrowser.FindElement(MyLoanedTokens);
                Assert.IsTrue(loanedtable.Displayed, "[" + Env + "] BLOQBOARD", "My Loaned tokens table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyUnwrapbtnDisplayed()
        {
            try
            {
                OpenBloqBoard();
                TermsandConditionAceptance();
                IWebElement weth = Browser.CurrentBrowser.FindElement(WethBtn);
                weth.Click();
                Browser.MiddlePause();


                IWebElement wrapbtn = Browser.CurrentBrowser.FindElement(Wrap);
                Assert.IsTrue(wrapbtn.Text.Contains("UNWRAP"), "[" + Env + "] BLOQBOARD", "Unwrap button is not dipslayed properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyNewRequestCanbeCreated()
        {

 




            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;


            string MetamaskTab = handles[0];
            string BloqboardTab = handles[1];


            Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab); 
            Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.CurrentBrowser.Navigate().GoToUrl("https://staging.bloqboard.com/");







            Browser.MiddlePause();
            TermsandConditionAceptance();
            CreateNewRequest();



        }




    }
}
