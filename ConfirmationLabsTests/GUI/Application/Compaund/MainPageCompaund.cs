﻿using System;
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
        private static readonly By Lendbtn = By.CssSelector(".btn-red");
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
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement table = Browser.CurrentBrowser.FindElement(Table);
            Assert.IsTrue(table.Displayed);
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void VerifyAssetsDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement assets = Browser.CurrentBrowser.FindElement(AssetsNames);

            Assert.IsTrue(assets.Displayed);
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
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
                Assert.IsTrue(price.Text.Contains("USD"));
            }
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void VerifyLendBtnDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement lend = Browser.CurrentBrowser.FindElement(Lendbtn);

            Assert.IsTrue(lend.Displayed);
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void VerifyBorrowdBtnDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement borrow = Browser.CurrentBrowser.FindElement(Borrowed);
            Assert.IsTrue(borrow.Displayed );
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void VerifyBalanceTableDisplayed()
        {
            try { 
            OpenCompaund();
            TermsandConditionAceptance();

            IWebElement balance = Browser.CurrentBrowser.FindElement(Balancetable);
            Assert.IsTrue(balance.Displayed);
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

    }
}
