using ConfirmationLabsTests.GUI.Engine;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ConfirmationLabsTests.Helpers
{
    class Wallets
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr handle);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        public static void LoginToMetaMaskWallet()
        {
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.MetaMaskChromeLanding);
            Browser.MiddlePause();
            //const int SW_RESTORE = 9;
            //var hWnd = FindWindow(null, "MetaMask - Chrome Web Store");
            //if (IsIconic(hWnd))
            //    ShowWindow(hWnd, SW_RESTORE);
            //SetForegroundWindow(hWnd);

            IList<IWebElement> all = Browser.CurrentBrowser.FindElements(By.CssSelector("[role='button']"));
            foreach (var element in all)
            {
                if (element.Text.Contains("Add to Chrome") || element.Text.Contains("Установить"))
                {
                    element.Click();
                    break;
                }
            }
            Browser.ShortPause();

            //const int SW_RESTOREDouble = 9;
            //var hWndDouble = FindWindow(null, "MetaMask - Chrome Web Store");
            //if (IsIconic(hWndDouble))
            //    ShowWindow(hWndDouble, SW_RESTOREDouble);
            //SetForegroundWindow(hWndDouble);

            AcceptInstallation();
            Browser.CloseAdditionalWindows();
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.MetaMaskMainPageKovan);
            Browser.MiddlePause();
            Browser.CloseAdditionalWindows();

            IWebElement proceed = Browser.CurrentBrowser.FindElement(By.CssSelector(".positive"));
            proceed.Click();
            Browser.MiddlePause();
            Browser.CloseAdditionalWindows();

            IWebElement agreed = Browser.CurrentBrowser.FindElement(By.CssSelector(".welcome-screen__button"));
            agreed.Click();
            Browser.ShortPause();

            IWebElement restoreLink = Browser.CurrentBrowser.FindElement(By.CssSelector(".first-time-flow__link"));
            restoreLink.Click();
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
            ScrollAgreement();

            IWebElement agrementFirstScreen = Browser.CurrentBrowser.FindElement(By.CssSelector(".first-time-flow__button"));
            agrementFirstScreen.Click();
            Browser.ShortPause();
            IWebElement agrementSecondScreen = Browser.CurrentBrowser.FindElement(By.CssSelector(".first-time-flow__button"));
            agrementSecondScreen.Click();
            Browser.ShortPause();
            IWebElement agrementThirdScreen = Browser.CurrentBrowser.FindElement(By.CssSelector(".first-time-flow__button"));
            agrementThirdScreen.Click();
            Browser.MiddlePause();
        }

        public static void ScrollAgreement()
        {
            Browser.MiddlePause();
            SendKeys.SendWait("{TAB}");
            Browser.ShortPause();
            SendKeys.SendWait("{END}");
            Browser.ShortPause();
            SendKeys.SendWait("{TAB}");
            Browser.ShortPause();
            SendKeys.SendWait("{END}");
            Browser.MiddlePause();
        }

        public static void AcceptInstallation()
        {
            Browser.ShortPause();
            SendKeys.SendWait("{TAB}");
            Browser.ShortPause();
            SendKeys.SendWait("{TAB}");
            Browser.ShortPause();
            //SendKeys.SendWait("{ENTER}");
            //Browser.ShortPause();
            //SendKeys.SendWait("%{Tab}");
        }
    }
}
