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
                IWebElement loanamount = Engine.Browser.CurrentBrowser.FindElement(LoanAmount);
                string amount = loanamount.Text;

                string[] stringSeparators = new string[] { "$" };
                var result = amount.Split(stringSeparators, StringSplitOptions.None);


                firstrow.Click();
                Engine.Browser.MiddlePause();

                IWebElement loanamountcard = Engine.Browser.CurrentBrowser.FindElement(LaonAmountCard);
                Assert.IsTrue(loanamountcard.Text.Contains(result[1]));
            }
            catch (Exception)
            {
                SlackClient.PostMessage("VerifySingleCardOpening" + " test failed. Please check Loanscan system manualy...");
            }
            


        }

        public static void VerifyDataonDharmaCardcorrespondsDataFromTable()
        {
            Open();
            IWebElement dharmacolumn = Engine.Browser.CurrentBrowser.FindElement(DharmaColumn);
            dharmacolumn.Click();
            Engine.Browser.MiddlePause();

            IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);



        }


    }
}
