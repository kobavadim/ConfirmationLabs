﻿using System;
using System.Collections.Generic;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;

namespace ConfirmationLabsTests.GUI.Application.BloqBoard
{
    class MainPageBb
    {
        //Elements
        static string Env = TestData.DefineEnvironmentDependingOnEnvironment();
        private static readonly By TermsAndCOnditionsCheckBox = By.CssSelector("div.terms-checkbox > label > input");
        private static readonly By Continuebtn = By.CssSelector("div.modal-footer > button.btn-green");
        private static readonly By LiquidityTable = By.CssSelector(".content-table-row");
        private static readonly By BalanceTable = By.CssSelector(".balances-table__table-wrapper");
        private static readonly By RequesttoBorrowTable = By.CssSelector(".app__content-sub .col-sm:nth-child(1)");
        private static readonly By MyRequestsToBorrowTable = By.CssSelector(".tabs__container .undefined");
        private static readonly By MyLoanedTokens = By.CssSelector(".app__small-table~ .app__small-table+ .app__small-table");
        private static readonly By DaiBtn = By.CssSelector(".token-item:nth-child(2) .token-item-name");
        private static readonly By AmountInput = By.CssSelector(".wallet-info__value-input");
        private static readonly By Wrap = By.CssSelector(".wallet-info__exchange-button+ .wallet-info__exchange-button");
        private static readonly By NewRequest = By.CssSelector(".token-item:nth-child(4) .token-item-name");
        private static readonly By AmountInputbyNewRequest = By.CssSelector("[name='amount']");
        private static readonly By InterestInputByNewRequest = By.CssSelector("[name='interestRate']");
        private static readonly By CollateralAmountNewRequest = By.CssSelector("[name='collateralAmount']");
        private static readonly By AddRequestBtn = By.CssSelector("button.loan-request-form__place-btn");
        private static readonly By Signbtn = By.CssSelector("");
        private static readonly By SignButtonMetaMaskPopUp = By.CssSelector(".button");
        private static readonly By CollateralDropDown = By.CssSelector("[name='collateralType']");
        private static readonly By LastRequestCreationDate = By.CssSelector("div.my-requests-wrapper > div:nth-of-type(4) > div.content-table-body > div:first-child > div:first-child > div.bottom-cell");
        private static readonly By TokensTable = By.CssSelector(".token-item");
        private static readonly By RecentLoans = By.CssSelector(".issued-loans-wrapper");
        private static readonly By LoanTable = By.CssSelector(".loan-table");
        private static readonly By LendToPoolTable = By.CssSelector(".on-demand-wrapper");
        private static readonly By MyWalletTable = By.CssSelector(".content-table-row");
        private static readonly By MyBorrowedTokensTable = By.CssSelector(".part-side:nth-child(1)");
        private static readonly By MyLandedTokensTable = By.CssSelector(".part-side+ .part-side");
        private static readonly By MyOpenedRequestsTable = By.CssSelector(".part-side:nth-child(1)");
        private static readonly By MyClosedRequestsTable = By.CssSelector(".part-side+ .part-side");
        private static readonly By CancelRequestBtn = By.CssSelector("#cancelPopover-0");
        private static readonly By CancelledCreationTime = By.CssSelector(".part-side+ .part-side .content-table-row:nth-child(1) .first+ .bottom-cell");
        private static readonly By ConfirmCancellationRequest = By.CssSelector("button.confirm-btn");
        private static readonly By LoanIssuedDateBloqBoard = By.CssSelector(".first .content-table-row:nth-child(1) .first+ .bottom-cell");
        private static readonly By LoanIssuedDateLoanscan = By.CssSelector("dl.row > dd:nth-of-type(5) > span");
        private static readonly By WalletIcon = By.CssSelector("[width='32'][fill='#18a9f2']");
        private static readonly By Logout = By.CssSelector(".account-menu__logout-button");
        private static readonly By LoginWithSeedBtn = By.CssSelector(".unlock-page__link--import");
        private static readonly By LendPeerToPeerRows = By.CssSelector(".loan-table .content-table-row");
        private static readonly By LendBtn = By.CssSelector(".content-table-row:nth-child(1) .lend-btn");
        private static readonly By LendBtn2 = By.CssSelector(".content-table-row:nth-child(2) .lend-btn");
        private static readonly By FundLoanRequest = By.CssSelector("button.loan-details-btn.fill");
        private static readonly By TransactionSuccessfulMsg = By.CssSelector("div.loan-details-actions-header");
        private static readonly By LendMenuBtn = By.CssSelector(".active+ .sidebar-block-item");
        private static readonly By LoansMenuBtn = By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)");
        private static readonly By RepayBtn = By.CssSelector("#repayPopover-0");
        private static readonly By InputRepayAmount = By.CssSelector("input.repay-input");
        private static readonly By ConfirmRepay = By.CssSelector("button.confirm-repay-btn");
        private static readonly By FirstTransactionLoaned = By.CssSelector(".first .content-table-row:nth-child(1) .first");
        private static readonly By RepaymanrAmountLoanscan = By.CssSelector("li > span.loan-amount.repayment");
        private static readonly By WholeAmountToRepay = By.CssSelector("div > div:nth-of-type(2) > div.content-value.text-right > div:first-child");
        private static readonly By SeizeCollarealBtn = By.CssSelector("div.content-table-body > div:first-child > div:nth-of-type(6) > div.top-cell > button.collateral-act-btn");
        private static readonly By ConfirmReturnCollateralBtn = By.CssSelector("button.confirm-btn");
        private static readonly By CollateralReturnedBtn = By.CssSelector("div.content-table-body > div:first-child > div:nth-of-type(6) > div.top-cell.labeled > div.action-label");
        private static readonly By SeizeCollateralSimilarBtns = By.CssSelector(".collateral-act-btn");
        private static readonly By NextPage = By.CssSelector("ul.pagination > li:nth-of-type(6) > a.page-link > span");
        private static readonly By ConfirmSeizing = By.CssSelector("button.confirm-btn");
        private static readonly By BorrowPtwoPBtn = By.CssSelector(".btn-green");
        private static readonly By BorrowTokensGreenBtn = By.CssSelector("button.borrow-btn");
        private static readonly By TransactionMessage = By.CssSelector("div.fund-loan-success-header");
        private static readonly By LendPageLink = By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(2)");
        private static readonly By TokenAmount = By.CssSelector(".padding-s .top-cell");
        private static readonly By UsdAmount = By.CssSelector(".padding-s .bottom-cell");
        private static readonly By ColumnNamesBorrowPage = By.CssSelector(".header-item .header-text");
        private static readonly By PercentageIconinRequestLendTable = By.CssSelector(".top-cell .cell-normal");
        private static readonly By TokenItemsBoxes = By.CssSelector(".token-item");
        private static readonly By MyWalletLink = By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(1)");
        private static readonly By AssetsInWallet = By.CssSelector(".token-cell .top-cell");
        private static readonly By UsdPriceWallet = By.CssSelector(".content-table-cell.text-right");
        private static readonly By ColumnWallet = By.CssSelector(".header-text");
        private static readonly By PermissionsWallet = By.CssSelector(".permission-button");
        private static readonly By Permissions = By.CssSelector(".type-label");

        private static readonly By MyRequestsMainMenu = By.CssSelector(".sidebar-block-item~ .sidebar-block-item+ .sidebar-block-item");





