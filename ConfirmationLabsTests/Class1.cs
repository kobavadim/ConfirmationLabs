﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmationLabsTests
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;

        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            driver = new ChromeDriver();
        }
    }
}
