using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;

namespace ConfirmationLabsTests.GUI.Engine
{
    class Browser
    {
        public static IWebDriver CurrentBrowser;

        public static void Start()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("no-sandbox");
            CurrentBrowser = new ChromeDriver(chromeOptions);
            CurrentBrowser.Manage().Window.Maximize();
        }

        public static void StartWithExstension()
        {
            ChromeOptions chromeoptions = new ChromeOptions();
            chromeoptions.AddArgument("no-sandbox");
            chromeoptions.AddExtensions("C:\\Users\\Administrator\\Documents\\Exstensions\\MetaMask_v4.13.0.crx");
            CurrentBrowser = new ChromeDriver(chromeoptions);
            MiddlePause();
            CurrentBrowser.Manage().Window.Maximize();
        }

        public static void CloseAdditionalWindows()
        {
            String mainWindow = Browser.CurrentBrowser.CurrentWindowHandle;
            Browser.CurrentBrowser.WindowHandles.Where(w => w != mainWindow).ToList()
                .ForEach(w =>
                {
                    Browser.CurrentBrowser.SwitchTo().Window(w);
                    Browser.CurrentBrowser.Close();
                });
            CurrentBrowser.SwitchTo().Window(mainWindow);
        }

        //TODO:add elegant waits
        public static void Pause(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public static void ShortPause()
        {
            Thread.Sleep(3000);
        }

        public static void MiddlePause()
        {
            Thread.Sleep(10000);
        }

        public static void LongPause()
        {
            Thread.Sleep(20000);
        }

        public static void SearchElementAndClickByIt(By by, TimeSpan? timeout = null)
        {
            PerformActionWithTimeOut(
                () =>
                {
                    var element = CurrentBrowser.FindElement(by);
                    if (element != null)
                    {
                        ClickByElement(element);
                        return true;
                    }

                    return false;
                }, timeout ?? TimeSpan.FromSeconds(4));
        }

        public static void PerformActionWithTimeOut(Func<bool> action, TimeSpan timeout)
        {
            Thread.Sleep(2000);

            var sleep = TimeSpan.FromMilliseconds(250);
            var amount = TimeSpan.Zero;

            while (amount <= timeout)
            {
                try
                {
                    if (action.Invoke())
                    {
                        return;
                    }
                }
                catch
                {
                    // ignore
                }

                Thread.Sleep(sleep);
                amount += sleep;
            }

                                   throw new TimeoutException();
        }

        private static bool ClickByElement(IWebElement element, Action<IWebElement> customAction, string actionName)
        {
            try
            {
                customAction.Invoke(element);
                element.Click();
                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }
        
        public static void ClickByElement(IWebElement element)
        {
            int waitTry = 0;
            do
            {
                try
                {
                    waitTry++;

                    var clicked = ClickByElement(element, el => { }, "regular click");

                    if (!clicked)
                    {
                        clicked = ClickByElement(
                            element,
                            el => ((IJavaScriptExecutor)CurrentBrowser).ExecuteScript("arguments[0].click()", el),
                            "javascript click");
                    }

                    if (!clicked)
                    {
                        clicked = ClickByElement(
                            element,
                            el => ((IJavaScriptExecutor)CurrentBrowser).ExecuteScript("arguments[0].scrollIntoView(true);", el),
                            "scrol into view click");
                    }

                    if (!clicked)
                    {
                        clicked = ClickByElement(
                            element,
                            el => new Actions(CurrentBrowser).MoveToElement(el).Perform(),
                            "move to element (actions) click");
                    }

                    if (!clicked)
                    {
                        clicked = ClickByElement(
                            element,
                            el => ((IJavaScriptExecutor)CurrentBrowser).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)"),
                            "scroll down click");
                    }

                    if (!clicked)
                    {
                        clicked = ClickByElement(
                            element,
                            el => ((IJavaScriptExecutor)CurrentBrowser).ExecuteScript("window.scrollBy(500,0)", ""),
                            "scroll down click");
                    }

                    if (clicked) break;
                }
                catch (Exception ex)
                {
                    waitTry++;
                    if (waitTry == 3)
                    {
                        throw new Exception("Cannot find element for 60 seconds. Make sure that UI wasn't changed.");
                    }
                    Thread.Sleep(1000);
                }
                Thread.Sleep(1000);
            }
            while (waitTry < 4);


        }

        public static IWebElement FindElementNew(By by)
        {
            Pause(1000);
            IWebElement result = null;
            Console.WriteLine("Search element exists..." + by);
            int waitTry = 0;
            bool clicked = false;
            do
            {
                try
                {
                    waitTry++;

                    try
                    {
                        var element = CurrentBrowser.FindElement(@by);
                        if (element != null && element.Displayed & element.Enabled)
                            result = element;
                        clicked = true;
                        break;
                    }
                    catch (Exception e) { }

                    if (!clicked)
                    {
                        try
                        {
                            var element = CurrentBrowser.FindElement(@by);
                            ((IJavaScriptExecutor)CurrentBrowser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                            if (element != null && element.Displayed & element.Enabled)
                                result = element;
                            clicked = true;
                            break;
                        }
                        catch (Exception e) { }
                    }

                    if (!clicked)
                    {
                        try
                        {
                            var element = CurrentBrowser.FindElement(@by);
                            Actions actions = new Actions(CurrentBrowser);
                            actions.MoveToElement(element).Perform();
                            if (element != null && element.Displayed & element.Enabled)
                                result = element;
                            clicked = true;
                            break;
                        }
                        catch (Exception e) { }
                    }

                    if (!clicked)
                    {
                        try
                        {
                            var element = CurrentBrowser.FindElement(@by);
                            ((IJavaScriptExecutor)CurrentBrowser).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                            if (element != null && element.Displayed & element.Enabled)
                                result = element;
                            clicked = true;
                            break;
                        }
                        catch (Exception e) { }
                    }

                    if (!clicked)
                    {
                        try
                        {
                            var element = CurrentBrowser.FindElement(@by);
                            ((IJavaScriptExecutor)CurrentBrowser).ExecuteScript("window.scrollBy(500,0)", "");
                            if (element != null && element.Displayed & element.Enabled)
                                result = element;
                            clicked = true;
                            break;
                        }
                        catch (Exception e) { }
                    }
                }
                catch (Exception ex)
                {
                    waitTry++;
                    if (waitTry == 3)
                    {
                        throw new Exception("Cannot find element " + by + " for 60 seconds. Make sure that UI wasn't changed.");
                    }
                    Thread.Sleep(1000);
                }
                Thread.Sleep(1000);
            }
            while (waitTry < 4);
            return result;

        }


        public static void Close()

        {
            try
            {
                Browser.CurrentBrowser.Close();
                Browser.CurrentBrowser.Quit();
            }
            catch (Exception)
            { }

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
    }
}
    

