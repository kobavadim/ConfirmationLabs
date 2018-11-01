using System;
using System.Diagnostics;
using System.IO;
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
            Browser.Start();
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

        [TearDown]
        public void TestCleanUp()
        {

        }
    }
}
