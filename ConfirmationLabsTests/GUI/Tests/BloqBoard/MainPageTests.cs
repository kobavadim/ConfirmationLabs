using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.Helpers;

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

        #region STAGING_Kovan
        [Category("Bloqboard_sk")]
        [Test]
        public void BloqBoardPageisOpenedTest_sk()
        {
            MainPageBb.VerifyPageisOpened();
            TestRetrier.RunWithRetry(MainPageBb.VerifyPageisOpened, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void TokensTableDisplayedTest_sk()
        {
            MainPageBb.VerifyTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void RecentLoansTableDisplayedTest_sk()
        {
            MainPageBb.VerifyRecentLoansTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyRecentLoansTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void LoanTableDisplayedTest_sk()
        {
            MainPageBb.VerifyLoanTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLoanTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void LendToPoolTableDisplayedTest_sk()
        {
            MainPageBb.VerifyLendToPoolTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLendToPoolTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void AssetsTableDisplayTest_sk()
        {
            MainPageBb.VerifyAssetsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyAssetsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void MyBorrowedTokenstableDisplayTest_sk()
        {
            MainPageBb.VerifyMyBorrowedTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyBorrowedTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void MyLendedTokenstableDisplayTest_sk()
        {
            MainPageBb.VerifyMyLendedTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyLendedTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void MyOpenRequestsTableDisplayTest_sk()
        {
            MainPageBb.VerifyMyOpenRequestsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyOpenRequestsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void MyCancelledRequestsTableDisplayTest_sk()
        {
            MainPageBb.VerifyMyCancelledRequestsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyCancelledRequestsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sk")]
        [Test]
        public void OpeningCardfromBloqBoardTest_sk()
        {
            MainPageBb.VerifyLoanScanCardisOpenedfromBloqBoard();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLoanScanCardisOpenedfromBloqBoard, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Bloqboard_sm")]
        [Test]
        public void BloqBoardPageisOpenedTest_sm()
        {
            MainPageBb.VerifyPageisOpened();
            TestRetrier.RunWithRetry(MainPageBb.VerifyPageisOpened, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void TokensTableDisplayedTest_sm()
        {
            MainPageBb.VerifyTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void RecentLoansTableDisplayedTest_sm()
        {
            MainPageBb.VerifyRecentLoansTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyRecentLoansTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void LoanTableDisplayedTest_sm()
        {
            MainPageBb.VerifyLoanTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLoanTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void LendToPoolTableDisplayedTest_sm()
        {
            MainPageBb.VerifyLendToPoolTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLendToPoolTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void AssetsTableDisplayTest_sm()
        {
            MainPageBb.VerifyAssetsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyAssetsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void MyBorrowedTokenstableDisplayTest_sm()
        {
            MainPageBb.VerifyMyBorrowedTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyBorrowedTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void MyLendedTokenstableDisplayTest_sm()
        {
            MainPageBb.VerifyMyLendedTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyLendedTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void MyOpenRequestsTableDisplayTest_sm()
        {
            MainPageBb.VerifyMyOpenRequestsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyOpenRequestsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void MyCancelledRequestsTableDisplayTest_sm()
        {
            MainPageBb.VerifyMyCancelledRequestsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyCancelledRequestsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_sm")]
        [Test]
        public void OpeningCardfromBloqBoardTest_sm()
        {
            MainPageBb.VerifyLoanScanCardisOpenedfromBloqBoard();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLoanScanCardisOpenedfromBloqBoard, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("Bloqboard_pm")]
        [Test]
        public void BloqBoardPageisOpenedTest_pm()
        {
            MainPageBb.VerifyPageisOpened();
            TestRetrier.RunWithRetry(MainPageBb.VerifyPageisOpened, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void TokensTableDisplayedTest_pm()
        {
            MainPageBb.VerifyTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void RecentLoansTableDisplayedTest_pm()
        {
            MainPageBb.VerifyRecentLoansTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyRecentLoansTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void LoanTableDisplayedTest_pm()
        {
            MainPageBb.VerifyLoanTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLoanTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void LendToPoolTableDisplayedTest_pm()
        {
            MainPageBb.VerifyLendToPoolTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLendToPoolTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void AssetsTableDisplayTest_pm()
        {
            MainPageBb.VerifyAssetsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyAssetsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void MyBorrowedTokenstableDisplayTest_pm()
        {
            MainPageBb.VerifyMyBorrowedTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyBorrowedTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void MyLendedTokenstableDisplayTest_pm()
        {
            MainPageBb.VerifyMyLendedTokensTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyLendedTokensTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void MyOpenRequestsTableDisplayTest_pm()
        {
            MainPageBb.VerifyMyOpenRequestsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyOpenRequestsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void MyCancelledRequestsTableDisplayTest_pm()
        {
            MainPageBb.VerifyMyCancelledRequestsTableDisplayed();
            TestRetrier.RunWithRetry(MainPageBb.VerifyMyCancelledRequestsTableDisplayed, 3, TestReInitialize);
        }

        [Category("Bloqboard_pm")]
        [Test]
        public void OpeningCardfromBloqBoardTest_pm()
        {
            MainPageBb.VerifyLoanScanCardisOpenedfromBloqBoard();
            TestRetrier.RunWithRetry(MainPageBb.VerifyLoanScanCardisOpenedfromBloqBoard, 3, TestReInitialize);
        }
        #endregion

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

        private void TestReInitialize()
        {
            TestCleanUp();
            TestInitialize();
        }
    }
}
