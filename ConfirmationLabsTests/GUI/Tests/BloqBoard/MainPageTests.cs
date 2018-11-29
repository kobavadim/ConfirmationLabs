using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    public class MainPageTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("Bloqboard")]
        [Test]
        public void BloqBoardPageisOpenedTest()
        {
            MainPageBb.VerifyPageisOpened();
        }

        [Category("Bloqboard")]
        [Test]
        public void TokensTableDisplayedTest()
        {
            MainPageBb.VerifyTokensTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void RecentLoansTableDisplayedTest()
        {
            MainPageBb.VerifyRecentLoansTableDisplayed();  
        }

        [Category("Bloqboard")]
        [Test]
        public void LoanTableDisplayedTest()
        {
            MainPageBb.VerifyLoanTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void LendToPoolTableDisplayedTest()
        {
            MainPageBb.VerifyLendToPoolTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void AssetsTableDisplayTest()
        {
            MainPageBb.VerifyAssetsTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyBorrowedTokenstableDisplayTest()
        {
            MainPageBb.VerifyMyBorrowedTokensTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyLendedTokenstableDisplayTest()
        {
            MainPageBb.VerifyMyLendedTokensTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyOpenRequestsTableDisplayTest()
        {
            MainPageBb.VerifyMyOpenRequestsTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyCancelledRequestsTableDisplayTest()
        {
            MainPageBb.VerifyMyCancelledRequestsTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void OpeningCardfromBloqBoardTest()
        {
            MainPageBb.VerifyLoanScanCardisOpenedfromBloqBoard();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
