using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.Helpers;
using ConfirmationLabsTests.GUI.Application.LoanScan;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan
{
    [TestFixture]
    class LoanScanMainPageTests
    {
        
            [SetUp]
            public void TestInitialize()
            {
                Browser.Start();
            }

            [Category("Healthcheck")]
            [Test]
            public void SeacrhAvailabilityTest()
            {
                MainPage.SearchAvailability();
            }

            [Category("Healthcheck")]
            [Test]
            public void SearchFunctionalityTest()
            {
                MainPage.SearchFunctionality();
            }

            [Category("Healthcheck")]
            [Test]
            public void FilteringTableFunctionalityTest()
            {
                MainPage.FilteringTable();
            }

            [Category("Healthcheck")]
            [Test]
            public void PaginationTest()
            {
                MainPage.PaginationTable();
            }

            [Category("Healthcheck")]
            [Test]
            public void ColumnsAvailabilityTest()
            {
                MainPage.ColumnsTable();
            }

            [Category("Healthcheck")]
            [Test]
            public void CurrencySwitcherTest()
            {
                MainPage.CurrencySwtichingTest();
            }


            [Category("Healthcheck")]
            [Test]
            public void LendingProtocolSwitchTest()
            {
                MainPage.LendingProtocolSwitch();
            }


            [Category("Healthcheck")]
            [Test]
            public void TermSwitchingTest()
            {
                MainPage.TermSwitchingFunctionality();
            }

            [Category("Healthcheck")]
            [Test]
            public void ChartTabsAvailabilityTest()
            {
               MainPage.ChartTabsAvailability();
            }




            [TearDown]
            public void TestCleanUp()
            {
                Browser.Close();
            }
        }
    
}
