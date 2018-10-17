using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConfirmationLabsTests.Helpers;
using OpenQA.Selenium;

namespace ConfirmationLabsTests.GUI.Application.LoanScan
{
    class MainPage
    {
        //Elements
        private static readonly By SearchInput = By.CssSelector("#search");
        private static readonly By SearchBtn = By.CssSelector(".btn-primary");
        private static readonly By FoundLendingProtocol = By.CssSelector("td:nth-child(12)");
        private static readonly By DharmaColumn = By.CssSelector(".mr-auto .btn-sm:nth-child(1)");
        private static readonly By MarketDaoColumn = By.CssSelector(".mr-auto .btn-sm:nth-child(2)");
        private static readonly By AllColumn = By.CssSelector(".mr-auto .btn-sm:nth-child(3)");
        private static readonly By NextPage = By.CssSelector(".page-item:nth-child(8) span");
        private static readonly By PAginationElements3rdPage = By.CssSelector(".page-item:nth-child(5) .page-link");
        private static readonly By CreationDate = By.CssSelector("td:nth-child(2) .nowrap");
        private static readonly By LastPageNavigationIcon = By.CssSelector(".page-item:nth-child(9) span");
        private static readonly By PreviousPageIcon = By.CssSelector("div.container.table-responsive > div:nth-of-type(1) > ngb-pagination > ul.pagination.pagination-sm > li:nth-of-type(2) > a.page-link > span");
        private static readonly By LastPageNumber = By.CssSelector("div.container.table-responsive > div:nth-of-type(1) > ngb-pagination > ul.pagination.pagination-sm > li:nth-of-type(7) > a.page-link");
        private static readonly By PreviousPageNumber = By.CssSelector("div.container.table-responsive > div:nth-of-type(1) > ngb-pagination > ul.pagination.pagination-sm > li:nth-of-type(6) > a.page-link");
        private static readonly By LoanAmount = By.CssSelector("th:nth-child(3)");
        private static readonly By AnnaulInterestRate = By.CssSelector("th:nth-child(4)");
        private static readonly By LoanTerm = By.CssSelector("th:nth-child(5)");
        private static readonly By LTV = By.CssSelector("th:nth-child(6)");
        private static readonly By Collateral = By.CssSelector("th:nth-child(7)");
        private static readonly By LoanStatus = By.CssSelector("th:nth-child(8)");
        private static readonly By Repaid = By.CssSelector("th:nth-child(9)");
        private static readonly By UnderwriterName = By.CssSelector("th:nth-child(10)");
        private static readonly By RelayerName = By.CssSelector("th:nth-child(11)");
        private static readonly By BtcButton = By.CssSelector(".col-md-4:nth-child(1) .btn-sm:nth-child(1)");
        private static readonly By EthButton = By.CssSelector(".col-md-4:nth-child(1) .btn-sm:nth-child(2)");
        private static readonly By UsdButton = By.CssSelector(".col-md-4:nth-child(1) .btn-sm:nth-child(3)");
        private static readonly By CurrencyBanner = By.CssSelector("span+ b");
        private static readonly By DharmaLoanProtocol = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(2) > div.btn-group.btn-group-toggle > label:nth-of-type(1)");
        private static readonly By MakerDaoLoanProtocol = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(2) > div.btn-group.btn-group-toggle > label:nth-of-type(2)");
        private static readonly By AllLoanProtocol = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(2) > div.btn-group.btn-group-toggle > label:nth-of-type(3)");
        private static readonly By HoursTab = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(3) > div.btn-group.btn-group-toggle > label:nth-of-type(1)");
        private static readonly By SevenDaysTab = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(3) > div.btn-group.btn-group-toggle > label:nth-of-type(2)");
        private static readonly By ThirtyDaysTab = By.CssSelector("div.container > div:nth-of-type(1) > div:nth-of-type(3) > div.btn-group.btn-group-toggle > label:nth-of-type(3)");
        private static readonly By TermonBanner = By.CssSelector("b+ b");
        private static readonly By NetworkVolume = By.CssSelector("#networkVolume");
        private static readonly By AverageLoanAmount = By.CssSelector("#averageLoanAmount");
        private static readonly By MedianLoanAmount = By.CssSelector("#medianLoanAmount");
        private static readonly By TopBorrowedTokens = By.CssSelector("#topTokensByVolume");
        private static readonly By TopRelayers = By.CssSelector("#topRelayersByVolume");




        //Methods

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

        public static void PerformSearch()
        {
            IWebElement searchinput = Engine.Browser.CurrentBrowser.FindElement(SearchInput);
            searchinput.SendKeys("Dharma");
            IWebElement searchbtn = Engine.Browser.CurrentBrowser.FindElement(SearchBtn);
            searchbtn.Click();
            Engine.Browser.ShortPause();

            IList<IWebElement> values = Engine.Browser.CurrentBrowser.FindElements(FoundLendingProtocol);
            foreach (var value in values)
            {
                string result = value.Text;
                Assert.IsTrue(result.Contains("Dharma"));

            }


        }

