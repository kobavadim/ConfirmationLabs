using System;
using System.Collections.Generic;
using ConfirmationLabsTests.Helpers;
using OpenQA.Selenium;
using Assert = ConfirmationLabsTests.Helpers.Assert;

namespace ConfirmationLabsTests.GUI.Application.LoanScan
{
    class CardPage
    {
        //ELEMENTS
        private static readonly By DharmaColumn = By.CssSelector(".mr-auto .btn-sm:nth-child(1)");
        private static readonly By Row = By.CssSelector(".loan-row:nth-child(1) .nowrap");
        private static readonly By ElementsonCardPageDharma = By.CssSelector(".col-sm-3");
        private static readonly By MakerDaoColumn = By.CssSelector("div.btn-group.btn-group-toggle.mr-auto > label:nth-of-type(2)");
        static string Env = "";

        //METHODS

        public static void Open()
        {

            Env = TestData.DefineEnvironmentDependingOnEnvironment();
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
                
                if(!elements[0].Text.Contains("Repayment progress"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Repayment progress element is abcent. Please check manually.");
                }
                
                if (!elements[1].Text.Contains("Loan amount"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan amount field is element. Please check manually.");
                }
                
                if (!elements[2].Text.Contains("Loan term"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan term field is element. Please check manually.");
                }

                if (!elements[3].Text.Contains("Loan interest rate"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan interest rate field is element. Please check manually.");
                }
                
                if (!elements[4].Text.Contains("Loan issuance date"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan issuance date field is element. Please check manually.");
                }
               
                if (!elements[5].Text.Contains("Loan maturity date"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan maturity date field is element. Please check manually.");
                }
                
                if (!elements[6].Text.Contains("Loan-to-value (LTV) at origination"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan-to-value (LTV) at origination field is element. Please check manually.");
                }

                if (!elements[7].Text.Contains("Loan-to-value (LTV) current"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan-to-value (LTV) current field is element. Please check manually.");
                }
                
                if (!elements[8].Text.Contains("Debtor address"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Debtor address field is element. Please check manually.");
                }
                
                if (!elements[9].Text.Contains("Creditor address"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Creditor address field is element. Please check manually.");
                }

                if (!elements[10].Text.Contains("Collateral"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Collateral field is element. Please check manually.");
                }
                
                if (!elements[11].Text.Contains("Repayments"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Repayments field is element. Please check manually.");
                }

                if (!elements[12].Text.Contains("Repayment frequency"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Repayment frequency field is element. Please check manually.");
                }
                
                if (!elements[13].Text.Contains("Agreement Id"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Agreement Id field is element. Please check manually.");
                }

                if (!elements[14].Text.Contains("Relayer name"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Relayer name field is element. Please check manually.");
                }
                if (!elements[15].Text.Contains("Relayer address"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Relayer address field is element. Please check manually.");
                }
                
                if (!elements[16].Text.Contains("Relayer fees"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Relayer fees field is element. Please check manually.");
                }
                
                if (!elements[17].Text.Contains("Underwriter name"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Underwriter name field is element. Please check manually.");
                }
                                
                if (!elements[18].Text.Contains("Underwriter address"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Underwriter address field is element. Please check manually.");
                }
                
                if (!elements[19].Text.Contains("Underwriter fees"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN:Underwriter fees field is element. Please check manually.");
                }
                
                if (!elements[20].Text.Contains("Underwriter risk rating"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Underwriter risk rating field is element. Please check manually.");
                }
                
                if (!elements[21].Text.Contains("Loan issuance link"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan issuance link field is element. Please check manually.");
                }
               
                if (!elements[22].Text.Contains("Loan contract"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan contract field is element. Please check manually.");
                }
                
                if (!elements[23].Text.Contains("Lending protocol/system"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Lending protocol/system field is element. Please check manually.");
                }
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
            }
        }

        public static void VerifyPaidOfDharmaSingleCard()
        {
            try
            {
                Engine.Browser.CurrentBrowser.Navigate().GoToUrl("https://loanscan.io/Agreements/Dharma/0xa17912dffc430b2d9e346905e695d74e432fb45edaa9b6fe6fc216b41ec117c1");
                Engine.Browser.MiddlePause();

                string valuesStr = "";
                IList<IWebElement> values = Engine.Browser.CurrentBrowser.FindElements(By.CssSelector("span"));
                foreach(var val in values)
                {
                    valuesStr += val.Text;
                }
                if(valuesStr != "BETA100% of 0.000202 WETH repaidrepaid0.0002 WETH ($0.04) paid offpaid off1 hour8,760.00% / 1.00%September-25-2018 17:03:29 PM UTCSeptember-25-2018 18:03:29 PM UTC10.0%0xd840d02bb3a715027343fc8428b61a7f83dcb6e70xd840d02bb3a715027343fc8428b61a7f83dcb6e7heldin a smart contract0.000202 WETH ($0.04)1Hourly0xa17912dffc430b2d9e346905e695d74e432fb45edaa9b6fe6fc216b41ec117c10xa17912dffc430b2d9e346905e695d74e432fb45edaa9b6fe6fc216b41ec117c1Bloqboard0x00f34ad48a326b406bf995e04189e42d285d57730x860c058b354b0a63066cd030ac80a60df0cbce933da6ad86c2165cf5db0c60010x5de2538838b4eb7fa2dbdea09d642b88546e5f20Dharma")
                {
                    throw new Exception("[" + Env + "] LOANSCAN: paid of values are probably broken. Please check manually.");
                }
               
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
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
                Engine.Browser.LongPause();

                IList<IWebElement> elements = Engine.Browser.CurrentBrowser.FindElements(ElementsonCardPageDharma);

                if (!elements[0].Text.Contains("Repayment progress"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Repayment progress field is not present at the card page. Please check manually.");
                }

                if (!elements[1].Text.Contains("Loan balance"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan balance field is not present at the card page. Please check manually.");
                }
                if (!elements[2].Text.Contains("Loan term"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan term field is not present at the card page. Please check manually.");
                }
                if (!elements[3].Text.Contains("Loan interest rate (annual)"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan interest rate (annual) field is not present at the card page. Please check manually.");
                }

                if (!elements[4].Text.Contains("Loan-to-value (LTV) current"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan-to-value (LTV) current field is not present at the card page. Please check manually.");
                }
                
                if (!elements[5].Text.Contains("Debtor address"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Debtor addresst field is not present at the card page. Please check manually.");
                }
                
                if (!elements[6].Text.Contains("Creditor address"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Creditor address field is not present at the card page. Please check manually.");
                }
               
                if (!elements[7].Text.Contains("Loan draws"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan draws field is not present at the card page. Please check manually.");
                }
                
                if (!elements[8].Text.Contains("Collateral"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Collateral field is not present at the card page. Please check manually.");
                }
                
                if (!elements[10].Text.Contains("Repayments"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Repayments field is not present at the card page. Please check manually.");
                }
                
                if (!elements[11].Text.Contains("Cumulative liquidation fee"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Cumulative liquidation fee field is element. Please check manually.");
                }

                
                if (!elements[12].Text.Contains("CDP creation link"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: CDP creation link field is not present at the card page. Please check manually.");
                }
                
                if (!elements[13].Text.Contains("Lending protocol/system"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Lending protocol/system field is not present at the card page. Please check manually.");
                }
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
            }


        }


    }
}
