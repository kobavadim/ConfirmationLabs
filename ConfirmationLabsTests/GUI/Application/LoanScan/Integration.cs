using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfirmationLabsTests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = ConfirmationLabsTests.Helpers.Assert;

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
        private static readonly By MakerDaoColumn = By.CssSelector("div.btn-group.btn-group-toggle.mr-auto > label:nth-of-type(2)");
        private static readonly By LendingProtocolTable = By.CssSelector(".loan-row:nth-child(1) td:nth-child(12) .nowrap");
        private static readonly By AnnualInterestRateCardMakerDao = By.CssSelector(".col-sm-9:nth-child(6) span");
        private static readonly By LendingProtocolCard = By.CssSelector(".col-sm-9:nth-child(28) span");
        private static readonly By CollateralTableMakerDao = By.CssSelector(".loan-list .loan-summary");
        private static readonly By AllDataDharma = By.CssSelector("span , .col-sm-9:nth-child(44) , .col-sm-9:nth-child(40) , .col-sm-9:nth-child(38)");
        private static readonly By AllDataMakerDao = By.CssSelector(".col-sm-9");




        static string Env = "";

       


        //Methods
        public static void Open()
        {

            Env = Helpers.TestData.DefineBaseUrlDependingOnEnvironment();
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

                Assert.IsTrue(annualinterestratecard.Text.Contains(value), "[" + Env + "] LOANSCAN", "The appopriate card is not opened from the table");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
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

                if (!annaulVlaueCard.Contains(annaulintRateTableValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Annual Interest Rate value doesn't match through the table and the card. Please check manually.");
                }
                

                IWebElement repayedCard = Engine.Browser.CurrentBrowser.FindElement(RepayedCard);
                if (!repayedCard.Text.Contains(repayedTableValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: %Repayed value doesn't match through the table and the card. Please check manually.");
                }

                IWebElement loanTermCard = Engine.Browser.CurrentBrowser.FindElement(LoanTermCard);
                if (!loanTermCard.Text.Contains(loanTermtableValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Loan Term value doesn't match through the table and the card. Please check manually.");
                }
                
                IWebElement underwritercard = Engine.Browser.CurrentBrowser.FindElement(UnderwrietrNameCard);
                if (!underwritercard.Text.Contains(underwriterNameTableValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Underwriter Name value doesn't match through the table and the card. Please check manually.");
                }
                IWebElement relayername = Engine.Browser.CurrentBrowser.FindElement(RelayerNameCard);
                if (!relayername.Text.Contains(relayerNameTableValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Relayer Name value doesn't match through the table and the card. Please check manually.");
                }


            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
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
            Assert.IsTrue(loanamountCard.Text.Contains(dollar), "[" + Env + "] LOANSCAN", "Loan amount in the card is not the same as in the table");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
            }


        }

        public static void VerifyCollateralistheSameThroughTableandCard()
        {
            try
            {
                Open();
                IWebElement dharmacolumn = Engine.Browser.CurrentBrowser.FindElement(DharmaColumn);
                dharmacolumn.Click();
                Engine.Browser.MiddlePause();

                IWebElement collateralTable = Engine.Browser.CurrentBrowser.FindElement(CollateralTable);
                string collateralTableValue = collateralTable.Text;
                string[] stringSeparators = new string[] { "(" };
                var result = collateralTableValue.Split(stringSeparators, StringSplitOptions.None);

                string token = result[0];
                string dollar = result[1];
                               

                IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);
                firstrow.Click();
                Engine.Browser.MiddlePause();

                IWebElement collateralCard = Engine.Browser.CurrentBrowser.FindElement(CollateralCard);
                Assert.IsTrue(collateralCard.Text.Contains(dollar), "[" + Env + "] LOANSCAN", "Collateral vlaue on the card is not the same as in the table");


            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
            }

        }

        public static void VerifyDataonMakerDaoCardcorrespondsDataFromTable()
        {
            try
            {

                Open();
                IWebElement makerDaoColumn = Engine.Browser.CurrentBrowser.FindElement(MakerDaoColumn);
                makerDaoColumn.Click();
                Engine.Browser.MiddlePause();
                IWebElement row = Engine.Browser.CurrentBrowser.FindElement(Row);

                IWebElement annaulInterestRateTable = Engine.Browser.CurrentBrowser.FindElement(AnnaulInterestRateTable);
                string annaulintRateTableValue = annaulInterestRateTable.Text;
                
                IWebElement repayedTable = Engine.Browser.CurrentBrowser.FindElement(RepayedTable);
                string repayedTableValue = repayedTable.Text;

                IWebElement lendingProtocol = Engine.Browser.CurrentBrowser.FindElement(LendingProtocolTable);
                string lendingProtocolValue = lendingProtocol.Text;



                row.Click();
                Engine.Browser.MiddlePause();


                IWebElement annualInterestRateCard = Engine.Browser.CurrentBrowser.FindElement(AnnualInterestRateCardMakerDao);
                string annaulVlaueCard = annualInterestRateCard.Text;

                if (!annaulVlaueCard.Contains(annaulintRateTableValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Annual Interest Rate value doesn't match through the table and the card of Maker DAO lending protocol. Please check manually.");
                }


                IWebElement repayedCard = Engine.Browser.CurrentBrowser.FindElement(RepayedCard);
                if (!repayedCard.Text.Contains(repayedTableValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: %Repayed value doesn't match through the table and the card. Please check manually.");
                }

                IWebElement lendingProtocolCard = Engine.Browser.CurrentBrowser.FindElement(LendingProtocolCard);
                if (!lendingProtocolCard.Text.Contains(lendingProtocolValue))
                {
                    throw new Exception("[" + Env + "] LOANSCAN: Lending Protocol type doesn't match through the table and the card. Please check manually.");
                }




            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);
            }




        }

        public static void VerifyCollateralistheSameThroughTableandCardMakerDao()
        {
            try
            {
                Open();
                IWebElement makerDaoColumn = Engine.Browser.CurrentBrowser.FindElement(MakerDaoColumn);
                makerDaoColumn.Click();
                Engine.Browser.MiddlePause();

                IWebElement collateralTable = Engine.Browser.CurrentBrowser.FindElement(CollateralTable);
                string collateralTableValue = collateralTable.Text;
                string[] stringSeparators = new string[] { "(" };
                var result = collateralTableValue.Split(stringSeparators, StringSplitOptions.None);

                string token = result[0];
                string dollar = result[1];


                IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);
                firstrow.Click();
                Engine.Browser.MiddlePause();

                IWebElement collateralCard = Engine.Browser.CurrentBrowser.FindElement(CollateralTableMakerDao);
                Assert.IsTrue(collateralCard.Text.Contains(dollar), "[" + Env + "] LOANSCAN", "Collateral vlaue on the card is not the same as in the table");


            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);

            }

        }


        public static void VerifyAllDataloadedDharma()
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

                IList<IWebElement> datadharma = Engine.Browser.CurrentBrowser.FindElements(AllDataDharma);
                foreach (var value in datadharma)
                {
                    string valuetext = value.Text;
                    Assert.IsTrue(!valuetext.Contains(""), "[" + Env + "] LOANSCAN", "Some values are missing on the Dharma Single Card");
                }
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);

            }

        }

        public static void VerifyAllDataloadedMakerDao()
        {
            try
            {
                Open();
                IWebElement makerDaoColumn = Engine.Browser.CurrentBrowser.FindElement(MakerDaoColumn);
                makerDaoColumn.Click();
                Engine.Browser.MiddlePause();

                IWebElement firstrow = Engine.Browser.CurrentBrowser.FindElement(Row);
                firstrow.Click();
                Engine.Browser.MiddlePause();

                IList<IWebElement> datamakerdao = Engine.Browser.CurrentBrowser.FindElements(AllDataMakerDao);
                foreach (var value in datamakerdao)
                {
                    string valuetext = value.Text;
                    Assert.IsTrue(!valuetext.Contains(""), "[" + Env + "] LOANSCAN", "Some values are missing on the MakerDao Single Card");
                }

            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "LOANSCAN", exception);

            }
        }




    }
}
