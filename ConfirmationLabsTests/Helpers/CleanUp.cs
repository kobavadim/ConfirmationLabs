using System;
using System.Diagnostics;
using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.GUI.Engine;
using NUnit.Framework;

namespace ConfirmationLabsTests.Helpers
{
    public class CleanUp
    {
        [SetUp]
        public void TestInitialize()
        {

        }

        [Category("Cleanup")]
        [Test]
        public void CloseBrowser()
        {
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
