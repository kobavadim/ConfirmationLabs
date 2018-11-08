﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = ConfirmationLabsTests.Helpers.Assert;
using System.Collections.ObjectModel;


namespace ConfirmationLabsTests.GUI.Application.Compaund
{
    class MainPageCompaund
    {

        //Elements
        private static readonly By TermsAndCOnditionsCheckBox = By.CssSelector("div.terms-checkbox > label > input");
        private static readonly By Continuebtn = By.CssSelector("div.modal-footer > button.btn-green");
        private static readonly By LendBtn = By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(2)");
        private static readonly By LendToLiquidityTable = By.CssSelector(".on-demand-wrapper");
        static string Env = TestData.DefineEnvironmentDependingOnEnvironment();
        private static readonly By LendRepBtn = By.CssSelector("div.content-table-body > div:nth-of-type(3) > div:nth-of-type(4) > div.top-cell.actions-cell > div:nth-of-type(2) > button.action-btn.btn-red");
        private static readonly By LendAMountImput = By.CssSelector("[name='amount']");
        private static readonly By ConfirmLendRedButton = By.CssSelector("button.on-demand-modal__button.btn-red");
        private static readonly By LoanedAmount = By.CssSelector("div.content-table-body > div:first-child > div.content-table-cell.amount-cell > div.amount-cell.amount-cell-deposit > div.amount-cell-value > div.top-cell");
        private static readonly By LoanedRep = By.CssSelector("div.content-table-body > div:nth-of-type(3) > div.content-table-cell.amount-cell > div.amount-cell.amount-cell-deposit > div.amount-cell-value > div.top-cell");
        private static readonly By WithdrawBtn = By.CssSelector("div.content-table-body > div:nth-of-type(3) > div:nth-of-type(5) > div.top-cell.actions-cell > div:nth-of-type(2) > button.action-btn.btn-green");
        private static readonly By ConfirmationMessage = By.CssSelector("div.on-demand-modal__response-message");
        private static readonly By ConfirmWithdrawBtn = By.CssSelector("button.on-demand-modal__button.btn-green");
        private static readonly By BorrowBtn = By.CssSelector(".btn-green");
        private static readonly By BorrowGreenBtn = By.CssSelector("button.on-demand-modal__button.btn-green");
        private static readonly By BorrowMessage = By.CssSelector("div.on-demand-modal__response-message");
        private static readonly By RepayBtn = By.CssSelector(".action-btn");
        private static readonly By RepayGreenBtn = By.CssSelector("button.on-demand-modal__button.btn-red");
        


        //Methods

        public static void OpenBloqBoard()
        {
            Console.WriteLine("Logging Metamask");
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();
            string Env = Helpers.TestData.DefineEnvironmentDependingOnEnvironment();
            if (Env == "PROD")
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }

                Browser.MiddlePause();
                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.BloqBoardProd);

