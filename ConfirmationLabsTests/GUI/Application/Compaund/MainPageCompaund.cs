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

        //Methods

        public static void OpenCompaund()
        {
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();

            string Env = Helpers.TestData.DefineBaseUrlDependingOnEnvironment();
            if (Env == "PROD")
            {
                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.CompaundProd);
                var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
                Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
                Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.CompaundProd);

            }
            else
            {
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.CompaundKovan);
                var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
                Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
                //Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.MetaMaskWeb);
                //Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[2]);

                Assert.AreEqual(Browser.CurrentBrowser.SwitchTo().Window(popup).Url, Helpers.TestData.Urls.CompaundKovan);

            }

            Engine.Browser.MiddlePause();

        }

       

        public static void TermsandConditionAceptance()
        {
            IWebElement termschecbox = Browser.CurrentBrowser.FindElement(TermsAndCOnditionsCheckBox);
            termschecbox.Click();
            Browser.ShortPause();
            IWebElement continuebtn = Browser.CurrentBrowser.FindElement(Continuebtn);
            continuebtn.Click();

        }




        //Tests

        public static void VerifyPageisOpened()
        {
            OpenCompaund();
            TermsandConditionAceptance();
            IWebElement table = Browser.CurrentBrowser.FindElement(Table);
            Assert.IsTrue(table.Displayed);
        }


    }
}
