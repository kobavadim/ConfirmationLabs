using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConfirmationLabsTests
{
    [TestFixture]
    public class LoanscanTests
    {
        private IWebDriver driver;

        [Category("Loanscan")]
        [Test]
        public void LoanscanHealthCheck()
        {
            Console.WriteLine("Loanscan " + TestData.DefineBaseUrlDependingOnEnvironment());
            driver = new ChromeDriver();
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}
