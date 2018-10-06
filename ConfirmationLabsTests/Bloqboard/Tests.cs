﻿using NUnit.Framework;
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
    public class BloqboardTests
    {
        private IWebDriver driver;

        [Category("Bloqboard")]
        [Test]
        public void BloqboardHealthCheck()
        {
            Console.WriteLine("Bloqboard " + TestData.DefineBaseUrlDependingOnEnvironment());
            driver = new ChromeDriver();
            Thread.Sleep(3000);
            driver.Close();
        }

    }
}
