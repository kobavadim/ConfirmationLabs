using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.LoanScan;




namespace ConfirmationLabsTests.GUI.Tests.LoanScan
{


    [TestFixture]

    class LoanScanMobileTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartMobile();
        }

        [Category("LoanscanMobile")]
        [Test]
        public void CurrencyDisplayMobileTest()
        {
           LoanScanMobile.VerifyCurrencySwitchedonMobile();
        }

        [Category("LoanscanMobile")]
        [Test]
        public void LandingProtocolSwitchMobileTest()
        {
            LoanScanMobile.VerifyLendingProtocolsAvailability();
        }

        [Category("LoanscanMobile")]
        [Test]
        public void TermSwitchMobileTest()
        {
            LoanScanMobile.VerifyTermSwitch();
        }

        [Category("LoanscanMobile")]
        [Test]
        public void SearchFunctionalityMobileTest()
        {
            LoanScanMobile.VerifySearchPerformed();
        }

        [Category("LoanscanMobile")]
        [Test]
        public void PaginationMobileTest()
        {
            LoanScanMobile.VerifyPagination();
        }

        [Category("LoanscanMobile")]
        [Test]
        public void CardOpeningMobileTest()
        {
            LoanScanMobile.VerifySingleCardOpening();
        }


        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
