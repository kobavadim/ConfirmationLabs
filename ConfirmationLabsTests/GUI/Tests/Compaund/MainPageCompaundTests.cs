using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Application.Compaund;


namespace ConfirmationLabsTests.GUI.Tests.Compaund
{

    [TestFixture]
    class MainPageCompaundTests
    {

        [SetUp]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [Category("Compaund")]
        [Test]
        public void PageisOpenedTest()
        {
            MainPageCompaund.VerifyPageisOpened();
        }

        

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

    }
}