                //try
                //{
                //    Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardProd);
                //}
                //catch (Exception ex)
                //{
                //    IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.CurrentBrowser;
                //    js.ExecuteScript("return window.stop");
                //}
            }
            else
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }

                Browser.MiddlePause();
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.BloqBoardStaging);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardStaging);
            }

            Engine.Browser.LongPause();

        }
                
        public static void TermsandConditionAceptance()
        {
            IWebElement termschecbox = Browser.CurrentBrowser.FindElement(TermsAndCOnditionsCheckBox);
            termschecbox.Click();
            Browser.ShortPause();
            IWebElement continuebtn = Browser.CurrentBrowser.FindElement(Continuebtn);
            continuebtn.Click();
            Browser.MiddlePause();
        }



        //Tests

        public static void VerifyLendToLiquidityPoolTableisOpened()
        {
            try
            {
                Wallets.LoginToMetaMaskWallet();
                Browser.MiddlePause();

                ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;


                string MetamaskTab = handles[0];
                string BloqboardTab = handles[1];

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Lend);
                Browser.MiddlePause();

                TermsandConditionAceptance();
                Browser.MiddlePause();

                IWebElement table = Browser.CurrentBrowser.FindElement(LendToLiquidityTable);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "Lend to liquidity table is not loaded correctly");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyTokenCanbeLounedtoLiquidityPool()
        {
            try
            {
                OpenBloqBoard();
                ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

                string MetamaskTab = handles[0];
                string BloqboardTab = handles[1];
                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Lend);

                Browser.MiddlePause();
                TermsandConditionAceptance();

                Browser.MiddlePause();

                IWebElement loanedRepamount = Browser.CurrentBrowser.FindElement(LoanedRep);
                string[] stringSeparators = new string[] { "." };
                var result = loanedRepamount.Text.Split(stringSeparators, StringSplitOptions.None);

                double loanedRep = double.Parse(result[0]);


                IWebElement lendbtn = Browser.CurrentBrowser.FindElement(LendRepBtn);
                lendbtn.Click();
                Browser.ShortPause();
                IWebElement amount = Browser.CurrentBrowser.FindElement(LendAMountImput);
                amount.SendKeys("1");
                Browser.MiddlePause();
                IWebElement confirm = Browser.CurrentBrowser.FindElement(ConfirmLendRedButton);
                confirm.Click();
                Browser.MiddlePause();



                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                Browser.LongPause();
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.ShortPause();

                Console.WriteLine("Confirming request...");
                BloqBoard.MainPageBB.SignRequest();

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();
                IWebElement loanedAmount = Browser.CurrentBrowser.FindElement(LoanedAmount);
                string loanedamounttext = loanedAmount.Text;
                string[] stringSeparators2 = new string[] { "." };
                var result2 = loanedamounttext.Split(stringSeparators2, StringSplitOptions.None);
                double loaned = double.Parse(result2[0]);
                Assert.IsTrue(loaned - loanedRep == 1, "[" + Env + "] BLOQBOARD", "Lend functionality is not working as expected");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyTokensCanBeWithdrawn()
        {
            try
            {


                OpenBloqBoard();
                ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

                string MetamaskTab = handles[0];
                string BloqboardTab = handles[1];
                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Lend);

                Browser.MiddlePause();
                TermsandConditionAceptance();

                Browser.MiddlePause();

                IWebElement withdrawBtnt = Browser.CurrentBrowser.FindElement(WithdrawBtn);
                withdrawBtnt.Click();
                IWebElement amount = Browser.CurrentBrowser.FindElement(LendAMountImput);
                amount.SendKeys("1");
                Browser.MiddlePause();
                IWebElement confirm = Browser.CurrentBrowser.FindElement(ConfirmWithdrawBtn);
                confirm.Click();
                Browser.MiddlePause();

                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                Browser.LongPause();
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.ShortPause();

                Console.WriteLine("Confirming request...");
                BloqBoard.MainPageBB.SignRequest();

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();
                IWebElement msg = Browser.CurrentBrowser.FindElement(ConfirmationMessage);
                Assert.IsTrue(msg.Text.Contains("successfully"), "[" + Env + "] BLOQBOARD", "Withdraw functionality is not working properly");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }

        }

        public static void VerifyBorrowFunctionality()
        {
            OpenBloqBoard();
            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

            string MetamaskTab = handles[0];
            string BloqboardTab = handles[1];
            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Lend);

            Browser.MiddlePause();
            TermsandConditionAceptance();

            Browser.MiddlePause();
            IWebElement borrowbtn = Browser.CurrentBrowser.FindElement(BorrowBtn);
            borrowbtn.Click();

            IWebElement borrowinput = Browser.CurrentBrowser.FindElement(LendAMountImput);
            borrowinput.SendKeys("0.1");
            Browser.MiddlePause();

            IWebElement greenbtn = Browser.CurrentBrowser.FindElement(BorrowGreenBtn);
            greenbtn.Click();
            Browser.ShortPause();

            Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
            Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
            Browser.LongPause();
            Browser.CurrentBrowser.Navigate().Refresh();
            Browser.ShortPause();

            Console.WriteLine("Confirming request...");
            BloqBoard.MainPageBB.SignRequest();

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.LongPause();

            IWebElement msg = Browser.CurrentBrowser.FindElement(BorrowMessage);
            Assert.IsTrue(msg.Text.Contains("successfully"), "[" + Env + "] BLOQBOARD", "Borrow functionlaity is not working as expected");


        }

        public static void VerifyRepaytoLiquidityPoolFunctionality()
        {
            OpenBloqBoard();
            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

            string MetamaskTab = handles[0];
            string BloqboardTab = handles[1];
            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Lend);

            Browser.MiddlePause();
            TermsandConditionAceptance();

            Browser.MiddlePause();

            IList<IWebElement> repaybtns = Browser.CurrentBrowser.FindElements(RepayBtn);
            foreach (var btn in repaybtns)
            {
                string btnvalue = btn.Text;
                if(btnvalue.Contains("REPAY"))
                {
                    btn.Click();
                    break;
                }
            }
            Browser.ShortPause();
            IWebElement amountinput = Browser.CurrentBrowser.FindElement(LendAMountImput);
            amountinput.SendKeys("0.1");

            IWebElement greenbtn = Browser.CurrentBrowser.FindElement(RepayGreenBtn);
            greenbtn.Click();
            Browser.ShortPause();

            Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
            Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
            Browser.LongPause();
            Browser.CurrentBrowser.Navigate().Refresh();
            Browser.ShortPause();

            Console.WriteLine("Confirming request...");
            BloqBoard.MainPageBB.SignRequest();

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.LongPause();

            IWebElement msg = Browser.CurrentBrowser.FindElement(BorrowMessage);
            Assert.IsTrue(msg.Text.Contains("successfully"), "[" + Env + "] BLOQBOARD", "Repay functionlaity is not working as expected");


        }

    }

}

