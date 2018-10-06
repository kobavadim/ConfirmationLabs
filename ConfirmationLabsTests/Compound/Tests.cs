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
    public class CompoundTests
    {
        private IWebDriver driver;

        [Category("Compound")]
        [Test]
        public void CompoundHealthCheck()
        {
            Console.WriteLine("Compound " + TestData.DefineBaseUrlDependingOnEnvironment());
            driver = new ChromeDriver();
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}
