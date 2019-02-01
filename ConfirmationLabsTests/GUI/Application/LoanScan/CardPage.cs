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
                if (elements.Count<24)
                {
                    throw new Exception("[" + Env + "] LOANSCAN fields count is incorrect. Please check manually. " + elements.Count + " URL " + Engine.Browser.CurrentBrowser.Url);
                }
                else
                {
                    if (!elements[0].Text.Contains("Repayment progress"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Repayment progress element is incorrect. Please check manually.");
                    }

                    if (!elements[1].Text.Contains("Loan amount"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan amount field is incorrect. Please check manually.");
                    }

                    if (!elements[2].Text.Contains("Loan term"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan term field is incorrect. Please check manually.");
                    }

                    if (!elements[3].Text.Contains("Loan interest rate"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan interest rate field is incorrect. Please check manually.");
                    }

                    if (!elements[4].Text.Contains("Loan issuance date"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan issuance date field is incorrect. Please check manually.");
                    }
                    //Loan issuance date
                    if (!elements[5].Text.Contains("Loan maturity date"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan maturity date field is incorrect. Please check manually.");
                    }

                    if (!elements[6].Text.Contains("Loan-to-value (LTV) at origination"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan-to-value (LTV) at origination field is incorrect. Please check manually.");
                    }

                    if (!elements[7].Text.Contains("Loan-to-value (LTV) current"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan-to-value (LTV) current field is incorrect. Please check manually.");
                    }
                    //Debtor address
                    if (!elements[8].Text.Contains("Borrower address"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Debtor address field is incorrect. Please check manually.");
                    }

                    //Creditor address
                    if (!elements[9].Text.Contains("Lender address"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Creditor address field is incorrect. Please check manually.");
                    }

                    if (!elements[10].Text.Contains("Collateral"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Collateral field is incorrect. Please check manually.");
                    }

                    if (!elements[11].Text.Contains("Repayments"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Repayments field is incorrect. Please check manually.");
                    }

                    if (!elements[12].Text.Contains("Repayment frequency"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Repayment frequency field is incorrect. Please check manually.");
                    }

                    if (!elements[13].Text.Contains("Agreement Id"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Agreement Id field is incorrect. Please check manually.");
                    }
                    //Relayer name
                    if (!elements[14].Text.Contains("Lending platform"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Relayer name field is incorrect. Please check manually.");
                    }
                    //Relayer address
                    if (!elements[15].Text.Contains("Lending platform address"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Relayer address field is incorrect. Please check manually.");
                    }
                    //Relayer fees
                    if (!elements[16].Text.Contains("Lending platform fees"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Relayer fees field is incorrect. Please check manually.");
                    }

                    if (!elements[17].Text.Contains("Underwriter name"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Underwriter name field is incorrect. Please check manually.");
                    }

                    if (!elements[18].Text.Contains("Underwriter address"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Underwriter address field is incorrect. Please check manually.");
                    }

                    if (!elements[19].Text.Contains("Underwriter fees"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN:Underwriter fees field is incorrect. Please check manually.");
                    }

                    if (!elements[20].Text.Contains("Underwriter risk rating"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Underwriter risk rating field is incorrect. Please check manually.");
                    }

                    if (!elements[21].Text.Contains("Loan issuance link"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan issuance link field is incorrect. Please check manually.");
                    }

                    if (!elements[22].Text.Contains("Loan contract"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Loan contract field is incorrect. Please check manually.");
                    }
                    //Lending protocol/system
                    if (!elements[23].Text.Contains("Lending protocol"))
                    {
                        throw new Exception("[" + Env + "] LOANSCAN: Lending protocol/system field is incorrect. Please check manually.");
                    }
                }
 
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception, false);
            }
        }

        public static void VerifyProtocolsSingleCards()
        {
            try
            {
                Engine.Browser.CurrentBrowser.Navigate().GoToUrl("https://loanscan.io/agreements/MakerDao/14142");
                Engine.Browser.MiddlePause();

                string valuesStr = "";
                IList<IWebElement> values = Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".col-sm-3"));
                foreach(var val in values)
                {
                    valuesStr += val.Text;
                }
                if(valuesStr != "Repayment progressLoan balanceLoan termLoan interest rate (annual)Loan-to-value (LTV) currentBorrower addressLender addressLoan drawsCollateralRepaymentsCumulative liquidation feeCDP creation linkLending platformLending protocol")
                {
                    throw new Exception("[" + Env + "] LOANSCAN: MakerDao card is probably broken. Please check manually.");
                }

                Engine.Browser.MiddlePause();
                Engine.Browser.CurrentBrowser.Navigate().GoToUrl("https://loanscan.io/agreements/Dharma/0x2544c6eeb2cc029f216b7d032b31b35b8efd01ac243b8a391cf7bb23e33e05be");
                Engine.Browser.MiddlePause();

                string valuesDharmaStr = "";
                IList<IWebElement> valuesDharma = Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".col-sm-3"));
                foreach (var val in valuesDharma)
                {
                    valuesDharmaStr += val.Text;
                }
                var finalDharma = valuesDharmaStr.Replace(" ", string.Empty);
                if (!valuesDharmaStr.Contains("(annual)/(per loan term)Loan issuance dateLoan maturity dateLoan-to-value (LTV) at originationLoan-to-value (LTV) currentBorrower addressLender addressCollateralRepaymentsRepayment frequencyAgreement IdLending platformLending platform addressLending platform feesUnderwriter nameUnderwriter addressUnderwriter feesUnderwriter risk ratingLoan issuance linkLoan contractLending protocol"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Dharma card is probably broken. Please check manually.");
                }
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception, false);
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
                //
                if (!elements[5].Text.Contains("Borrower address"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Debtor addresst field is not present at the card page. Please check manually.");
                }
                
                if (!elements[6].Text.Contains("Lender address"))
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
                
                if (!elements[13].Text.Contains("Lending platform"))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Lending protocol/system field is not present at the card page. Please check manually.");
                }
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception, false);
            }


        }


    }
}
