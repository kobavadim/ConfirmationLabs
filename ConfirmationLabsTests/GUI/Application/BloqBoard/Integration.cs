using System;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace ConfirmationLabsTests.GUI.Application.BloqBoard
{
    class Integration
    {
        //Elements
        private static readonly By Token = By.CssSelector("div.issued-table-body > div:first-child > div.body-item.amount-item.text-right");
        private static readonly By APR = By.CssSelector("div.issued-table-body > div:first-child > div.body-item.rate-item.text-right");
        private static readonly By Term = By.CssSelector("div.issued-table-body > div:first-child > div.body-item.term-item.text-right");
        private static readonly By Date = By.CssSelector("div.issued-table-body > div:first-child > div.body-item.date-item");

        private static readonly By TokenLoanScan = By.CssSelector("dl.row > dd:nth-of-type(2) > span");
        private static readonly By DateLoanScan = By.CssSelector("dl.row > dd:nth-of-type(5) > span");
        private static readonly By TermLoanScan = By.CssSelector("dl.row > dd:nth-of-type(3) > span");
        static string Env = TestData.DefineEnvironmentDependingOnEnvironment();


        //Methods



        //Tests
        public static void VerifyDatefromRecentLoans()
        {
            MainPageBB.LoginToMetamaskIntegration();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handlesMain = Browser.CurrentBrowser.WindowHandles;

            string BloqboardTabMain = handlesMain[1];

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabMain);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");

            Browser.MiddlePause();
            MainPageBB.TermsandConditionAceptance();
            Browser.MiddlePause();

            string[] stringSeparator = { " " };
            IWebElement date = Browser.CurrentBrowser.FindElement(Date);
            var datetime = date.Text.Split(stringSeparator, StringSplitOptions.None);
            string[] stringSeparatorDate = { "-" };
            var datevalues = datetime[0].Split(stringSeparatorDate, StringSplitOptions.None);

            string[] stringSeparatorColumn = { ":" };
            var timevalue = datetime[1].Split(stringSeparatorColumn, StringSplitOptions.None);
            IWebElement term = Browser.CurrentBrowser.FindElement(Term);
            term.Click();

            Browser.MiddlePause();
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

            string LoanScan = handles[2];
            Browser.CurrentBrowser.SwitchTo().Window(LoanScan);

            IWebElement dateloanscan = Browser.CurrentBrowser.FindElement(DateLoanScan);
            var datevaluesloanscan  = dateloanscan.Text.Split(stringSeparator, StringSplitOptions.None);
            var dayvalue = datevaluesloanscan[0].Split(stringSeparatorDate, StringSplitOptions.None);
            Assert.IsTrue(dayvalue[1].Equals(datevalues[2]), "BloqBoard", "Incorrect date is displayed on the recent loans table");

            var timeloanscan = datevaluesloanscan[1].Split(stringSeparatorColumn, StringSplitOptions.None);
            Assert.IsTrue(timeloanscan[1].Equals(timevalue[1]), "BloqBoard", "Incorrect time is displayed on the recent loans table");
        }

        public static void VerifyAmountfromRecentLoans()
        {
            MainPageBB.LoginToMetamaskIntegration();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handlesMain = Browser.CurrentBrowser.WindowHandles;

            string BloqboardTabMain = handlesMain[1];

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabMain);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");

            Browser.MiddlePause();
            MainPageBB.TermsandConditionAceptance();
            Browser.MiddlePause();

            IWebElement amount = Browser.CurrentBrowser.FindElement(Token);
            string[] stringSeparator = { " " };
            var result = amount.Text.Split(stringSeparator, StringSplitOptions.None);
            string amountvalue = result[0];
            string tokenvalue = result[1];

            IWebElement term = Browser.CurrentBrowser.FindElement(Term);
            term.Click();

            Browser.MiddlePause();
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;
            string LoanScan = handles[2];
            Browser.CurrentBrowser.SwitchTo().Window(LoanScan);
            IWebElement tokenloanscan = Browser.CurrentBrowser.FindElement(TokenLoanScan);

            var tokenvaluesloanscan = tokenloanscan.Text.Split(stringSeparator, StringSplitOptions.None);
            if (!tokenvaluesloanscan[0].Contains(amountvalue))
            {
                if (!amountvalue.Contains(tokenvaluesloanscan[0]))
                {
                    throw new Exception("[" + Env + "] BloqBoard: Incorrect amountis displayed in the recent loans table. Please check manually.");
                }
            }
            Assert.IsTrue(tokenvalue.Equals(tokenvaluesloanscan[1]), "BloqBoard", "Incorrect token is displayed on the recent loans table");
        }

        public static void VerifyAPRfromRecentLoans()
        {
            MainPageBB.LoginToMetamaskIntegration();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handlesMain = Browser.CurrentBrowser.WindowHandles;

            string BloqboardTabMain = handlesMain[1];

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabMain);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");

            Browser.MiddlePause();
            MainPageBB.TermsandConditionAceptance();
            Browser.MiddlePause();

            IWebElement percent = Browser.CurrentBrowser.FindElement(By.CssSelector(".clickable-row:nth-child(1) .rate-item"));
            string percentvalue = Regex.Replace(percent.Text, @"\s+", "");

            IWebElement term = Browser.CurrentBrowser.FindElement(Term);
            term.Click();

            Browser.MiddlePause();
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

            string LoanScan = handles[2];
            Browser.CurrentBrowser.SwitchTo().Window(LoanScan);

            IWebElement percentageLoan = Browser.CurrentBrowser.FindElement(By.CssSelector("dl.row > dd:nth-of-type(4) > span"));
            Assert.IsTrue(percentageLoan.Text.Contains(percentvalue), "BloqBoard", "Incorrect loan interest rate is displayed on the recent loans table");
        }

        public static void VerifyTermfromRecentLoans()
        {
            MainPageBB.LoginToMetamaskIntegration();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handlesMain = Browser.CurrentBrowser.WindowHandles;

            string MetamaskTabMain = handlesMain[0];
            string BloqboardTabMain = handlesMain[1];

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabMain);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");

            Browser.MiddlePause();
            MainPageBB.TermsandConditionAceptance();
            Browser.MiddlePause();

            IWebElement term = Browser.CurrentBrowser.FindElement(Term);
            string termvalue = term.Text;
            term.Click();

            Browser.MiddlePause();
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

            string LoanScan = handles[2];
            Browser.CurrentBrowser.SwitchTo().Window(LoanScan);

            IWebElement termloanscan = Browser.CurrentBrowser.FindElement(TermLoanScan);
            Assert.IsTrue(termloanscan.Text.Contains(termvalue), "BloqBoard", "Incorrect term is displayed on the recent loans table");
        }
    }
}
