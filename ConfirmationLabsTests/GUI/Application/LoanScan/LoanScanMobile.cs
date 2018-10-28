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
        static string Env = "";
        private static readonly By DharmaLoanProtocol = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(2) > div.btn-group.btn-group-toggle > label:nth-of-type(1)");
        private static readonly By MakerDaoLoanProtocol = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(2) > div.btn-group.btn-group-toggle > label:nth-of-type(2)");
        private static readonly By AllLoanProtocol = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(2) > div.btn-group.btn-group-toggle > label:nth-of-type(3)");
        private static readonly By HoursTab = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(3) > div.btn-group.btn-group-toggle > label:nth-of-type(1)");
        private static readonly By SevenDaysTab = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(3) > div.btn-group.btn-group-toggle > label:nth-of-type(2)");
        private static readonly By ThirtyDaysTab = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(3) > div.btn-group.btn-group-toggle > label:nth-of-type(3)");
        private static readonly By TermonBanner = By.CssSelector("b+ b");
        private static readonly By SearchInput = By.CssSelector("#search");
        private static readonly By SearchBtn = By.CssSelector(".btn-primary");
        private static readonly By FoundLendingProtocol = By.CssSelector("td:nth-child(12)");
        private static readonly By PAginationElements3rdPage = By.CssSelector(".page-item:nth-child(5) .page-link");
        private static readonly By CreationDate = By.CssSelector("td:nth-child(2) .nowrap");
        private static readonly By LastPageNavigationIcon = By.CssSelector(".page-item:nth-child(9) span");
        private static readonly By PreviousPageIcon = By.CssSelector(".page-item:nth-child(2) span");
        private static readonly By FirstPageNavigationIcon = By.CssSelector(".page-item:nth-child(1) span");
        private static readonly By NextPageNavigationIcon = By.CssSelector(".page-item:nth-child(8) span");





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
            try
            {
                Open();
                IWebElement usdcurr = Engine.Browser.CurrentBrowser.FindElement(UsdCurrency);
                usdcurr.Click();
                Engine.Browser.MiddlePause();
                IWebElement usdicon = Engine.Browser.CurrentBrowser.FindElement(UsdIconBanner);
                Assert.IsTrue(usdicon.Text.Contains("$"), "LOANSCAN Mobile", "The currency on banner is not displayed as expected");

                IWebElement eth = Engine.Browser.CurrentBrowser.FindElement(EthCurr);
                eth.Click();
                Engine.Browser.MiddlePause();
                IWebElement ethicon = Engine.Browser.CurrentBrowser.FindElement(UsdIconBanner);
                Assert.IsTrue(ethicon.Text.Contains("ETH"), "LOANSCAN Mobile", "The currency on banner is not displayed as expected");

                IWebElement btc = Engine.Browser.CurrentBrowser.FindElement(BtcCurr);
                btc.Click();
                Engine.Browser.MiddlePause();
                IWebElement btcicon = Engine.Browser.CurrentBrowser.FindElement(UsdIconBanner);
                Assert.IsTrue(btcicon.Text.Contains("BTC"), "LOANSCAN Mobile", "The currency on banner is not displayed as expected");




            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LoanScan Mobile", exception);
            }
        }

        public static void VerifyLendingProtocolsAvailability()
        {
            try
            {
                Open();
                IWebElement all = Engine.Browser.CurrentBrowser.FindElement(AllLoanProtocol);
                string allvalue = all.Text;
                IWebElement dharma = Engine.Browser.CurrentBrowser.FindElement(DharmaLoanProtocol);
                string dhvalue = dharma.Text;
                IWebElement makerdao = Engine.Browser.CurrentBrowser.FindElement(MakerDaoLoanProtocol);
                string mkvalue = makerdao.Text;
                Assert.IsTrue(allvalue.Contains("All"), "LOANSCAN Mobile", "The landing protocol is not switched as expected");
                Assert.IsTrue(dhvalue.Contains("Dharma"), "LOANSCAN Mobile", "The landing protocol is not switched as expected");
                Assert.IsTrue(mkvalue.Contains("Maker DAO"), "LOANSCAN Mobile", "The landing protocol is not switched as expected");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LoanScan Mobile", exception);
            }
        }

        public static void VerifyTermSwitch()
        {

            try
            {

                Open();

                IWebElement hoursTerm = Engine.Browser.CurrentBrowser.FindElement(HoursTab);
                hoursTerm.Click();
                Engine.Browser.MiddlePause();
                IWebElement bannervaluehours = Engine.Browser.CurrentBrowser.FindElement(TermonBanner);
                Assert.IsTrue(bannervaluehours.Text.Contains("24 hours"), "LoanScan Mobile", "The term is not switched as expected");

                IWebElement sevenTerm = Engine.Browser.CurrentBrowser.FindElement(SevenDaysTab);
                sevenTerm.Click();
                Engine.Browser.MiddlePause();
                IWebElement bannervalueSevenDays = Engine.Browser.CurrentBrowser.FindElement(TermonBanner);
                Assert.IsTrue(bannervalueSevenDays.Text.Contains("7 days"), "LoanScan Mobile", "The term is not switched as expected");


                IWebElement thirtyTerm = Engine.Browser.CurrentBrowser.FindElement(ThirtyDaysTab);
                thirtyTerm.Click();
                Engine.Browser.MiddlePause();
                IWebElement bannervalueThirtyDays = Engine.Browser.CurrentBrowser.FindElement(TermonBanner);
                Assert.IsTrue(bannervalueThirtyDays.Text.Contains("30 days"), "LoanScan Mobile", "The term is not switched as expected");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LoanScan Mobile", exception);
            }




        }

        public static void VerifySearchPerformed()
        {
            try
            {
                Open();
                IWebElement searchinput = Engine.Browser.CurrentBrowser.FindElement(SearchInput);
                searchinput.SendKeys("Dharma");
                IWebElement searchbtn = Engine.Browser.CurrentBrowser.FindElement(SearchBtn);
                searchbtn.Click();
                Engine.Browser.ShortPause();

                IList<IWebElement> values = Engine.Browser.CurrentBrowser.FindElements(FoundLendingProtocol);
                foreach (var value in values)
                {
                    string result = value.Text;
                    Assert.IsTrue(result.Contains("Dharma"), "[" + Env + "] LOANSCAN Mobile", "LoanScan search is not working as expected");

                }
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LoanScan Mobile", exception);
            }
        }

        public static void VerifyPagination()
        {
            try
            {
                Open();
                IWebElement paginationbox = Engine.Browser.CurrentBrowser.FindElement(PAginationElements3rdPage);
                paginationbox.Click();
                Engine.Browser.MiddlePause();
                IList<IWebElement> creationcolumn = Engine.Browser.CurrentBrowser.FindElements(CreationDate);
                Assert.IsTrue(creationcolumn.Count.Equals(50), "[" + Env + "] LOANSCAN MOBILE", "The table seems to be broken");

                IWebElement lastpagenavigationicon = Engine.Browser.CurrentBrowser.FindElement(LastPageNavigationIcon);
                Assert.IsTrue(creationcolumn.Count.Equals(50), "[" + Env + "] LOANSCAN MOBILE", "The navigation bar by the table seems to be broken");

                IWebElement previouspageicon = Engine.Browser.CurrentBrowser.FindElement(PreviousPageIcon);
                Assert.IsTrue(creationcolumn.Count.Equals(50), "[" + Env + "] LOANSCAN MOBILE", "The navigation bar by the table seems to be broken");

                IWebElement firsticon = Engine.Browser.CurrentBrowser.FindElement(FirstPageNavigationIcon);
                Assert.IsTrue(creationcolumn.Count.Equals(50), "[" + Env + "] LOANSCAN MOBILE", "The navigation bar by the table seems to be broken");

                IWebElement nexticon = Engine.Browser.CurrentBrowser.FindElement(NextPageNavigationIcon);
                Assert.IsTrue(creationcolumn.Count.Equals(50), "[" + Env + "] LOANSCAN MOBILE", "The navigation bar by the table seems to be broken");

            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LoanScan Mobile", exception);
            }
        }

    }

}