        public static void FilteringTablebyLendingProtocol()
        {
            IWebElement dharmatab = Engine.Browser.FindElementNew(DharmaColumn);
            dharmatab.Click();
            Engine.Browser.MiddlePause();
            IList<IWebElement> values = Engine.Browser.CurrentBrowser.FindElements(FoundLendingProtocol);
            foreach (var value in values)
            {
                string result = value.Text;
                Assert.IsTrue(result.Contains("Dharma"));

            }

            IWebElement marketdaotab = Engine.Browser.FindElementNew(MarketDaoColumn);
            marketdaotab.Click();
            Engine.Browser.MiddlePause();

            IList<IWebElement> values2 = Engine.Browser.CurrentBrowser.FindElements(FoundLendingProtocol);
            foreach (var value in values2)
            {
                string result = value.Text;
                Assert.IsTrue(result.Contains("Maker DAO"));

            }
            Engine.Browser.ShortPause();


            IWebElement alltab = Engine.Browser.FindElementNew(AllColumn);
            alltab.Click();
            Engine.Browser.MiddlePause();

            int countD = 0;
            int countM = 0;

            for (int i = 0; i < 5; i++)
            {

                IList<IWebElement> values3 = Engine.Browser.CurrentBrowser.FindElements(FoundLendingProtocol);
                foreach (var value in values3)
                {
                    string result = value.Text;
                    if (result.Contains("Dharma"))
                    {
                        countD++;
                    }
                    if (result.Contains("MakerDao"))
                    {
                        countM++;
                    }
                }
                if (countD > 0 && countM > 0)
                {
                    break;
                }
                else
                {
                    IWebElement nextpageicon = Engine.Browser.CurrentBrowser.FindElement(NextPage);
                    nextpageicon.Click();
                    Engine.Browser.MiddlePause();
                }
            }
            Assert.IsTrue(countM > 0 && countD > 0);

        }

        public static void PaginationbyTheTable()
        {
            IWebElement paginationbox = Engine.Browser.CurrentBrowser.FindElement(PAginationElements3rdPage);
            paginationbox.Click();
            Engine.Browser.MiddlePause();
            IList<IWebElement> creationcolumn = Engine.Browser.CurrentBrowser.FindElements(CreationDate);
            Assert.IsTrue(creationcolumn.Count.Equals(50));

            IWebElement lastpagenavigationicon = Engine.Browser.CurrentBrowser.FindElement(LastPageNavigationIcon);
            lastpagenavigationicon.Click();
            Engine.Browser.MiddlePause();
            IWebElement selectedlastpage = Engine.Browser.CurrentBrowser.FindElement(LastPageNumber);
            string selectedpage = selectedlastpage.Text;

            Assert.IsTrue(selectedpage.Contains("current"));
            IWebElement creationcolumnlast = Engine.Browser.CurrentBrowser.FindElement(CreationDate);
            Assert.IsTrue(creationcolumnlast.Displayed);

            IWebElement previouspageicon = Engine.Browser.CurrentBrowser.FindElement(PreviousPageIcon);
            previouspageicon.Click();
            Engine.Browser.MiddlePause();

            IWebElement previouspagenumber = Engine.Browser.CurrentBrowser.FindElement(PreviousPageNumber);

            string previouspage = previouspagenumber.Text;
            Assert.IsTrue(previouspage.Contains("current"));



        }

        public static void ColumnsAvailabilityintheTable()
        {

            IWebElement loanamountcolumn = Engine.Browser.CurrentBrowser.FindElement(LoanAmount);
            Assert.IsTrue(loanamountcolumn.Text.Contains("Loan amount"));

            IWebElement annaulInterestRate = Engine.Browser.CurrentBrowser.FindElement(AnnaulInterestRate);
            Assert.IsTrue(annaulInterestRate.Text.Contains("Annual interest rate"));

            IWebElement loanterm = Engine.Browser.CurrentBrowser.FindElement(LoanTerm);
            Assert.IsTrue(loanterm.Text.Contains("Loan term"));

            IWebElement ltv = Engine.Browser.CurrentBrowser.FindElement(LTV);
            Assert.IsTrue(ltv.Text.Contains("LTV"));

            IWebElement collateral = Engine.Browser.CurrentBrowser.FindElement(Collateral);
            Assert.IsTrue(collateral.Text.Contains("Collateral"));

            IWebElement loanstatus = Engine.Browser.CurrentBrowser.FindElement(LoanStatus);
            Assert.IsTrue(loanstatus.Text.Contains("Loan status"));

            IWebElement repaid = Engine.Browser.CurrentBrowser.FindElement(Repaid);
            Assert.IsTrue(repaid.Text.Contains("% repaid"));

            IWebElement underwrirename = Engine.Browser.CurrentBrowser.FindElement(UnderwriterName);
            Assert.IsTrue(underwrirename.Text.Contains("Underwriter name"));

            IWebElement relayerName = Engine.Browser.CurrentBrowser.FindElement(RelayerName);
            Assert.IsTrue(relayerName.Text.Contains("Relayer name"));


        }

