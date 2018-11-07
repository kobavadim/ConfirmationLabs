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
            MainPageBB.VerifyPageisOpened();
        }

        [Category("Bloqboard")]
        [Test]
        public void TokensTableDisplayedTest()
        {
            MainPageBB.VerifyTokensTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void RecentLoansTableDisplayedTest()
        {
            MainPageBB.VerifyRecentLoansTableDisplayed();  
        }

        [Category("Bloqboard")]
        [Test]
        public void LoanTableDisplayedTest()
        {
            MainPageBB.VerifyLoanTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void LendToPoolTableDisplayedTest()
        {
            MainPageBB.VerifyLendToPoolTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void AssetsTableDisplayTest()
        {
            MainPageBB.VerifyAssetstableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyBorrowedTokenstableDisplayTest()
        {
            MainPageBB.VerifyMyBorrowedTokensTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyLendedTokenstableDisplayTest()
        {
            MainPageBB.VerifyMyLendedTokensTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyOpenRequestsTableDisplayTest()
        {
            MainPageBB.VerifyMyOpenRequestsTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void MyCancelledRequestsTableDisplayTest()
        {
            MainPageBB.VerifyMyCancelledRequestsTableDisplayed();
        }

        [Category("Bloqboard")]
        [Test]
        public void OpeningCardfromBloqBoardTest()
        {
            MainPageBB.VerifyLoanScanCardisOpenedfromBloqBoard();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
