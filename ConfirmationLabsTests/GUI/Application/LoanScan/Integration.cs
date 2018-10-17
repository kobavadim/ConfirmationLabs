using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfirmationLabsTests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ConfirmationLabsTests.GUI.Application.LoanScan
{
    class Integration
    {
        //ELEMENTS

        private static readonly By Row = By.CssSelector(".loan-row:nth-child(1) .nowrap");
        private static readonly By LoanAmount = By.CssSelector(".loan-row:nth-child(1) td:nth-child(3) .nowrap");
        private static readonly By DharmaColumn = By.CssSelector(".mr-auto .btn-sm:nth-child(1)");
        private static readonly By LaonAmountCard = By.CssSelector("dl.row > dd:nth-of-type(2) > span");
        private static readonly By AnnaulInterestRateTable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(4)");
        private static readonly By LoanTermTable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(5) .nowrap");
        private static readonly By Ltvtable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(6) span");
        private static readonly By CollateralTable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(7) .nowrap");
        private static readonly By RepayedTable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(9)");
        private static readonly By UnderwriterNameTable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(10)");
        private static readonly By RelayerNameTable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(11)");
        private static readonly By LoanTermCard = By.CssSelector(".col-sm-9:nth-child(6) span");
        private static readonly By AnnualInterestRateCard = By.CssSelector("br+ span");
        private static readonly By RepayedCard = By.CssSelector(".progress-label");
        private static readonly By CollateralCard = By.CssSelector(".loan-time+ div");
        private static readonly By UnderwrietrNameCard = By.CssSelector(".col-sm-9:nth-child(38)");
        private static readonly By RelayerNameCard = By.CssSelector(".col-sm-9:nth-child(32)");


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

        //Tests

        public static void VerifySingleCardOpening()
        {
            try
            {
                Open();
                IWebElement dharmacolumn = Engine.Browser.CurrentBrowser.FindElement(DharmaColumn);
                dharmacolumn.Click();
                Engine.Browser.MiddlePause();

                IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);
                IWebElement annualintrate = Engine.Browser.CurrentBrowser.FindElement(AnnaulInterestRateTable);
                string value = annualintrate.Text;

                firstrow.Click();
                Engine.Browser.MiddlePause();

                IWebElement annualinterestratecard = Engine.Browser.CurrentBrowser.FindElement(AnnualInterestRateCard);
                Assert.IsTrue(annualinterestratecard.Text.Contains(value));
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void VerifyDataonDharmaCardcorrespondsDataFromTable()
        {
            try
            {

                Open();
                IWebElement dharmacolumn = Engine.Browser.CurrentBrowser.FindElement(DharmaColumn);
                dharmacolumn.Click();
                Engine.Browser.MiddlePause();
                IWebElement row = Engine.Browser.CurrentBrowser.FindElement(Row);

                IWebElement annaulInterestRateTable = Engine.Browser.CurrentBrowser.FindElement(AnnaulInterestRateTable);
                string annaulintRateTableValue = annaulInterestRateTable.Text;

                IWebElement loanTermTable = Engine.Browser.CurrentBrowser.FindElement(LoanTermTable);
                string loanTermtableValue = loanTermTable.Text;
                
                
                IWebElement collateralTable = Engine.Browser.CurrentBrowser.FindElement(CollateralTable);
                string collateralTableValue = collateralTable.Text;

                string[] stringSeparators = new string[] { "$" };
                var result = collateralTableValue.Split(stringSeparators, StringSplitOptions.None);


                IWebElement repayedTable = Engine.Browser.CurrentBrowser.FindElement(RepayedTable);
                string repayedTableValue = repayedTable.Text;

                IWebElement underwriterNameTable = Engine.Browser.CurrentBrowser.FindElement(UnderwriterNameTable);
                string underwriterNameTableValue = underwriterNameTable.Text;

                IWebElement relayerNameTable = Engine.Browser.CurrentBrowser.FindElement(RelayerNameTable);
                string relayerNameTableValue = relayerNameTable.Text;

                row.Click();
                Engine.Browser.MiddlePause();


                IWebElement annualInterestRateCard = Engine.Browser.CurrentBrowser.FindElement(AnnualInterestRateCard);
                string annaulVlaueCard = annualInterestRateCard.Text;
                Assert.IsTrue(annaulVlaueCard.Contains(annaulintRateTableValue));

                IWebElement repayedCard = Engine.Browser.CurrentBrowser.FindElement(RepayedCard);
                Assert.IsTrue(repayedCard.Text.Contains(repayedTableValue));

                IWebElement loanTermCard = Engine.Browser.CurrentBrowser.FindElement(LoanTermCard);
                Assert.IsTrue(loanTermCard.Text.Contains(loanTermtableValue));

                IWebElement collateralCard = Engine.Browser.CurrentBrowser.FindElement(CollateralCard);
                Assert.IsTrue(collateralCard.Text.Contains(result[1]));

                IWebElement underwritercard = Engine.Browser.CurrentBrowser.FindElement(UnderwrietrNameCard);
                Assert.IsTrue(underwritercard.Text.Contains(underwriterNameTableValue));

                IWebElement relayername = Engine.Browser.CurrentBrowser.FindElement(RelayerNameCard);
                Assert.IsTrue(relayername.Text.Contains(relayerNameTableValue));



            }

            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }



            
        }

        public static void VerifyLoanAmountisTheSameinTableandOnCard()
        {
            try
            {
                Open();
            IWebElement dharmacolumn = Engine.Browser.CurrentBrowser.FindElement(DharmaColumn);
            dharmacolumn.Click();
            Engine.Browser.MiddlePause();

            IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);

            IWebElement loanamount = Engine.Browser.CurrentBrowser.FindElement(LoanAmount);
            string loanamountvalue = loanamount.Text;
            string[] stringSeparators = new string[] { "(" };
            var result = loanamountvalue.Split(stringSeparators, StringSplitOptions.None);
            
            string token = result[0];
            string dollar = result[1];

            firstrow.Click();
            Engine.Browser.MiddlePause();

            IWebElement loanamountCard = Engine.Browser.CurrentBrowser.FindElement(LaonAmountCard);
            Assert.IsTrue(loanamountCard.Text.Contains(dollar));
            }

            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }


        }


    }
}
