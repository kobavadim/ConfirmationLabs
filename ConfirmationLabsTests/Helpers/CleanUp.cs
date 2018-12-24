using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.GUI.Engine;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace ConfirmationLabsTests.Helpers
{
    public class CleanUp
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("Cleanup")]
        [Test]
        public void CloseBrowser()
        {
            try
            {
                ICapabilities capabilities = ((RemoteWebDriver)Browser.CurrentBrowser).Capabilities;
                var version = capabilities.GetCapability("version");
                var path = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                System.IO.File.WriteAllText(path + "\\" + "seleniumVersion.txt", version.ToString());

                Browser.CurrentBrowser.Quit();
                Browser.CurrentBrowser.Close();
            }
            catch (Exception e)
            {

            }
    

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (process.ProcessName.Contains("chromedriver") || process.ProcessName.Contains("chrome"))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        [Category("DataPreparation")]
        [Test]
        public void BorrowerPreparation()
        {
            try
            {
                //Login to the app
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("borrower");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                //Borrow
                for (int i = 0; i < 2; i++)
                {
                    //Test started
                    IWebElement Borrow = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(1)"));
                    Borrow.Click();
                    Browser.MiddlePause();
                    Console.WriteLine("Creating new request...");
                    MainPageBb.CreateNewBorrowRequest();

                    //approve on MetaMask
                    Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);


                    //Check values
                    try
                    {
                        IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.ok-btn"));
                        Close.Click();
                    }
                    catch (Exception)
                    {

                    }
                    Browser.ShortPause();
                }
            }
            catch (Exception)
            {
                Browser.Close();
            }
        }

        [Category("DataPreparation")]
        [Test]
        public void LenderPreparation()
        {
            try
            {
                //Login to the app
                ReadOnlyCollection<string> windows = MainPageBb.LoginToMainPage("lender");
                string MetamaskTab = windows[0];
                string BloqboardTab = windows[1];

                //Lend
                for (int i = 0; i < 2; i++)
                {
                    //Test started
                    IWebElement Lend = Browser.CurrentBrowser.FindElement(By.CssSelector("div.sidebar-block.loans-block > a:nth-of-type(2)"));
                    Lend.Click();
                    Browser.MiddlePause();

                    //Check values before (Loan offers)
                    Browser.CurrentBrowser.Navigate().GoToUrl(TestData.DefineRootAdressDependingOnEnvironment() + "lend");
                    Browser.MiddlePause();
                    Console.WriteLine("Creating new request...");
                    MainPageBb.CreateNewOffersToLandRequest();

                    //approve on MetaMask
                    Wallets.ApproveTransaction(MetamaskTab, BloqboardTab);

                    //Check values
                    try
                    {
                        IWebElement Close = Browser.CurrentBrowser.FindElement(By.CssSelector("button.ok-btn"));
                        Close.Click();
                    }
                    catch (Exception)
                    {

                    }
                    Browser.ShortPause();
                }
            }
            catch (Exception exception)
            {
                Browser.Close();
            }
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

        private void TestReInitialize()
        {
            TestCleanUp();
            TestInitialize();
        }
    }
}