        //METHODS
        public static ReadOnlyCollection<string> LoginToMainPage(string role)
        {
            Console.WriteLine("Log in to Metamask...");
            Wallets.LoginToMetaMaskWallet(role);
            Browser.MiddlePause();

            string environment = TestData.DefineEnvironmentDependingOnEnvironment();
            if (environment.Contains("Kovan"))
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }
                Console.WriteLine("running tests on " + environment + " with Kovan network.");
            }
            else if (environment.Contains("Mainnet"))
            {
                Browser.ShortPause();
                Console.WriteLine("running tests on " + environment + " with Mainnet network.");
            }
            Browser.LongPause();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

            string metamaskTab = handles[0];
            string bloqboardTab = handles[1];

            Browser.CurrentBrowser.SwitchTo().Window(bloqboardTab);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment());
            Browser.LongPause();
            TermsandConditionAceptance();
            Browser.ShortPause();
      
            Console.WriteLine("Wallet approval");
            IWebElement connectWallet = Browser.CurrentBrowser.FindElement(By.CssSelector("div.auth-module-wrapper"));
            connectWallet.Click();
            Browser.MiddlePause();

            IWebElement submit = Browser.CurrentBrowser.FindElement(By.CssSelector("ul.extensions-block > li:first-child"));
            submit.Click();
            Browser.MiddlePause();

            Browser.CurrentBrowser.SwitchTo().Window(metamaskTab);
            Browser.ShortPause();
            Browser.CurrentBrowser.Navigate().Refresh();
            Browser.MiddlePause();

            IWebElement submitFromMetamask = Browser.CurrentBrowser.FindElement(By.CssSelector(".btn-confirm"));
            submitFromMetamask.Click();
            Browser.MiddlePause();

            Browser.CurrentBrowser.SwitchTo().Window(bloqboardTab);
            Browser.CurrentBrowser.Navigate().Refresh();
            Browser.ShortPause();
            IWebElement connectWalletAgain = Browser.CurrentBrowser.FindElement(By.CssSelector("div.auth-module-wrapper"));
            connectWalletAgain.Click();
            Browser.MiddlePause();

            IWebElement submitAgain = Browser.CurrentBrowser.FindElement(By.CssSelector("ul.extensions-block > li:first-child"));
            submitAgain.Click();
            Browser.MiddlePause();

            return handles;
        }

        public static void LoginToMetamaskAsLender()
        {
            Console.WriteLine("Log in to Metamask...");
            Wallets.LoginToMetaMaskWalletWithNewUser();
            Browser.MiddlePause();

            string Env = TestData.DefineEnvironmentDependingOnEnvironment();
            if (Env.Contains("Kovan"))
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }
                Console.WriteLine("running tests on " + Env + " with Kovan network.");
            }
            else if (Env.Contains("Mainnet"))
            {
                Browser.ShortPause();
                Console.WriteLine("running tests on " + Env + " with Mainnet network.");
            }
            Browser.LongPause();
        }

        public static void OpenNewTab()
        {
            var popup = Browser.CurrentBrowser.WindowHandles[0]; // handler for the new tab
            //Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
            //Assert.IsTrue(Browser.CurrentBrowser.SwitchTo().Window(popup).Url == ""); // url is OK  
            Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[0]); // close the tab
            Browser.CurrentBrowser.SwitchTo().Window(Browser.CurrentBrowser.WindowHandles[1]); // get back to the main window
        }

        public static void TermsandConditionAceptance()
        {
            IWebElement termschecbox = Browser.CurrentBrowser.FindElement(TermsAndCOnditionsCheckBox);
            termschecbox.Click();
            Browser.ShortPause();
            IWebElement continuebtn = Browser.CurrentBrowser.FindElement(Continuebtn);
            continuebtn.Click();
            Browser.MiddlePause();
        }

        public static void WentThroughRequestTable()
        {
            IList<IWebElement> elementList = Browser.CurrentBrowser.FindElements(SeizeCollateralSimilarBtns);

            bool isClicked = false;

            for (int i = 0; i < 4; i++)
            {
                foreach (var el in elementList)
                {
                    if (el.Text == "Seize collateral")
                    {
                        el.Click();
                        isClicked = true;
                        break;
                    }
                }

                if (isClicked)
                {
                    break;
                }
                else
                {
                    IWebElement nextpage = Browser.CurrentBrowser.FindElement(NextPage);
                    nextpage.Click();
                }

            }
        }

        public static string ClickCollateralButtonAndReturnDate()
        {
            var clickedTime = "no collateral found";

            IList<IWebElement> elementListRows = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table-row"));
            foreach (var el in elementListRows)
            {
                var children = el.FindElements(By.XPath(".//*"));

                var time = children[0].Text;
                var button = children[children.Count - 1];
                if (button.Text == "SEIZE COLLATERAL")
                {
                    button.Click();
                    clickedTime = time;
                    break;
                }

            }

            return clickedTime;
        }

        public static bool CheckIfCollateralSiezed(string date)
        {
            bool result = false;

            IList<IWebElement> elementListRows = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table-row"));
            foreach (var el in elementListRows)
            {
                var children = el.FindElements(By.XPath(".//*"));

                var time = children[0].Text;
                if (time == date)
                {
                    var button = children[children.Count - 2];
                    if (button.Text.Contains("Seized"))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public static void CreateNewOffersToLendRequest(string LendToken)
        {
            IWebElement createOffer = Browser.CurrentBrowser.FindElement(By.CssSelector("button.transparent-button"));
            createOffer.Click();

            Browser.ShortPause();

            IWebElement amount = Browser.CurrentBrowser.FindElement(AmountInputbyNewRequest);
            amount.SendKeys("0.0001");

            IWebElement interest = Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"interestRate\"]"));
            interest.SendKeys("1");

            IWebElement token = Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"collateralToken\"]"));
            token.Click();
            Browser.ShortPause();

            if (LendToken.Contains("ZRX"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralToken"))).SelectByText("ZRX");
            }

            if (LendToken.Contains("BAT"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralToken"))).SelectByText("BAT");
            }

            if (LendToken.Contains("DAI"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralToken"))).SelectByText("ZRX");
            }

            if (LendToken.Contains("REP"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralToken"))).SelectByText("ZRX");
            }

            IWebElement LTV = Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"collateralRatio\"]"));
            LTV.SendKeys(OpenQA.Selenium.Keys.Control + "a");
            LTV.SendKeys(OpenQA.Selenium.Keys.Backspace);
            LTV.SendKeys("155");


            IWebElement submit = Browser.CurrentBrowser.FindElement(By.CssSelector("button.loan-form__btn.lend"));
            submit.Click();
        }

        public static void CreateNewBorrowRequest(string token)
        {
            IWebElement createOffer = Browser.CurrentBrowser.FindElement(By.CssSelector("button.transparent-button"));
            createOffer.Click();
            Browser.ShortPause();

            IWebElement amount = Browser.CurrentBrowser.FindElement(AmountInputbyNewRequest);
            amount.SendKeys("0.00001");

            IWebElement interest = Browser.CurrentBrowser.FindElement(InterestInputByNewRequest);
            interest.SendKeys("1");
            Browser.ShortPause();


            IWebElement click = Browser.CurrentBrowser.FindElement(By.CssSelector("[name='collateralType']"));
            click.Click();

            if (token.Contains("ZRX"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralType"))).SelectByText("ZRX");
                Browser.ShortPause();
                IWebElement collateral = Browser.CurrentBrowser.FindElement(CollateralAmountNewRequest);
                collateral.SendKeys("0.009");
            }
            if (token.Contains("BAT"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralType"))).SelectByText("BAT");
                Browser.ShortPause();
                IWebElement collateral = Browser.CurrentBrowser.FindElement(CollateralAmountNewRequest);
                collateral.SendKeys("0.02");
            }
            if (token.Contains("DAI"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralType"))).SelectByText("DAI");
                Browser.ShortPause();
                IWebElement collateral = Browser.CurrentBrowser.FindElement(CollateralAmountNewRequest);
                collateral.SendKeys("0.03");
            }
            if (token.Contains("REP"))
            {
                new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("collateralType"))).SelectByText("REP");
                Browser.ShortPause();
                IWebElement collateral = Browser.CurrentBrowser.FindElement(CollateralAmountNewRequest);
                collateral.SendKeys("0.004");
            }

            Browser.ShortPause();
            interest.Submit();
            Browser.MiddlePause();
        }

        public static void SignRequest()
        {
            IList<IWebElement> buttons = Browser.CurrentBrowser.FindElements(By.CssSelector("button"));
            buttons[1].Click();
        }

        public static void LogoutWallet()
        {
            Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
            Browser.MiddlePause();

            IWebElement icon = Browser.CurrentBrowser.FindElement(WalletIcon);
            icon.Click();
            Browser.MiddlePause();
            IWebElement logout = Browser.CurrentBrowser.FindElement(Logout);
            logout.Click();
            Browser.MiddlePause();
        }

        public static void LoginWalletwithNewUser()
        {
            IWebElement loginwithseed = Browser.CurrentBrowser.FindElement(LoginWithSeedBtn);
            loginwithseed.Click();
            Browser.ShortPause();

            IWebElement seed = Browser.CurrentBrowser.FindElement(By.CssSelector(".import-account__secret-phrase"));
            seed.Click();
            var restore = TestData.ToUpperCase(TestData.Input.lender) + " " + "music";
            seed.SendKeys(restore);
            Browser.ShortPause();

            IWebElement password = Browser.CurrentBrowser.FindElement(By.CssSelector("#password"));
            password.Click();
            password.SendKeys(TestData.Input.password);
            Browser.ShortPause();

            IWebElement confirmpassword = Browser.CurrentBrowser.FindElement(By.CssSelector("#confirm-password"));
            confirmpassword.Click();
            confirmpassword.SendKeys(TestData.Input.password);
            Browser.MiddlePause();

            IWebElement proceedPhrase = Browser.CurrentBrowser.FindElement(By.CssSelector(".first-time-flow__button"));
            proceedPhrase.Click();
            Browser.ShortPause();
        }

        public static void LoginWalletwithFirstUser()
        {
            IWebElement loginwithseed = Browser.CurrentBrowser.FindElement(LoginWithSeedBtn);
            loginwithseed.Click();
            Browser.ShortPause();

            IWebElement seed = Browser.CurrentBrowser.FindElement(By.CssSelector(".import-account__secret-phrase"));
            seed.Click();
            seed.SendKeys(TestData.Input.seedPhrase);
            Browser.ShortPause();

            IWebElement password = Browser.CurrentBrowser.FindElement(By.CssSelector("#password"));
            password.Click();
            password.SendKeys(TestData.Input.password);
            Browser.ShortPause();

            IWebElement confirmpassword = Browser.CurrentBrowser.FindElement(By.CssSelector("#confirm-password"));
            confirmpassword.Click();
            confirmpassword.SendKeys(TestData.Input.password);
            Browser.MiddlePause();

            IWebElement proceedPhrase = Browser.CurrentBrowser.FindElement(By.CssSelector(".first-time-flow__button"));
            proceedPhrase.Click();
            Browser.ShortPause();
        }



        //TESTS
        public static void VerifyPageisOpened()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                IWebElement table = Browser.CurrentBrowser.FindElement(LiquidityTable);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "BloqBoard page is not loaded correctly");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyTokensTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                IWebElement tokenstable = Browser.CurrentBrowser.FindElement(TokensTable);
                Assert.IsTrue(tokenstable.Displayed, "[" + Env + "] BLOQBOARD", "Tokens Table is not loaded properly");

            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyRecentLoansTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                IWebElement table = Browser.CurrentBrowser.FindElement(RecentLoans);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "Recent Loans table is not loaded properly");

            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyLoanTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Lend);
                Browser.MiddlePause();
                IWebElement table = Browser.CurrentBrowser.FindElement(LoanTable);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "Loan table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyLendToPoolTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Lend);
                Browser.MiddlePause();

                IWebElement loanedtable = Browser.CurrentBrowser.FindElement(LendToPoolTable);
                Assert.IsTrue(loanedtable.Displayed, "[" + Env + "] BLOQBOARD", "Lend to pool table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyAssetsTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                IWebElement table = Browser.CurrentBrowser.FindElement(MyWalletTable);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "Assets table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyMyBorrowedTokensTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                IWebElement MyLoans = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                MyLoans.Click();
                Browser.MiddlePause();

                IWebElement myborrowedtokenstable = Browser.CurrentBrowser.FindElement(MyBorrowedTokensTable);
                Assert.IsTrue(myborrowedtokenstable.Displayed, "[" + Env + "] BLOQBOARD", "My borrowed tokens table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyMyLendedTokensTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                IWebElement MyLoans = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                MyLoans.Click();
                Browser.MiddlePause();

                IWebElement mytokenstable = Browser.CurrentBrowser.FindElement(MyLandedTokensTable);
                Assert.IsTrue(mytokenstable.Displayed, "[" + Env + "] BLOQBOARD", "My lended tokens table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyMyOpenRequestsTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Requests);
                Browser.MiddlePause();

                IWebElement openrequests = Browser.CurrentBrowser.FindElement(MyOpenedRequestsTable);
                Assert.IsTrue(openrequests.Displayed, "[" + Env + "] BLOQBOARD", "My open requests table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void CheckRepay()
        {
            Browser.ShortPause();

            IList<IWebElement> elementListRows = Browser.CurrentBrowser.FindElements(By.CssSelector(".first div.content-table-row"));
            foreach (var el in elementListRows)
            {
                var children = el.FindElements(By.XPath(".//*"));

                var time = children[0].Text;
                if (time.Contains("16-10-2018"))
                {
                    var repay = children[children.Count - 1];
                    repay.Click();
                    break;
                }
            }
        }

        public static void IgnoreAfterLogin(string reason)
        {
            Console.WriteLine("Login to the app...");
            LoginToMainPage("lender");

            Console.WriteLine("Test started...");
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Requests);

            Browser.MiddlePause();
            TermsandConditionAceptance();
            Browser.ShortPause();
        }

        public static void CheckReturn(string date)
        {
            Browser.ShortPause();

            IList<IWebElement> elementListRows = Browser.CurrentBrowser.FindElements(By.CssSelector(".first div.content-table-row"));
            foreach (var el in elementListRows)
            {
                var children = el.FindElements(By.XPath(".//*"));

                var time = children[0].Text;
                if (time.Contains(date))
                {
                    var repay = children[children.Count - 1];
                    if (repay.Text.Contains("RETURN COLLATERAL"))
                    {
                        repay.Click();
                        break;
                    }

                }
            }
        }

        public static bool CheckCollateral(string date)
        {
            bool result = false;

            Browser.ShortPause();

            IList<IWebElement> elementListRows = Browser.CurrentBrowser.FindElements(By.CssSelector(".first div.content-table-row"));
            foreach (var el in elementListRows)
            {
                var children = el.FindElements(By.XPath(".//*"));

                var time = children[0].Text;
                if (time.Contains(date))
                {
                    var repay = children[children.Count - 2];
                    if (repay.Text.Contains("Returned"))
                    {
                        result = true;
                        break;
                    }

                }
            }
            return result;
        }

        public static void VerifyMyCancelledRequestsTableDisplayed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Requests);
                Browser.MiddlePause();

                IWebElement requests = Browser.CurrentBrowser.FindElement(MyClosedRequestsTable);
                Assert.IsTrue(requests.Displayed, "[" + Env + "] BLOQBOARD", "My cancelled requests table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void FieldsConsistentTest()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(MyRequestsMainMenu);
                MyRequests.Click();
                Browser.MiddlePause();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table .header-text"));

                Assert.IsTrue(requests[0].Text.Contains("Created"), "[" + Env + "] BLOQBOARD", "Header 'Created' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[1].Text.Contains("Status"), "[" + Env + "] BLOQBOARD", "Header 'Status' is not displayed on the My Requests page Loan offer table.");

                Assert.IsTrue(requests[2].Text.Contains("Amount"), "[" + Env + "] BLOQBOARD", "Header 'Amount' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[3].Text.Contains("Term"), "[" + Env + "] BLOQBOARD", "Header 'Term' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[4].Text.Contains("APR"), "[" + Env + "] BLOQBOARD", "Header 'APR' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[5].Text.Contains("Interest"), "[" + Env + "] BLOQBOARD", "Header 'Interest amount' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[6].Text.Contains("Collateral ratio"), "[" + Env + "] BLOQBOARD", "Header 'Collateral ratio' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[7].Text.Contains("Collateral"), "[" + Env + "] BLOQBOARD", "Header 'Collateral' is not displayed on the My Requests page Loan offer table.");
                }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void FieldsConsistentMyRequestsPageLoanOfferTableTest()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(MyRequestsMainMenu);
                MyRequests.Click();
                Browser.MiddlePause();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table .header-text"));

                Assert.IsTrue(requests[9].Text.Contains("Created"), "[" + Env + "] BLOQBOARD", "Header 'Created' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[10].Text.Contains("Status"), "[" + Env + "] BLOQBOARD", "Header 'Status' is not displayed on the My Requests page Loan offer table.");

                Assert.IsTrue(requests[11].Text.Contains("Amount"), "[" + Env + "] BLOQBOARD", "Header 'Amount' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[12].Text.Contains("Term"), "[" + Env + "] BLOQBOARD", "Header 'Term' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[13].Text.Contains("APR"), "[" + Env + "] BLOQBOARD", "Header 'APR' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[14].Text.Contains("Interest"), "[" + Env + "] BLOQBOARD", "Header 'Interest amount' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[15].Text.Contains("Collateral ratio"), "[" + Env + "] BLOQBOARD", "Header 'Collateral ratio' is not displayed on the My Requests page Loan offer table.");
                Assert.IsTrue(requests[16].Text.Contains("Collateral"), "[" + Env + "] BLOQBOARD", "Header 'Collateral' is not displayed on the My Requests page Loan offer table.");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyTokenDisplayinAmountBorrowPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                MyRequests.Click();
                Browser.MiddlePause();

                IList<IWebElement> tokens = Browser.CurrentBrowser.FindElements(TokenAmount);
                foreach(var token in tokens)
                {
                    Assert.IsTrue(token.Displayed, "[" + Env + "] BLOQBOARD", "Tokens are not displayed on the Borrow page.");
                }
                

            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyTokenDisplayinAmountLendPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement lendPage = Browser.CurrentBrowser.FindElement(LendPageLink);
                lendPage.Click();
                Browser.MiddlePause();

                IList<IWebElement> tokens = Browser.CurrentBrowser.FindElements(TokenAmount);
                foreach (var token in tokens)
                {
                    Assert.IsTrue(token.Displayed, "[" + Env + "] BLOQBOARD", "Tokens are not displayed on the Lend page.");
                }
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyUsdDisplayingBorrowPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                MyRequests.Click();
                Browser.MiddlePause();

                IList<IWebElement> usd = Browser.CurrentBrowser.FindElements(UsdAmount);

                foreach (var usdamount in usd)
                {
                    string usdtext = usdamount.Text;


                    Assert.IsTrue(usdtext.Contains("USD"), "[" + Env + "] BLOQBOARD", "USD is not displayed on the Borrow page.");
                }

                


            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyUsdDisplayingLendPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                
                IWebElement lendPage = Browser.CurrentBrowser.FindElement(LendPageLink);
                lendPage.Click();
                Browser.MiddlePause();

                IList<IWebElement> usd = Browser.CurrentBrowser.FindElements(UsdAmount);

                foreach (var usdamount in usd)
                {
                    string usdtext = usdamount.Text;


                    Assert.IsTrue(usdtext.Contains("USD"), "[" + Env + "] BLOQBOARD", "USD is not displayed on the Borrow page.");
                }
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyCOlumnsDisplayinBorrowPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                MyRequests.Click();
                Browser.MiddlePause();



                IList<IWebElement> columnnames = Browser.CurrentBrowser.FindElements(ColumnNamesBorrowPage);
                Assert.IsTrue(columnnames[0].Text.Contains("Type"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the My Requests page.");
                Assert.IsTrue(columnnames[1].Text.Contains("Amount available"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the My Requests page.");
                Assert.IsTrue(columnnames[2].Text.Contains("APR"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the My Requests page.");
                Assert.IsTrue(columnnames[4].Text.Contains("Collateral asset"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the My Requests page.");



            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyColumnsDisplayinLendPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();

                IWebElement lendPage = Browser.CurrentBrowser.FindElement(LendPageLink);
                lendPage.Click();
                Browser.MiddlePause();

                IList<IWebElement> columnnames = Browser.CurrentBrowser.FindElements(ColumnNamesBorrowPage);
                Assert.IsTrue(columnnames[0].Text.Contains("Type"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the Lend page.");
                Assert.IsTrue(columnnames[1].Text.Contains("Amount available"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the Lend page.");
                Assert.IsTrue(columnnames[2].Text.Contains("APR"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the Lend page.");
                Assert.IsTrue(columnnames[4].Text.Contains("Collateral asset"), "[" + Env + "] BLOQBOARD", "Header 'Type' is not displayed on the Lend page.");




            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyPercentageIconDisplayinLiquidityPoolBorrowPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                MyRequests.Click();
                Browser.MiddlePause();

                IList<IWebElement> percentage = Browser.CurrentBrowser.FindElements(PercentageIconinRequestLendTable);
                foreach (var icon in percentage)
                {
                    string icontext = icon.Text;
                    Assert.IsTrue(icontext.Contains("%"), "[" + Env + "] BLOQBOARD", "Percentage icon is not displayed on the Borrow page.");

                }



            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyPercentageIconDisplayinLiquidityPoolLendPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement lendPage = Browser.CurrentBrowser.FindElement(LendPageLink);
                lendPage.Click();
                Browser.MiddlePause();

                IList<IWebElement> percentage = Browser.CurrentBrowser.FindElements(PercentageIconinRequestLendTable);
                foreach (var icon in percentage)
                {
                    string icontext = icon.Text;
                    Assert.IsTrue(icontext.Contains("%"), "[" + Env + "] BLOQBOARD", "Percentage icon is not displayed on the Lend page.");

                }

            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyTokenItemsareDisplayedontheBorrowPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                MyRequests.Click();
                Browser.MiddlePause();

                IList<IWebElement> tokens = Browser.CurrentBrowser.FindElements(TokenItemsBoxes);
                Assert.IsTrue(tokens.Count == 5, "[" + Env + "] BLOQBOARD", "Token items are not displayed on the Borrow page");

            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyTokenItemsareDisplayedontheLendPage()
        {

            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement lendPage = Browser.CurrentBrowser.FindElement(LendPageLink);
                lendPage.Click();
                Browser.MiddlePause();


                IList<IWebElement> tokens = Browser.CurrentBrowser.FindElements(TokenItemsBoxes);
                Assert.IsTrue(tokens.Count == 5, "[" + Env + "] BLOQBOARD", "Token items are not displayed on the Lend page");

            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyAssetsDisplayInWallet()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement wallet = Browser.CurrentBrowser.FindElement(MyWalletLink);
                wallet.Click();
                Browser.MiddlePause();

                IList<IWebElement> assets = Browser.CurrentBrowser.FindElements(AssetsInWallet);
                Assert.IsTrue(assets.Count == 6, "[" + Env + "] BLOQBOARD", "Assets are not displayed on the Wallet page");

            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }

        }

        public static void VerifyUsdIconDisplayinPriceWallet()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement wallet = Browser.CurrentBrowser.FindElement(MyWalletLink);
                wallet.Click();
                Browser.MiddlePause();

                IList<IWebElement> price = Browser.CurrentBrowser.FindElements(UsdPriceWallet);
                foreach (var usd in price)
                {
                    Assert.IsTrue(usd.Text.Contains("USD"), "[" + Env + "] BLOQBOARD", "Usd is not displayed on the Wallet page");

                }

            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }


        }

        public static void VerifyColumnsnDisplayWallet()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement wallet = Browser.CurrentBrowser.FindElement(MyWalletLink);
                wallet.Click();
                Browser.MiddlePause();

                IList<IWebElement> column = Browser.CurrentBrowser.FindElements(ColumnWallet);
                Assert.IsTrue(column[0].Text.Contains("Asset"), "[" + Env + "] BLOQBOARD", "Header 'Asset' is not displayed on the Wallet page.");
                Assert.IsTrue(column[1].Text.Contains("Price"), "[" + Env + "] BLOQBOARD", "Header 'Price' is not displayed on the Wallet page.");
                Assert.IsTrue(column[2].Text.Contains("Available"), "[" + Env + "] BLOQBOARD", "Header 'Available' is not displayed on the Wallet page.");
                Assert.IsTrue(column[3].Text.Contains("Actions"), "[" + Env + "] BLOQBOARD", "Header 'Actions' is not displayed on the Wallet page.");

            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }


        }
        public static void VerifyPermissionsDisplayWallet()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("maze");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.MiddlePause();
                IWebElement wallet = Browser.CurrentBrowser.FindElement(MyWalletLink);
                wallet.Click();
                Browser.MiddlePause();
                IWebElement permissionsbtn = Browser.CurrentBrowser.FindElement(PermissionsWallet);
                permissionsbtn.Click();

                Browser.ShortPause();

                IList<IWebElement> permissions = Browser.CurrentBrowser.FindElements(Permissions);

                Assert.IsTrue(permissions.Count == 15, "[" + Env + "] BLOQBOARD", "Not all permissions are displayed on the Wallet page");


            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }

        }

        public static void VerifyNewZrxBorrowRequestCanBeCreated()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("borrower");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();
                Browser.MiddlePause();

                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                Borrow.Click();
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewBorrowRequest("ZRX");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                Console.WriteLine("Do the final assert...");
                IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                Close.Click();

                Browser.ShortPause();
                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.LongPause();

                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "New request is not displayed under 'My requests' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewDaiBorrowRequestCanBeCreated()
        {
            try
            {
                Console.WriteLine("Log check...");
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("borrower");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();
                Browser.MiddlePause();

                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                Borrow.Click();
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewBorrowRequest("DAI");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);


                Console.WriteLine("Do the final assert...");
                try
                {
                    IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                    Close.Click();
                }
                catch (Exception)
                {

                }

                Browser.ShortPause();

                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.LongPause();


                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "New request is not displayed under 'My requests' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewBatBorrowRequestCanBeCreated()
        {
            try
            {
                Console.WriteLine("Log check...");
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("borrower");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();
                Browser.MiddlePause();

                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                Borrow.Click();
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewBorrowRequest("BAT");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);


                Console.WriteLine("Do the final assert...");
                try
                {
                    IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                    Close.Click();
                }
                catch (Exception)
                {

                }

                Browser.ShortPause();

                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.LongPause();


                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "New request is not displayed under 'My requests' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewRepBorrowRequestCanBeCreated()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("borrower");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();
                Browser.MiddlePause();

                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                Borrow.Click();
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewBorrowRequest("REP");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);


                Console.WriteLine("Do the final assert...");
                try
                {
                    IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                    Close.Click();
                }
                catch (Exception)
                {

                }

                Browser.ShortPause();

                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.LongPause();


                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table~ .content-table .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "New request is not displayed under 'My requests' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyRequestCanbeCancelled()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();

                Browser.MiddlePause();
                TermsandConditionAceptance();
                Browser.ShortPause();

                //CreateNewRequest();

                IWebElement creationDate = Browser.CurrentBrowser.FindElement(LastRequestCreationDate);
                string date = creationDate.Text;
                IWebElement cancelbtn = Browser.CurrentBrowser.FindElement(CancelRequestBtn);
                cancelbtn.Click();
                Browser.ShortPause();
                IWebElement confirm = Browser.CurrentBrowser.FindElement(ConfirmCancellationRequest);
                confirm.Click();
                Browser.MiddlePause();
                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                Browser.LongPause();

                Browser.CurrentBrowser.Navigate().Refresh();

                Browser.ShortPause();

                SignRequest();

                string EnvironmentAfterSign = TestData.DefineEnvironmentDependingOnEnvironment();
                if (EnvironmentAfterSign.Contains("Kovan"))
                {
                    Browser.LongPause();
                    Browser.LongPause();
                }
                else
                {
                    Browser.LongPause();
                    Browser.LongPause();
                    Browser.LongPause();
                }
                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();

                Console.WriteLine("Do the final assert...");
                IWebElement cancelledcreationtime = Browser.CurrentBrowser.FindElement(CancelledCreationTime);
                string cancelledtime = cancelledcreationtime.Text;

                Assert.IsTrue(cancelledtime.Contains(date), "[" + Env + "] BLOQBOARD", "Cancelled request is not displayed in the 'Cancelled requests' table");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyLoanScanCardisOpenedfromBloqBoard()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Loans);
                Browser.MiddlePause();

                IWebElement date = Browser.CurrentBrowser.FindElement(LoanIssuedDateBloqBoard);
                string dateissued = date.Text;

                date.Click();
                Browser.LongPause();

                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

                string Loanscan = handles[1];
                string BloqboardTab = handles[0];

                Browser.CurrentBrowser.SwitchTo().Window(Loanscan);
                Browser.MiddlePause();
                IWebElement dateloanscan = Browser.CurrentBrowser.FindElement(LoanIssuedDateLoanscan);
                string dateissuedloanscan = dateloanscan.Text;
                string[] stringSeparators = new string[] { ":" };
                var result = dateissuedloanscan.Split(stringSeparators, StringSplitOptions.None);

                Console.WriteLine("Do the final assert...");
                Assert.IsTrue(dateissued.Contains(result[1]), "[" + Env + "] BLOQBOARD", "The card opened from Bloqboard in Loanscan seems to be incorrect");

            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyRequestCanBeLended()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("borrower");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");
                Browser.MiddlePause();

                IWebElement filterDropdown = Browser.CurrentBrowser.FindElement(By.CssSelector("i.material-icons.filter-button__filter-icon"));
                filterDropdown.Click();

                IWebElement filterTick = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:first-child > div.token-list-filter__cell.token-list-filter__cell--token-principal > label"));
                filterTick.Click();

                IWebElement filterChoose = Browser.CurrentBrowser.FindElement(By.CssSelector("button.filter-modal__btn.filter-modal__btn--apply"));
                filterChoose.Click();

                Browser.ShortPause();

                Console.WriteLine("Choose filter values...");
                IWebElement filterAmountDropdown = Browser.CurrentBrowser.FindElement(By.CssSelector("div.dropdown__header"));
                filterAmountDropdown.Click();

                IWebElement filterAmountTick = Browser.CurrentBrowser.FindElement(By.CssSelector("div.dropdown__list > div:nth-of-type(5) > div.sort-dropdown__item"));
                filterAmountTick.Click();

                IList<IWebElement> loans = Browser.CurrentBrowser.FindElements(By.CssSelector(".btn-red"));
                loans[0].Click();
                Browser.ShortPause();

                IWebElement fundBtn = Browser.CurrentBrowser.FindElement(FundLoanRequest);
                fundBtn.Click();

                Browser.MiddlePause();
                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                Browser.CurrentBrowser.Navigate().Refresh();

                Browser.ShortPause();

                SignRequest();

                Console.WriteLine("Do the final assert...");
                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();

                IWebElement msg = Browser.CurrentBrowser.FindElement(TransactionSuccessfulMsg);
                Assert.IsTrue(msg.Displayed, "[" + Env + "] BLOQBOARD", "Lend request transaction is not performed as expected");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }

        }

        public static void VerifyRepayFunctionality()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                Borrow.Click();
                Browser.MiddlePause();

                IList<IWebElement> RepayButtons = Browser.CurrentBrowser.FindElements(By.CssSelector(".borrowed-assets-wrapper .btn-red"));
                var repCount = RepayButtons.Count;

                if (RepayButtons.Count > 0)
                {
                    RepayButtons[0].Click();

                    IWebElement repaySumm = Browser.CurrentBrowser.FindElement(By.CssSelector("form > div:nth-of-type(2) > div.row-value-wrapper > div.row-value"));
                    string[] repayment = repaySumm.Text.Split(' ');

                    IWebElement repayInput = Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"amount\"]"));
                    repayInput.SendKeys("0.000000001");

                    IWebElement submit = Browser.CurrentBrowser.FindElement(By.CssSelector("button.confirm-repay-btn"));
                    submit.Click();

                    Console.WriteLine("Approve on MetaMask...");
                    Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                    Console.WriteLine("Do the final assert...");

                    IWebElement BorrowTab = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                    BorrowTab.Click();
                    Browser.MiddlePause();

                    IList<IWebElement> RepayButtonsAfterRepay = Browser.CurrentBrowser.FindElements(By.CssSelector(".borrowed-assets-wrapper .btn-red"));
                    var repCountAfterRepay = RepayButtonsAfterRepay.Count;

                    Assert.IsTrue(repCount == repCountAfterRepay, "[" + Env + "] BLOQBOARD", "Repay transaction is not performed as expected");
                }

            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyCollatrealCanbeReturned()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                Borrow.Click();
                Browser.MiddlePause();

                IWebElement loansbtn = Browser.CurrentBrowser.FindElement(LoansMenuBtn);
                loansbtn.Click();
                Browser.LongPause();

                string amountrepayed = "";
                string BloqboardTabNew = "";
                string MetamaskTabNew = "";
                string date = "";

                bool isRepaid = false;

                for (int i = 0; i < 25; i++)
                {
                    if (!isRepaid)
                    {
                        var clickedTime = "no collateral found";

                        IList<IWebElement> elementListRows = Browser.CurrentBrowser.FindElements(By.CssSelector(".first div.content-table-row"));
                        foreach (var el in elementListRows)
                        {
                            var children = el.FindElements(By.XPath(".//*"));


                            var button = children[children.Count - 2];
                            if (button.Text == "REPAY")
                            {
                                date = children[0].Text;

                                var repay = children[children.Count - 2];
                                repay.Click();
                                isRepaid = true;
                                break;
                            }

                        }

                        if (!isRepaid)
                        {
                            Browser.ShortPause();
                            IWebElement page = Browser.CurrentBrowser.FindElement(By.CssSelector(".page-item:nth-child(7) .page-link"));
                            page.Click();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        break;
                    }
                }


                Browser.MiddlePause();
                IWebElement amounttorepay = Browser.CurrentBrowser.FindElement(WholeAmountToRepay);
                string amount = amounttorepay.Text;

                string[] stringSeparators = new string[] { "WETH" };
                var result = amount.Split(stringSeparators, StringSplitOptions.None);



                IWebElement amountrepay = Browser.CurrentBrowser.FindElement(InputRepayAmount);
                amountrepay.SendKeys(result[0]);

                IWebElement confirmrepaybtn = Browser.CurrentBrowser.FindElement(ConfirmRepay);
                confirmrepaybtn.Click();
                Browser.MiddlePause();


                ReadOnlyCollection<string> handlesnew = Browser.CurrentBrowser.WindowHandles;

                BloqboardTabNew = handlesnew[1];
                MetamaskTabNew = handlesnew[0];


                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTabNew);
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.ShortPause();
                SignRequest();
                Browser.LongPause();
                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabNew);

                Browser.ShortPause();
                CheckReturn(date);

                Browser.ShortPause();
                IWebElement confirmreturnCollateral = Browser.CurrentBrowser.FindElement(By.CssSelector(".confirm-btn"));
                confirmreturnCollateral.Click();
                Browser.MiddlePause();

                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTabNew);
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.ShortPause();
                SignRequest();
                Browser.LongPause();
                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabNew);

                Browser.ShortPause();
                bool isreturned = CheckCollateral(date);

                Assert.IsTrue(isreturned, "[" + Env + "] BLOQBOARD", "Return collateral is not performed as expected");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }

        }

        public static void VerifyCollateralCanBeSeized()
        {
            Console.WriteLine("Login to the app...");
            ReadOnlyCollection<string> windows = LoginToMainPage("lender");
            string MetamaskTab = windows[0];
            string BloqboardTab = windows[1];

            Console.WriteLine("Test started...");
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "loans");
            Browser.MiddlePause();

            IWebElement loansbtn = Browser.CurrentBrowser.FindElement(LoansMenuBtn);
            loansbtn.Click();
            Browser.MiddlePause();

            var dateOfClickedCollateral = ClickCollateralButtonAndReturnDate();


            Browser.ShortPause();
            IWebElement confirm = Browser.CurrentBrowser.FindElement(ConfirmSeizing);
            confirm.Click();

            Browser.MiddlePause();
            Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
            Browser.CurrentBrowser.Navigate().Refresh();

            Browser.ShortPause();
            SignRequest();

            Console.WriteLine("Do the final assert...");
            Browser.LongPause();
            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.LongPause();



            bool isSiezed = CheckIfCollateralSiezed(dateOfClickedCollateral);

            Assert.IsTrue(isSiezed, "[" + Env + "] BLOQBOARD", "Collateral is not seized properly");

        }

        public static void VerifyNewZrxOfferToLendCanBeCreated()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("lender");
                string metamaskTab = windows[0];
                string bloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement myRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                myRequests.Click();
                Browser.MiddlePause();
                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewOffersToLendRequest("ZRX");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(metamaskTab, bloqboardTab);

                Console.WriteLine("Do the final assert...");
                IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                Close.Click();
                Browser.ShortPause();

                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.MiddlePause();

                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "Offer to lend is not displayed under 'My Offers to lend' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewDaiOfferToLendCanBeCreated()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();
                Browser.MiddlePause();
                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewOffersToLendRequest("DAI");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                Console.WriteLine("Do the final assert...");
                try
                {
                    IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                    Close.Click();
                }
                catch (Exception)
                {

                }
                Browser.ShortPause();

                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.MiddlePause();

                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "Offer to lend is not displayed under 'My Offers to lend' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewBatOfferToLendCanBeCreated()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();
                Browser.MiddlePause();
                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewOffersToLendRequest("BAT");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                Console.WriteLine("Do the final assert...");
                try
                {
                    IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                    Close.Click();
                }
                catch (Exception)
                {

                }
                Browser.ShortPause();

                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.MiddlePause();

                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "Offer to lend is not displayed under 'My Offers to lend' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewRepOfferToLendCanBeCreated()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyRequests = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequests.Click();
                Browser.MiddlePause();
                Console.WriteLine("Getting initial values before operation (Loan offers)...");
                List<string> myRequestsBefore = new List<string>();
                IList<IWebElement> requests = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requests)
                {
                    myRequestsBefore.Add(request.Text);
                }
                var lastLoanbefore = myRequestsBefore.First();

                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");
                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewOffersToLendRequest("REP");

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                Console.WriteLine("Do the final assert...");
                try
                {
                    IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                    Close.Click();
                }
                catch (Exception)
                {

                }
                Browser.ShortPause();

                IWebElement MyRequestsAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(3)"));
                MyRequestsAfter.Click();
                Browser.MiddlePause();

                List<string> myRequestsAfter = new List<string>();
                IList<IWebElement> requestsAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".content-table:nth-child(2) .first+ .bottom-cell"));
                foreach (var request in requestsAfter)
                {
                    myRequestsAfter.Add(request.Text);
                }
                var lastLoanAfter = myRequestsAfter.First();

                Assert.IsTrue(lastLoanbefore != lastLoanAfter, "[" + Env + "] BLOQBOARD", "Offer to lend is not displayed under 'My Offers to lend' table");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewlyCreatedRequestToLendCanBeBorrowed()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("borrower");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyLoans = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                MyLoans.Click();
                Browser.MiddlePause();

                Console.WriteLine("Geting last request value...");
                IWebElement lastBorrowed = Browser.CurrentBrowser.FindElement(By.CssSelector("div.borrowed-assets-wrapper > div.content-table > div.content-table-body > div:first-child > div.content-table-cell.text-left.width-m > div.bottom-cell"));
                string recentrequest = lastBorrowed.Text;

                IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                Borrow.Click();
                Browser.MiddlePause();

                Console.WriteLine("Choose low values in requests filter...");
                IWebElement openfilter = Browser.CurrentBrowser.FindElement(By.CssSelector("div.filter-button__filter-wrapper"));
                openfilter.Click();

                IWebElement showallvalues = Browser.CurrentBrowser.FindElement(By.CssSelector("div.token-list-filter__collapse-label > span"));
                showallvalues.Click();

                IWebElement choosecollateral = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(5) > div:nth-of-type(2) > label"));
                choosecollateral.Click();

                IWebElement apply = Browser.CurrentBrowser.FindElement(By.CssSelector("button.filter-modal__btn.filter-modal__btn--apply"));
                apply.Click();
                Browser.ShortPause();

                IWebElement lovValued = Browser.CurrentBrowser.FindElement(By.CssSelector("div.dropdown__header"));
                lovValued.Click();

                IWebElement lowamount = Browser.CurrentBrowser.FindElement(By.CssSelector("div.dropdown__list > div:nth-of-type(5) > div.sort-dropdown__item"));
                lowamount.Click();
                Browser.ShortPause();

                Console.WriteLine("Choosing Borrow action...");
                IList<IWebElement> borrowbtns = Browser.CurrentBrowser.FindElements(By.CssSelector(".btn-green"));
                borrowbtns[1].Click();
                Browser.MiddlePause();
                IWebElement borrowtokens = Browser.CurrentBrowser.FindElement(BorrowTokensGreenBtn);
                borrowtokens.Click();

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                Console.WriteLine("Do the final assert...");
                IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                Close.Click();
                Browser.ShortPause();

                IWebElement MyLoansAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                MyLoansAfter.Click();
                Browser.MiddlePause();

                IWebElement lastBorrowedChanged = Browser.CurrentBrowser.FindElement(By.CssSelector("div.borrowed-assets-wrapper > div.content-table > div.content-table-body > div:first-child > div.content-table-cell.text-left.width-m > div.bottom-cell"));
                string recentrequestChanged = lastBorrowedChanged.Text;
                Assert.IsTrue(!recentrequestChanged.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Peer-to-peer borrowing is probably not working. Please check manually.");
            }
            catch (Exception exception)
            {
                Browser.Close();
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyNewlyCreatedRequestToBorrowCanBeLend()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                IWebElement MyLoans = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                MyLoans.Click();
                Browser.MiddlePause();

                IWebElement lastBorrowed = Browser.CurrentBrowser.FindElement(By.CssSelector("div.loaned-assets-wrapper > div.content-table > div.content-table-body > div:first-child > div.content-table-cell.text-left.width-m > div.bottom-cell"));
                string recentrequest = lastBorrowed.Text;

                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Lend);

                Browser.LongPause();
                Console.WriteLine("Choose low values in requests filter");
                IWebElement openfilter = Browser.CurrentBrowser.FindElement(By.CssSelector("div.filter-button__filter-wrapper"));
                openfilter.Click();

                IWebElement showallvalues = Browser.CurrentBrowser.FindElement(By.CssSelector("div.token-list-filter__collapse-label > span"));
                showallvalues.Click();
                Browser.ShortPause();


                IWebElement collateral = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(5) > div:nth-of-type(2) > label"));
                collateral.Click();

                IWebElement apply = Browser.CurrentBrowser.FindElement(By.CssSelector("button.filter-modal__btn.filter-modal__btn--apply"));
                apply.Click();
                Browser.ShortPause();

                IWebElement lovValued = Browser.CurrentBrowser.FindElement(By.CssSelector("div.dropdown__header"));
                lovValued.Click();

                IWebElement lowamount = Browser.CurrentBrowser.FindElement(By.CssSelector("div.dropdown__list > div:nth-of-type(5) > div.sort-dropdown__item"));
                lowamount.Click();
                Browser.ShortPause();

                IList<IWebElement> borrowbtns = Browser.CurrentBrowser.FindElements(By.CssSelector(".btn-red"));
                borrowbtns[1].Click();
                Browser.MiddlePause();
                IWebElement borrowtokens = Browser.CurrentBrowser.FindElement(By.CssSelector("button.loan-details-btn.btn-red"));
                borrowtokens.Click();
                Browser.ShortPause();

                Console.WriteLine("Approve on MetaMask...");
                Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                Console.WriteLine("Do the final assert...");
                IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.main-btn"));
                Close.Click();
                Browser.LongPause();
                IWebElement MyLoansAfter = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:nth-of-type(2) > a:nth-of-type(2)"));
                MyLoansAfter.Click();
                Browser.LongPause();

                IWebElement lastBorrowedChanged = Browser.CurrentBrowser.FindElement(By.CssSelector("div.loaned-assets-wrapper > div.content-table > div.content-table-body > div:first-child > div.content-table-cell.text-left.width-m > div.bottom-cell"));
                string recentrequestChanged = lastBorrowedChanged.Text;
                Assert.IsTrue(!recentrequestChanged.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Peer-to-peer borrowing is probably not working. Please check manually.");
            }
            catch (Exception exception)
            {
                Browser.Close();
                try
                {
                    ScreenShot.TakeWebScreenshot();
                }
                catch (Exception) { }
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }


        public static void VerifyOffersToLandValuesPresenceAfterRequests()
        {
            Console.WriteLine("Test started...");
            LoginToMainPage("borrower");

            Console.WriteLine("Test started...");
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Requests);

            Browser.MiddlePause();

            //IWebElement borrowbtn = Browser.CurrentBrowser.FindElement(BorrowPtwoPBtn);
            //borrowbtn.Click();
            //Browser.MiddlePause();
            //IWebElement borrowtokens = Browser.CurrentBrowser.FindElement(BorrowTokensGreenBtn);
            //borrowtokens.Click();
            //Browser.ShortPause();
            //Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
            //Browser.CurrentBrowser.Navigate().Refresh();
            //Browser.ShortPause();
            //SignRequest();
            //Browser.LongPause();
            //Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            //Browser.LongPause();
            //IWebElement msg = Browser.CurrentBrowser.FindElement(TransactionMessage);
            //Assert.IsTrue(msg.Displayed, "", "");
        }

        public static void VerifyEthCanBeWrapped()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                Browser.MiddlePause();

                IList<IWebElement> values = Browser.CurrentBrowser.FindElements(By.CssSelector(".amount-cell .bottom-cell"));
                string recentrequest = values[0].Text;

                IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#wrapPopover"));
                wrap.Click();

                IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                amount.SendKeys("0.01");

                IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                btnwrap.Click();

                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                Browser.LongPause();
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.ShortPause();

                Console.WriteLine("Signing request...");
                SignRequest();

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.LongPause();
                Browser.LongPause();
                Browser.LongPause();

                IList<IWebElement> valuesAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".amount-cell .bottom-cell"));
                string newcreatedrequest = valuesAfter[0].Text;

                Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyETHCanBeUnwrapped()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);

                Browser.MiddlePause();

                string environment = TestData.DefineEnvironmentDependingOnEnvironment();
                if (environment.Contains("STAGING") || environment.Contains("PROD_Mainnet"))
                {

                }
                else
                {
                    IWebElement termschecbox = Browser.CurrentBrowser.FindElement(TermsAndCOnditionsCheckBox);
                    termschecbox.Click();
                    Browser.ShortPause();
                    IWebElement continuebtn = Browser.CurrentBrowser.FindElement(Continuebtn);
                    continuebtn.Click();
                    Browser.MiddlePause();
                }
                Browser.ShortPause();

                IList<IWebElement> values = Browser.CurrentBrowser.FindElements(By.CssSelector(".amount-cell .bottom-cell"));
                string recentrequest = values[0].Text;

                IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#unWrapPopover"));
                wrap.Click();

                IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                amount.SendKeys("0.01");

                IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                btnwrap.Click();

                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                Browser.LongPause();
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.ShortPause();

                Console.WriteLine("Signing request...");
                SignRequest();

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.LongPause();
                Browser.CurrentBrowser.Navigate().Refresh();
                Browser.LongPause();
                Browser.LongPause();

                IList<IWebElement> valuesAfter = Browser.CurrentBrowser.FindElements(By.CssSelector(".amount-cell .bottom-cell"));
                string newcreatedrequest = valuesAfter[0].Text;

                Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyPermissionCanBeEnabled()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                //Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                //Browser.MiddlePause();

                //Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "add-offer-to-lend");
                //Browser.ShortPause();
                //Browser.CurrentBrowser.FindElement(By.Name("principalToken")).Click();
                //new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("principalToken"))).SelectByText("DAI");
                //Browser.ShortPause();
                //Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"amount\"]")).SendKeys("0.001");
                //Browser.ShortPause();
                //Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"interestRate\"]")).SendKeys("1");
                //Browser.ShortPause();


                //Browser.MiddlePause();

                //IWebElement isDisabled1 = Browser.CurrentBrowser.FindElement(By.CssSelector(".slider"));
                //var lol = isDisabled1.GetAttribute("class");
                //if (lol.Contains("slider_off"))
                //{
                //    //disabled
                //    IWebElement submit = Browser.CurrentBrowser.FindElement(By.CssSelector("[type='submit']"));
                //    submit.Click();
                //    IWebElement error = Browser.CurrentBrowser.FindElement(By.CssSelector("div.loan-form__error"));
                //    Assert.IsTrue(error.Text.Contains("Please grant permission to use DAI in peer-to-peer loans"), "[" + Env + "] BLOQBOARD", "Enable permissions is not working correctly");

                //    IWebElement isDisabled2 = Browser.CurrentBrowser.FindElement(By.CssSelector(".slider"));
                //    isDisabled2.Click();

                //    Browser.MiddlePause();

                //    Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //    Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.ShortPause();

                //    Console.WriteLine("Confirming request...");
                //    SignRequest();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.LongPause();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.Name("principalToken")).Click();
                //    new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("principalToken"))).SelectByText("DAI");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"amount\"]")).SendKeys("0.001");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"interestRate\"]")).SendKeys("1");
                //    Browser.ShortPause();


                //    IWebElement lend = Browser.CurrentBrowser.FindElement(By.CssSelector("button.loan-form__btn.lend"));
                //    lend.Click();
                //    Browser.ShortPause();

                //    Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //    Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.ShortPause();
                //    IList<IWebElement> buttons = Browser.CurrentBrowser.FindElements(By.CssSelector("button"));

                //    Assert.IsTrue(buttons.Count > 1, "[" + Env + "] BLOQBOARD", "Enable permissions is not working correctly");
                //}
                //else
                //{
                //    IWebElement isDisabled2 = Browser.CurrentBrowser.FindElement(By.CssSelector(".slider"));
                //    isDisabled2.Click();

                //    Browser.MiddlePause();

                //    Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //    Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.ShortPause();

                //    Console.WriteLine("Confirming request...");
                //    SignRequest();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.LongPause();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.Name("principalToken")).Click();
                //    new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("principalToken"))).SelectByText("DAI");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"amount\"]")).SendKeys("0.001");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"interestRate\"]")).SendKeys("1");
                //    Browser.ShortPause();
                //    IWebElement submit = Browser.CurrentBrowser.FindElement(By.CssSelector("[type='submit']"));
                //    submit.Click();
                //    Browser.ShortPause();
                //    IWebElement error = Browser.CurrentBrowser.FindElement(By.CssSelector("div.loan-form__error"));
                //    Assert.IsTrue(error.Text.Contains("Please grant permission to use DAI in peer-to-peer loans"), "[" + Env + "] BLOQBOARD", "Enable permissions is not working correctly");
                //}


            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyPermissionCanBeDisabled()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                //Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                //Browser.MiddlePause();

                //Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "add-offer-to-lend");
                //Browser.ShortPause();
                //Browser.CurrentBrowser.FindElement(By.Name("principalToken")).Click();
                //new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("principalToken"))).SelectByText("DAI");
                //Browser.ShortPause();
                //Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"amount\"]")).SendKeys("0.001");
                //Browser.ShortPause();
                //Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"interestRate\"]")).SendKeys("1");
                //Browser.ShortPause();


                //Browser.MiddlePause();

                //IWebElement isDisabled1 = Browser.CurrentBrowser.FindElement(By.CssSelector(".slider"));
                //var lol = isDisabled1.GetAttribute("class");
                //if (lol.Contains("slider_off"))
                //{
                //    //disabled
                //    IWebElement submit = Browser.CurrentBrowser.FindElement(By.CssSelector("[type='submit']"));
                //    submit.Click();
                //    IWebElement error = Browser.CurrentBrowser.FindElement(By.CssSelector("div.loan-form__error"));
                //    Assert.IsTrue(error.Text.Contains("Please grant permission to use DAI in peer-to-peer loans"), "[" + Env + "] BLOQBOARD", "Enable permissions is not working correctly");

                //    IWebElement isDisabled2 = Browser.CurrentBrowser.FindElement(By.CssSelector(".slider"));
                //    isDisabled2.Click();

                //    Browser.MiddlePause();

                //    Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //    Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.ShortPause();

                //    Console.WriteLine("Confirming request...");
                //    SignRequest();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.LongPause();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.Name("principalToken")).Click();
                //    new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("principalToken"))).SelectByText("DAI");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"amount\"]")).SendKeys("0.001");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"interestRate\"]")).SendKeys("1");
                //    Browser.ShortPause();


                //    IWebElement lend = Browser.CurrentBrowser.FindElement(By.CssSelector("button.loan-form__btn.lend"));
                //    lend.Click();
                //    Browser.ShortPause();

                //    Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //    Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.ShortPause();
                //    IList<IWebElement> buttons = Browser.CurrentBrowser.FindElements(By.CssSelector("button"));

                //    Assert.IsTrue(buttons.Count > 1, "[" + Env + "] BLOQBOARD", "Enable permissions is not working correctly");
                //}
                //else
                //{
                //    IWebElement isDisabled2 = Browser.CurrentBrowser.FindElement(By.CssSelector(".slider"));
                //    isDisabled2.Click();

                //    Browser.MiddlePause();

                //    Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //    Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.ShortPause();

                //    Console.WriteLine("Confirming request...");
                //    SignRequest();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //    Browser.LongPause();
                //    Browser.CurrentBrowser.Navigate().Refresh();
                //    Browser.LongPause();
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.Name("principalToken")).Click();
                //    new SelectElement(Browser.CurrentBrowser.FindElement(By.Name("principalToken"))).SelectByText("DAI");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"amount\"]")).SendKeys("0.001");
                //    Browser.ShortPause();
                //    Browser.CurrentBrowser.FindElement(By.CssSelector("[name=\"interestRate\"]")).SendKeys("1");
                //    Browser.ShortPause();
                //    IWebElement submit = Browser.CurrentBrowser.FindElement(By.CssSelector("[type='submit']"));
                //    submit.Click();
                //    Browser.ShortPause();
                //    IWebElement error = Browser.CurrentBrowser.FindElement(By.CssSelector("div.loan-form__error"));
                //    Assert.IsTrue(error.Text.Contains("Please grant permission to use DAI in peer-to-peer loans"), "[" + Env + "] BLOQBOARD", "Enable permissions is not working correctly");
                //}


            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyLtvOnHistoryOrder()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                Browser.MiddlePause();

                IWebElement lastrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                string recentrequest = lastrequest.Text;

                //IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#wrapPopover"));
                //wrap.Click();

                //IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                //amount.SendKeys("0.0001");
                //Browser.ShortPause();
                //IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                //btnwrap.Click();
                //Browser.ShortPause();
                //Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.ShortPause();

                //Console.WriteLine("Signing request...");
                //SignRequest();

                //Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.LongPause();
                //IWebElement newrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                //string newcreatedrequest = newrequest.Text;

                //Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyLtvOnJustCreatedOrder()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                Browser.MiddlePause();

                IWebElement lastrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                string recentrequest = lastrequest.Text;

                //IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#wrapPopover"));
                //wrap.Click();

                //IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                //amount.SendKeys("0.0001");
                //Browser.ShortPause();
                //IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                //btnwrap.Click();
                //Browser.ShortPause();
                //Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.ShortPause();

                //Console.WriteLine("Signing request...");
                //SignRequest();

                //Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.LongPause();
                //IWebElement newrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                //string newcreatedrequest = newrequest.Text;

                //Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyAprOnHistoryOrder()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                Browser.MiddlePause();

                IWebElement lastrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                string recentrequest = lastrequest.Text;

                //IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#wrapPopover"));
                //wrap.Click();

                //IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                //amount.SendKeys("0.0001");
                //Browser.ShortPause();
                //IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                //btnwrap.Click();
                //Browser.ShortPause();
                //Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.ShortPause();

                //Console.WriteLine("Signing request...");
                //SignRequest();

                //Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.LongPause();
                //IWebElement newrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                //string newcreatedrequest = newrequest.Text;

                //Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyAPRCalculationOnJustCreatedOrder()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                Browser.MiddlePause();

                IWebElement lastrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                string recentrequest = lastrequest.Text;

                //IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#wrapPopover"));
                //wrap.Click();

                //IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                //amount.SendKeys("0.0001");
                //Browser.ShortPause();
                //IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                //btnwrap.Click();
                //Browser.ShortPause();
                //Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.ShortPause();

                //Console.WriteLine("Signing request...");
                //SignRequest();

                //Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.LongPause();
                //IWebElement newrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                //string newcreatedrequest = newrequest.Text;

                //Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyCollateralizationRatio()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                LoginToMainPage("lender");

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                Browser.MiddlePause();

                IWebElement lastrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                string recentrequest = lastrequest.Text;

                //IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#wrapPopover"));
                //wrap.Click();

                //IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                //amount.SendKeys("0.0001");
                //Browser.ShortPause();
                //IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                //btnwrap.Click();
                //Browser.ShortPause();
                //Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.ShortPause();

                //Console.WriteLine("Signing request...");
                //SignRequest();

                //Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.LongPause();
                //IWebElement newrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                //string newcreatedrequest = newrequest.Text;

                //Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }

        public static void VerifyRepayCalculation()
        {
            try
            {
                Console.WriteLine("Login to the app...");
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                Console.WriteLine("Test started...");
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Assets);
                Browser.MiddlePause();

                IWebElement lastrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                string recentrequest = lastrequest.Text;

                //IWebElement wrap = Browser.CurrentBrowser.FindElement(By.CssSelector("#wrapPopover"));
                //wrap.Click();

                //IWebElement amount = Browser.CurrentBrowser.FindElement(By.CssSelector("input.wrap-input"));
                //amount.SendKeys("0.0001");
                //Browser.ShortPause();
                //IWebElement btnwrap = Browser.CurrentBrowser.FindElement(By.CssSelector("button.wrap-btn"));
                //btnwrap.Click();
                //Browser.ShortPause();
                //Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
                //Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.ShortPause();

                //Console.WriteLine("Signing request...");
                //SignRequest();

                //Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                //Browser.LongPause();
                //Browser.CurrentBrowser.Navigate().Refresh();
                //Browser.LongPause();
                //IWebElement newrequest = Browser.CurrentBrowser.FindElement(By.CssSelector("div.assets-table-body > div:nth-of-type(2) > div.content-table-cell.amount-cell.text-right > div.bottom-cell"));
                //string newcreatedrequest = newrequest.Text;

                //Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "Wrap Ooperation is working incorrectly. Please check manually. was: " + recentrequest + " become: " + newcreatedrequest);
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception, false);
            }
        }
    }
}

