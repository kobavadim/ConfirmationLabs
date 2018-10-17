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
    class CardPage
    {
        //ELEMENTS
        private static readonly By DharmaColumn = By.CssSelector(".mr-auto .btn-sm:nth-child(1)");
        private static readonly By Row = By.CssSelector(".loan-row:nth-child(1) .nowrap");
        private static readonly By ElementsonCardPageDharma = By.CssSelector(".col-sm-3");
        private static readonly By MakerDaoColumn = By.CssSelector("div.btn-group.btn-group-toggle.mr-auto > label:nth-of-type(2)");


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

        public static void VerifyElementsonDharmaSingleCard()
        {
            try
            {
                Open();
                IWebElement dharmacolumn = Engine.Browser.CurrentBrowser.FindElement(DharmaColumn);
                dharmacolumn.Click();
                Engine.Browser.MiddlePause();

                IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);
                firstrow.Click();
                Engine.Browser.MiddlePause();

                IList<IWebElement> elements = Engine.Browser.CurrentBrowser.FindElements(ElementsonCardPageDharma);
                Assert.IsTrue(elements[0].Text.Contains("Repayment progress"));
                Assert.IsTrue(elements[1].Text.Contains("Loan amount"));
                Assert.IsTrue(elements[2].Text.Contains("Loan term"));
                Assert.IsTrue(elements[3].Text.Contains("Loan interest rate"));
                Assert.IsTrue(elements[4].Text.Contains("Loan issuance date"));
                Assert.IsTrue(elements[5].Text.Contains("Loan maturity date"));
                Assert.IsTrue(elements[6].Text.Contains("Loan-to-value (LTV) at origination"));
                Assert.IsTrue(elements[7].Text.Contains("Loan-to-value (LTV) current"));
                Assert.IsTrue(elements[8].Text.Contains("Debtor address"));
                Assert.IsTrue(elements[9].Text.Contains("Creditor address"));
                Assert.IsTrue(elements[10].Text.Contains("Collateral"));
                Assert.IsTrue(elements[11].Text.Contains("Repayments"));
                Assert.IsTrue(elements[12].Text.Contains("Repayment frequency"));
                Assert.IsTrue(elements[13].Text.Contains("Agreement Id"));
                Assert.IsTrue(elements[14].Text.Contains("Relayer name"));
                Assert.IsTrue(elements[15].Text.Contains("Relayer address"));
                Assert.IsTrue(elements[16].Text.Contains("Relayer fees"));
                Assert.IsTrue(elements[17].Text.Contains("Underwriter name"));
                Assert.IsTrue(elements[18].Text.Contains("Underwriter address"));
                Assert.IsTrue(elements[19].Text.Contains("Underwriter fees"));
                Assert.IsTrue(elements[20].Text.Contains("Underwriter risk rating"));
                Assert.IsTrue(elements[21].Text.Contains("Loan issuance link"));
                Assert.IsTrue(elements[22].Text.Contains("Loan contract"));
                Assert.IsTrue(elements[23].Text.Contains("Lending protocol/system"));
            }
            catch(Exception)
            {
                SlackClient.PostMessage("VerifyElementsonDharmaSingleCard" + " test failed. Please check Loanscan system manualy...");
            }
        }

        public static void VerifyElementsonMakerDaoSingleCard()
        {
            try
            {
                Open();
                IWebElement column = Engine.Browser.CurrentBrowser.FindElement(MakerDaoColumn);
                column.Click();
                Engine.Browser.MiddlePause();

                IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);
                firstrow.Click();
                Engine.Browser.MiddlePause();

                IList<IWebElement> elements = Engine.Browser.CurrentBrowser.FindElements(ElementsonCardPageDharma);
                Assert.IsTrue(elements[0].Text.Contains("Repayment progress"));
                Assert.IsTrue(elements[1].Text.Contains("Loan balance"));
                Assert.IsTrue(elements[2].Text.Contains("Loan interest rate (annual)"));
                Assert.IsTrue(elements[3].Text.Contains("Loan-to-value (LTV) current"));
                Assert.IsTrue(elements[4].Text.Contains("Debtor address"));
                Assert.IsTrue(elements[5].Text.Contains("Creditor address"));
                Assert.IsTrue(elements[6].Text.Contains("Loan draws"));
                Assert.IsTrue(elements[7].Text.Contains("Collateral"));
                Assert.IsTrue(elements[9].Text.Contains("Repayments"));
                Assert.IsTrue(elements[10].Text.Contains("Cumulative liquidation fee"));
                Assert.IsTrue(elements[11].Text.Contains("CDP creation link"));
                Assert.IsTrue(elements[12].Text.Contains("Lending protocol/system"));
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifyElementsonMakerDaoSingleCard" + " test failed. Please check Loanscan system manualy...");
            }
  

        }


    }
}