        public static void SwitchCurrency()
        {
            IWebElement btcButton = Engine.Browser.CurrentBrowser.FindElement(BtcButton);
            btcButton.Click();
            Engine.Browser.MiddlePause();
            IWebElement btconBanner = Engine.Browser.CurrentBrowser.FindElement(CurrencyBanner);
            string bannervalue = btconBanner.Text;
            Assert.IsTrue(bannervalue.Contains("BTC"));

            IWebElement ethButton = Engine.Browser.CurrentBrowser.FindElement(EthButton);
            ethButton.Click();
            Engine.Browser.MiddlePause();
            IWebElement ethonBanner = Engine.Browser.CurrentBrowser.FindElement(CurrencyBanner);
            string ethonBannervalue = ethonBanner.Text;
            Assert.IsTrue(ethonBannervalue.Contains("ETH"));

            IWebElement usdButton = Engine.Browser.CurrentBrowser.FindElement(UsdButton);
            usdButton.Click();
            Engine.Browser.MiddlePause();
            IWebElement usdonBanner = Engine.Browser.CurrentBrowser.FindElement(CurrencyBanner);
            string usdonBannervalue = usdonBanner.Text;
            Assert.IsTrue(usdonBannervalue.Contains("$"));

        }

        public static void LendingProtocolsSwitch()
        {
            IWebElement all = Engine.Browser.CurrentBrowser.FindElement(AllLoanProtocol);
            string allvalue = all.Text;
            IWebElement dharma = Engine.Browser.CurrentBrowser.FindElement(DharmaLoanProtocol);
            string dhvalue = dharma.Text;
            IWebElement makerdao = Engine.Browser.CurrentBrowser.FindElement(MakerDaoLoanProtocol);
            string mkvalue = makerdao.Text;
            Assert.IsTrue(allvalue.Contains("All"));
            Assert.IsTrue(dhvalue.Contains("Dharma"));
            Assert.IsTrue(mkvalue.Contains("Maker DAO"));

        }

        public static void TermSwitch()
        {
            IWebElement hoursTerm = Engine.Browser.CurrentBrowser.FindElement(HoursTab);
            hoursTerm.Click();
            Engine.Browser.MiddlePause();
            IWebElement bannervaluehours = Engine.Browser.CurrentBrowser.FindElement(TermonBanner);
            Assert.IsTrue(bannervaluehours.Text.Contains("24 hours"));

            IWebElement sevenTerm = Engine.Browser.CurrentBrowser.FindElement(SevenDaysTab);
            sevenTerm.Click();
            Engine.Browser.MiddlePause();
            IWebElement bannervalueSevenDays = Engine.Browser.CurrentBrowser.FindElement(TermonBanner);
            Assert.IsTrue(bannervalueSevenDays.Text.Contains("7 days"));


            IWebElement thirtyTerm = Engine.Browser.CurrentBrowser.FindElement(ThirtyDaysTab);
            thirtyTerm.Click();
            Engine.Browser.MiddlePause();
            IWebElement bannervalueThirtyDays = Engine.Browser.CurrentBrowser.FindElement(TermonBanner);
            Assert.IsTrue(bannervalueThirtyDays.Text.Contains("30 days"));






        }

        public static void ChartTabsSwitching()
        {
            IWebElement networkvolume = Engine.Browser.CurrentBrowser.FindElement(NetworkVolume);
            IWebElement averageLoanAmount = Engine.Browser.CurrentBrowser.FindElement(AverageLoanAmount);
            IWebElement medianLoanAmount = Engine.Browser.CurrentBrowser.FindElement(MedianLoanAmount);
            IWebElement topBorrowedTokens = Engine.Browser.CurrentBrowser.FindElement(TopBorrowedTokens);
            IWebElement topRelayers = Engine.Browser.CurrentBrowser.FindElement(TopRelayers);

        }


        //Tests

        public static void SearchAvailability()
        {
        

           try
        {

    IList<IWebElement> MyElements = Engine.Browser.CurrentBrowser.FindElements(By.CssSelector("[text-anchor='start']"));



            Open();
            IWebElement searchinput = Engine.Browser.CurrentBrowser.FindElement(SearchInput);
            Assert.IsTrue(searchinput.Displayed);
        }

            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void SearchFunctionality()
        {
            try
            {
                Open();
                PerformSearch();
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void FilteringTable()
        {
            try { 
            Open();
            FilteringTablebyLendingProtocol();
        }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
}

        public static void PaginationTable()
        {
            try { 
            Open();
            PaginationbyTheTable();
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void ColumnsTable()
        {
            try { 
            Open();
            ColumnsAvailabilityintheTable();
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void CurrencySwtichingTest()
        {
            try { 
            Open();
            SwitchCurrency();
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void LendingProtocolSwitch()
        {
            try
            {                            
            Open();
            LendingProtocolsSwitch();
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void TermSwitchingFunctionality()
        {
            try { 
            Open();
            TermSwitch();
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void ChartTabsAvailability()
        {
            try { 
            Open();
            ChartTabsSwitching();
                 }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }





    }
}
