using ConfirmationLabsTests.GUI.Engine;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            AcceptInstallation();
            Browser.CloseAdditionalWindows();
            Browser.CurrentBrowser.Navigate().GoToUrl(TestData.Urls.MetaMaskMainPageKovan);
            Browser.LongPause();
            Browser.CloseAdditionalWindows();

            var screenname = TestData.GenerateConstant("Screen ");
            ITakesScreenshot screenshotDriver = Browser.CurrentBrowser as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            String fp = "C:\\Users\\Administrator\\Documents\\" + "snapshot" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
            screenshot.SaveAsFile(fp, OpenQA.Selenium.ScreenshotImageFormat.Png);


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
        static class KeyboardSend
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

            private const int KEYEVENTF_EXTENDEDKEY = 1;
            private const int KEYEVENTF_KEYUP = 2;

            public static void KeyDown(System.Windows.Forms.Keys vKey)
            {
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            }

            public static void KeyUp(System.Windows.Forms.Keys vKey)
            {
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
        }
        public static void AcceptInstallation()
        {
            Browser.ShortPause();
            KeyboardSend.KeyDown(System.Windows.Forms.Keys.LWin);
            KeyboardSend.KeyDown(System.Windows.Forms.Keys.D6);
            KeyboardSend.KeyUp(System.Windows.Forms.Keys.LWin);
            KeyboardSend.KeyUp(System.Windows.Forms.Keys.D6);
            Browser.ShortPause();

            KeyboardSend.KeyDown(System.Windows.Forms.Keys.LWin);
            KeyboardSend.KeyDown(System.Windows.Forms.Keys.D6);
            KeyboardSend.KeyUp(System.Windows.Forms.Keys.LWin);
            KeyboardSend.KeyUp(System.Windows.Forms.Keys.D6);

            Browser.MiddlePause();
            SendKeys.SendWait("{TAB}");
            Browser.ShortPause();
            SendKeys.SendWait("{ENTER}");
            Browser.MiddlePause();
        }
    }
}
