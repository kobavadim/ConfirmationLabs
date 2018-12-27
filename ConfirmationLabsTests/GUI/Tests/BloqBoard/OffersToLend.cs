using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.Helpers;
using NUnit.Framework;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    public class OffersToLend
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        #region STAGING_Kovan
        [Category("Lend_sk")]
        [Category("BlqRequests_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void OfferMyOwnLendTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewOfferToLendCanBeCreated, 3, TestReInitialize);
        }

        //[Ignore("No predefined data")]
        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void BorrowAlreadyExsistantLoanTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed, 3, TestReInitialize);
        }

        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void LendToAlreadyExsistantBorrowTestTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewlyCreatedRequestToBorrowCanBeLend, 3, TestReInitialize);
        }

        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckMyPendingBorrowingOfferConsistanceTest_sk()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckAlreadyBorrowedConsistanceTest()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckBorrowOfferFromLenderSideEtoE_sk()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckMyPendingLendingOfferConsistanceTest_sk()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Ignore("Predefined request expected")]
        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckAlreadyLoanedConsistanceTest_sk()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckLendingOfferFromBorrowerSideEtoE_sk()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void OfferMyOwnLendTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyNewOfferToLendCanBeCreated, 3, TestReInitialize);
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void BorrowAlreadyExsistantLoanTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed, 3, TestReInitialize);
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void LendToAlreadyExsistantBorrowTestTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyNewlyCreatedRequestToBorrowCanBeLend, 3, TestReInitialize);
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckMyPendingBorrowingOfferConsistanceTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckAlreadyBorrowedConsistanceTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckBorrowOfferFromLenderSideEtoE_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckMyPendingLendingOfferConsistanceTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckAlreadyLoanedConsistanceTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckLendingOfferFromBorrowerSideEtoE_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void OfferMyOwnLendTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewOfferToLendCanBeCreated, 3, TestReInitialize);
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void BorrowAlreadyExsistantLoanTest_pm()
        {
            Browser.LongPause();
            Browser.LongPause();
            //TestRetrier.RunWithRetry(MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed, 3, TestReInitialize);
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void LendToAlreadyExsistantBorrowTestTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewlyCreatedRequestToBorrowCanBeLend, 3, TestReInitialize);
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckMyPendingBorrowingOfferConsistanceTest_pm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckAlreadyBorrowedConsistanceTest_pm()
        {
            Browser.LongPause();
            Browser.LongPause();
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckBorrowOfferFromLenderSideEtoE_pm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckMyPendingLendingOfferConsistanceTest_pm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckAlreadyLoanedConsistanceTest_pm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckLendingOfferFromBorrowerSideEtoE_pm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests, 3, TestReInitialize);
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
