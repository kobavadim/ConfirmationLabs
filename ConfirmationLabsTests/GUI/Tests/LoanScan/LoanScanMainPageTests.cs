using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
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

            [Category("Loanscan")]
            [Test]
            public void SeacrhAvailabilityTest()
            {
                MainPage.SearchAvailability();
            }

            [Category("Loanscan")]
            [Test]
            public void SearchFunctionalityTest()
            {
                MainPage.SearchFunctionality();
            }

            [Ignore("BUG")]
            [Test]
            public void FilteringTableFunctionalityTest()
            {
                MainPage.FilteringTable();
            }

            [Ignore("BUG")]
            [Test]
            public void PaginationTest()
            {
                MainPage.PaginationTable();
            }

            [Category("Loanscan")]
            [Test]
            public void ColumnsAvailabilityTest()
            {
                MainPage.ColumnsTable();
            }

            [Category("Loanscan")]
            [Test]
            public void CurrencySwitcherTest()
            {
                MainPage.CurrencySwtichingTest();
            }


            [Ignore("BUG")]
            [Test]
            public void LendingProtocolSwitchTest()
            {
                MainPage.LendingProtocolSwitch();
            }


            [Category("Loanscan")]
            [Test]
            public void TermSwitchingTest()
            {
                MainPage.TermSwitchingFunctionality();
            }

            [Category("Loanscan")]
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
