using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Assert = ConfirmationLabsTests.Helpers.Assert;

namespace ConfirmationLabsTests.GUI.Application.LoanScan
{
    class LoanScanMobile
    {
        //ELEMENTS
        private static readonly By UsdCurrency = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(1) > div.btn-group.btn-group-toggle > label:nth-of-type(3)");
        private static readonly By EthCurr = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(1) > div.btn-group.btn-group-toggle > label:nth-of-type(2)");
        private static readonly By BtcCurr = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(1) > div.btn-group.btn-group-toggle > label:nth-of-type(1)");
        private static readonly By UsdIconBanner = By.CssSelector("div > b:nth-of-type(3)");


        //METHODS

        public static void Open()
        {

            string Env = Helpers.TestData.DefineBaseUrlDependingOnEnvironment();
            if (Env == "PROD")
            {
                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.LoanScanMainPageProd);
                Engine.Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.LoanScanMainPageProd);
            }
            else
            {
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.LoanScanMainPageKovan);
                Engine.Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.LoanScanMainPageKovan);
            }

            Engine.Browser.MiddlePause();

        }




        //TESTS

        public static void VerifyCurrencySwitchedonMobile()
        {
            Open();
            IWebElement usdcurr = Engine.Browser.CurrentBrowser.FindElement(UsdCurrency);
            usdcurr.Click();
            Engine.Browser.MiddlePause();
            IWebElement usdicon = Engine.Browser.CurrentBrowser.FindElement(UsdIconBanner);
            Assert.IsTrue(usdicon.Text.Contains("$"), "LOANSCAN Mobile", "The currency on banner is not displayed as expected");
        }



    }
}
