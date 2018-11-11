using System;
using System.Collections.Generic;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Engine;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ConfirmationLabsTests.GUI.Application.BloqBoard
{
    class MainPageBB
    {
        //Elements

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
        static string Env = TestData.DefineEnvironmentDependingOnEnvironment();

        private static readonly By NewRequest = By.CssSelector(".token-item:nth-child(4) .token-item-name");
        private static readonly By AmountInputbyNewRequest = By.CssSelector("[name='amount']");
        private static readonly By InterestInputByNewRequest = By.CssSelector("[name='interestRate']");
        private static readonly By CollateralAmountNewRequest = By.CssSelector("[name='collateralAmount']");
        private static readonly By AddRequestBtn = By.CssSelector("button.loan-request-form__place-btn");
        private static readonly By Signbtn = By.CssSelector("");
        private static readonly By SignButtonMetaMaskPopUp = By.CssSelector(".button");
        private static readonly By CollateralDropDown = By.CssSelector("[name='collateralType']");

        private static readonly By LastRequestCreationDate = By.CssSelector(".first .content-table-row:nth-child(1) .first+ .bottom-cell");
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



        //Methods
        public static void LoginToMetamaskUpdated()
        {
            Console.WriteLine("Logging Metamask");
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();
            string Env = Helpers.TestData.DefineEnvironmentDependingOnEnvironment();
            if (Env == "PROD")
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }

                Browser.MiddlePause();
                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.BloqBoardProd);

                //try
                //{
                //    Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardProd);
                //}
                //catch (Exception ex)
                //{
                //    IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.CurrentBrowser;
                //    js.ExecuteScript("return window.stop");
                //}
            }
            else
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }

                Browser.MiddlePause();
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.BloqBoardKovan);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardKovan);
            }

            Engine.Browser.LongPause();

        }

        public static void LoginToMetamaskUpdatedNewAccount()
        {
            Console.WriteLine("Logging Metamask");
            Wallets.LoginToMetaMaskWalletWithNewUser();
            Browser.MiddlePause();
            string Env = Helpers.TestData.DefineEnvironmentDependingOnEnvironment();
            if (Env == "PROD")
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }

                Browser.MiddlePause();
                Console.WriteLine("running tests on PROD " + Helpers.TestData.Urls.BloqBoardProd);

                //try
                //{
                //    Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardProd);
                //}
                //catch (Exception ex)
                //{
                //    IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.CurrentBrowser;
                //    js.ExecuteScript("return window.stop");
                //}
            }
            else
            {
                Browser.ShortPause();
                IWebElement Button = Browser.CurrentBrowser.FindElement(By.CssSelector(".network-name"));
                Button.Click();
                IList<IWebElement> values = GUI.Engine.Browser.CurrentBrowser.FindElements(By.CssSelector(".network-name-item"));

                Browser.ShortPause();
                foreach (var val in values)
                {
                    if (val.Text.Contains("Kovan"))
                    {
                        val.Click();
                        break;
                    }
                }

                Browser.MiddlePause();
                Console.WriteLine("running tests on KOVAN " + Helpers.TestData.Urls.BloqBoardKovan);
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.BloqBoardKovan);
            }

            Engine.Browser.LongPause();

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

        public static void foreachRows()
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
                if(time == date)
                {
                    var button = children[children.Count - 1];
                    if (button.Text.Contains("Seized"))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }






        public static void CreateNewRequest()
        {
            IList<IWebElement> buttons = Browser.CurrentBrowser.FindElements(By.CssSelector(".token-item-name"));
            foreach (var btn in buttons)
            {
                if (btn.Text == "WETH")
                {
                    btn.Click();
                    break;
                }
            }
            Browser.ShortPause();

            IWebElement amount = Browser.CurrentBrowser.FindElement(AmountInputbyNewRequest);
            amount.SendKeys("0.00005");

            IWebElement interest = Browser.CurrentBrowser.FindElement(InterestInputByNewRequest);
            interest.SendKeys("5");

            IWebElement collateral = Browser.CurrentBrowser.FindElement(CollateralAmountNewRequest);
            collateral.SendKeys("0.0005");
            Browser.ShortPause();
            interest.Submit();
            Browser.MiddlePause();

            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;
           
            string MetamaskTab = handles[0];
            string BloqboardTab = handles[1];

            Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
            Browser.CurrentBrowser.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
            Browser.LongPause();
            Browser.CurrentBrowser.Navigate().Refresh();
            Browser.ShortPause();

            Console.WriteLine("Signing request...");
            SignRequest();

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.LongPause();
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
            seed.SendKeys(TestData.Input.seedPhraseAccount2);
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



        //Tests
        public static void VerifyPageisOpened()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                IWebElement table = Browser.CurrentBrowser.FindElement(LiquidityTable);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "BloqBoard page is not loaded correctly");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyTokensTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                IWebElement tokenstable = Browser.CurrentBrowser.FindElement(TokensTable);
                Assert.IsTrue(tokenstable.Displayed, "[" + Env + "] BLOQBOARD", "Tokens Table is not loaded properly");
            
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyRecentLoansTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                IWebElement table = Browser.CurrentBrowser.FindElement(RecentLoans);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "Recent Loans table is not loaded properly");
            
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyLoanTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Lend);
                Browser.MiddlePause();
                IWebElement table = Browser.CurrentBrowser.FindElement(LoanTable);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "Loan table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyLendToPoolTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Lend);
                Browser.MiddlePause();

                IWebElement loanedtable = Browser.CurrentBrowser.FindElement(LendToPoolTable);
                Assert.IsTrue(loanedtable.Displayed, "[" + Env + "] BLOQBOARD", "Lend to pool table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyAssetstableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance(); Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Assets);
                Browser.MiddlePause();


                IWebElement table = Browser.CurrentBrowser.FindElement(MyWalletTable);
                Assert.IsTrue(table.Displayed, "[" + Env + "] BLOQBOARD", "Assets table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyMyBorrowedTokensTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Loans);
                Browser.MiddlePause();

                IWebElement myborrowedtokenstable = Browser.CurrentBrowser.FindElement(MyBorrowedTokensTable);
                Assert.IsTrue(myborrowedtokenstable.Displayed, "[" + Env + "] BLOQBOARD", "My borrowed tokens table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyMyLendedTokensTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Loans);
                Browser.MiddlePause();

                IWebElement mytokenstable = Browser.CurrentBrowser.FindElement(MyLandedTokensTable);
                Assert.IsTrue(mytokenstable.Displayed, "[" + Env + "] BLOQBOARD", "My lended tokens table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyMyOpenRequestsTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Requests);
                Browser.MiddlePause();

                IWebElement openrequests = Browser.CurrentBrowser.FindElement(MyOpenedRequestsTable);
                Assert.IsTrue(openrequests.Displayed, "[" + Env + "] BLOQBOARD", "My open requests table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyMyCancelledRequestsTableDisplayed()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
                Browser.CurrentBrowser.Navigate().GoToUrl(Helpers.TestData.Urls.Requests);
                Browser.MiddlePause();

                IWebElement requests = Browser.CurrentBrowser.FindElement(MyClosedRequestsTable);
                Assert.IsTrue(requests.Displayed, "[" + Env + "] BLOQBOARD", "My cancelled requests table is not loaded properly");
            }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyNewRequestCanbeCreated()
        {

            try
            {
                LoginToMetamaskUpdated(); 
                Browser.MiddlePause();

                ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;


                string MetamaskTab = handles[0];
                string BloqboardTab = handles[1];

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Requests);



                Browser.MiddlePause();
                TermsandConditionAceptance();
                Browser.ShortPause();
                IWebElement lastrequest = Browser.CurrentBrowser.FindElement(LastRequestCreationDate);
                string recentrequest = lastrequest.Text;

                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment());

                Browser.MiddlePause();
                Console.WriteLine("Creating new request...");
                CreateNewRequest();

                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Requests);
                Browser.LongPause();

                IWebElement newrequest = Browser.CurrentBrowser.FindElement(LastRequestCreationDate);
                string newcreatedrequest = newrequest.Text;

                Assert.IsTrue(!newcreatedrequest.Contains(recentrequest), "[" + Env + "] BLOQBOARD", "New request is not displayed under 'My requests' table");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyRequestCanbeCancelled()
        {
            try
            {
                LoginToMetamaskUpdated();
                Browser.MiddlePause();

                ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

                string MetamaskTab = handles[0];
                string BloqboardTab = handles[1];

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Requests);

                Browser.MiddlePause();
                TermsandConditionAceptance();
                Browser.ShortPause();

                //CreateNewRequest();

                //Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.Requests);
                //Browser.MiddlePause();

                IWebElement creationDate= Browser.CurrentBrowser.FindElement(LastRequestCreationDate);
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

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();
                Browser.LongPause();
                Browser.LongPause();

                //добавить ообработку длинных транзакций
                IWebElement cancelledcreationtime = Browser.CurrentBrowser.FindElement(CancelledCreationTime);
                string cancelledtime = cancelledcreationtime.Text;

                Assert.IsTrue(cancelledtime.Contains(date), "[" + Env + "] BLOQBOARD", "Cancelled request is not displayed in the 'Cancelled requests' table");
            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyLoanScanCardisOpenedfromBloqBoard()
        {
            try
            {
                LoginToMetamaskUpdated();
                TermsandConditionAceptance();
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

            
            Assert.IsTrue(dateissued.Contains(result[1]), "[" + Env + "] BLOQBOARD", "The card opened from Bloqboard in Loanscan seems to be incorrect");


        }

            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
}

        public static void VerifyRequestCanBeLended()
        {
            try
            {
                LoginToMetamaskUpdatedNewAccount();
                Browser.MiddlePause();

                ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;

                string MetamaskTab = handles[0];
                string BloqboardTab = handles[1];

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");

                Browser.MiddlePause();
                TermsandConditionAceptance();
                Browser.MiddlePause();

                IWebElement filterDropdown = Browser.CurrentBrowser.FindElement(By.CssSelector("i.material-icons.filter-button__filter-icon"));
                filterDropdown.Click();

                IWebElement filterTick = Browser.CurrentBrowser.FindElement(By.CssSelector("div > div:first-child > div.token-list-filter__cell.token-list-filter__cell--token-principal > label"));
                filterTick.Click();

                IWebElement filterChoose = Browser.CurrentBrowser.FindElement(By.CssSelector("button.filter-modal__btn.filter-modal__btn--apply"));
                filterChoose.Click();

                Browser.ShortPause();

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

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.LongPause();

                //добавить ожидание транзакции
                IWebElement msg = Browser.CurrentBrowser.FindElement(TransactionSuccessfulMsg);
                Assert.IsTrue(msg.Displayed, "[" + Env + "] BLOQBOARD", "Lend request transaction is not performed as expected");

            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }

        }

        public static void VerifyRepayFunctionality()
        {
            try
            {
                Wallets.LoginToMetaMaskWallet();
                Browser.MiddlePause();
                Wallets.ChangeToKovan();
                Browser.MiddlePause();

                ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
                ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;


                string MetamaskTab = handles[0];
                string BloqboardTab = handles[1];

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
                Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment());

                Browser.MiddlePause();
                TermsandConditionAceptance();

                IWebElement loansbtn = Browser.CurrentBrowser.FindElement(LoansMenuBtn);
                loansbtn.Click();
                Browser.MiddlePause();


                IWebElement firsttransaction = Browser.CurrentBrowser.FindElement(FirstTransactionLoaned);
                firsttransaction.Click();

                Browser.LongPause();

                ReadOnlyCollection<string> handlesnew = Browser.CurrentBrowser.WindowHandles;

                string Loanscan = handlesnew[2];
                string BloqboardTabNew = handlesnew[1];
                string MetamaskTabNew = handlesnew[0];

                Browser.CurrentBrowser.SwitchTo().Window(Loanscan);
                Browser.MiddlePause();

                IWebElement loanscanamount = Browser.CurrentBrowser.FindElement(RepaymanrAmountLoanscan);
                string amountrepayed = loanscanamount.Text;

                string[] stringSeparators = new string[] { "(" };
                var result = amountrepayed.Split(stringSeparators, StringSplitOptions.None);

                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabNew);


                IWebElement repaybtn = Browser.CurrentBrowser.FindElement(RepayBtn);
                repaybtn.Click();
                Browser.MiddlePause();
                IWebElement amountrepay = Browser.CurrentBrowser.FindElement(InputRepayAmount);
                amountrepay.SendKeys("0.00001");

                IWebElement confirmrepaybtn = Browser.CurrentBrowser.FindElement(ConfirmRepay);
                confirmrepaybtn.Click();

                Browser.MiddlePause();
                Browser.CurrentBrowser.SwitchTo().Window(MetamaskTabNew);
                Browser.CurrentBrowser.Navigate().Refresh();

                Browser.ShortPause();
                SignRequest();

                Browser.LongPause();
                Browser.CurrentBrowser.SwitchTo().Window(BloqboardTabNew);

                IWebElement firsttransaction2 = Browser.CurrentBrowser.FindElement(FirstTransactionLoaned);
                firsttransaction2.Click();

                Browser.LongPause();

                ReadOnlyCollection<string> handlesnew2 = Browser.CurrentBrowser.WindowHandles;

                string Loanscannew = handlesnew2[4];




                Browser.CurrentBrowser.SwitchTo().Window(Loanscannew);
                Browser.MiddlePause();

                IWebElement loanscanamountnew = Browser.CurrentBrowser.FindElement(RepaymanrAmountLoanscan);
                string amountrepayednew = loanscanamountnew.Text;

                string[] stringSeparatorsnew = new string[] { "(" };
                var resultnew = amountrepayednew.Split(stringSeparatorsnew, StringSplitOptions.None);

                Assert.IsTrue(!result[0].Contains(resultnew[0]), "[" + Env + "] BLOQBOARD", "Repay transaction is not performed as expected");

            }
            catch (Exception exception)
            {
                Assert.FinilizeErrors(Env, "BLOQBOARD", exception);
            }
        }

        public static void VerifyCollatrealCanbeReturned()
        {
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();
            Wallets.ChangeToKovan();
            Browser.MiddlePause();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;


            string MetamaskTab = handles[0];
            string BloqboardTab = handles[1];

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment());

            Browser.MiddlePause();
            TermsandConditionAceptance();

            IWebElement loansbtn = Browser.CurrentBrowser.FindElement(LoansMenuBtn);
            loansbtn.Click();
            Browser.MiddlePause();

            IWebElement repaybtn = Browser.CurrentBrowser.FindElement(RepayBtn);
            repaybtn.Click();
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
            Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
            Browser.CurrentBrowser.Navigate().Refresh();

            Browser.ShortPause();
            SignRequest();

            Browser.LongPause();
            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.LongPause();

            IWebElement seaizecollateralbtn = Browser.CurrentBrowser.FindElement(SeizeCollarealBtn);
            Assert.IsTrue(seaizecollateralbtn.Displayed, "[" + Env + "] BLOQBOARD", "Return collateral button is not displayed after the full repayment");
            Browser.ShortPause();

            //дальше надо еще дописать нажатие на кнопку и вернуть коллатерал
            seaizecollateralbtn.Click();
            Browser.ShortPause();
            IWebElement confirm = Browser.CurrentBrowser.FindElement(ConfirmReturnCollateralBtn);
            confirm.Click();

            Browser.MiddlePause();
            Browser.CurrentBrowser.SwitchTo().Window(MetamaskTab);
            Browser.CurrentBrowser.Navigate().Refresh();

            Browser.ShortPause();
            SignRequest();

            Browser.LongPause();
            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.LongPause();

            IWebElement returnedcollateraloutout = Browser.CurrentBrowser.FindElement(CollateralReturnedBtn);
            Assert.IsTrue(returnedcollateraloutout.Text.Contains("Returned"), "[" + Env + "] BLOQBOARD", "Collateral is not returned properly");
        }

        public static void VerifyCollateralCanBeSeized()
        {
            Wallets.LoginToMetaMaskWallet();
            Browser.MiddlePause();
            Wallets.ChangeToKovan();
            Browser.MiddlePause();

            ((IJavaScriptExecutor)Browser.CurrentBrowser).ExecuteScript("window.open();");
            ReadOnlyCollection<string> handles = Browser.CurrentBrowser.WindowHandles;


            string MetamaskTab = handles[0];
            string BloqboardTab = handles[1];

            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment());

            Browser.MiddlePause();
            TermsandConditionAceptance();
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

            Browser.LongPause();
            Browser.CurrentBrowser.SwitchTo().Window(BloqboardTab);
            Browser.LongPause();



            bool isSiezed = CheckIfCollateralSiezed(dateOfClickedCollateral);

            Assert.IsTrue(isSiezed, "[" + Env + "] BLOQBOARD", "Collateral is not seized properly");

        }



    }



    }

