using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.GUI.Engine;
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
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void OfferMyOwnLendTest_sk()
        {
            MainPageBb.VerifyNewOfferToLendCanBeCreated();
        }

        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void BorrowAlreadyExsistantLoanTest_sk()
        {
            MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed();
        }

        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void LendToAlreadyExsistantBorrowTestTest_sk()
        {
            MainPageBb.VerifyNewlyCreatedRequestToBorrowCanBeLend();
        }

        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckMyPendingBorrowingOfferConsistanceTest_sk()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckAlreadyBorrowedConsistanceTest()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Borrow_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckBorrowOfferFromLenderSideEtoE_sk()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckMyPendingLendingOfferConsistanceTest_sk()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckAlreadyLoanedConsistanceTest_sk()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void CheckLendingOfferFromBorrowerSideEtoE_sk()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void OfferMyOwnLendTest_sm()
        {
            MainPageBb.VerifyNewOfferToLendCanBeCreated();
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void BorrowAlreadyExsistantLoanTest_sm()
        {
            MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed();
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void LendToAlreadyExsistantBorrowTestTest_sm()
        {
            MainPageBb.VerifyNewlyCreatedRequestToBorrowCanBeLend();
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckMyPendingBorrowingOfferConsistanceTest_sm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckAlreadyBorrowedConsistanceTest_sm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Borrow_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckBorrowOfferFromLenderSideEtoE_sm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckMyPendingLendingOfferConsistanceTest_sm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckAlreadyLoanedConsistanceTest_sm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void CheckLendingOfferFromBorrowerSideEtoE_sm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }
        #endregion

        #region PROD_Mainnet
        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void OfferMyOwnLendTest_pm()
        {
            MainPageBb.VerifyNewOfferToLendCanBeCreated();
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void BorrowAlreadyExsistantLoanTest_pm()
        {
            MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed();
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void LendToAlreadyExsistantBorrowTestTest_pm()
        {
            MainPageBb.VerifyNewlyCreatedRequestToBorrowCanBeLend();
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckMyPendingBorrowingOfferConsistanceTest_pm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckAlreadyBorrowedConsistanceTest_pm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Borrow_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckBorrowOfferFromLenderSideEtoE_pm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckMyPendingLendingOfferConsistanceTest_pm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckAlreadyLoanedConsistanceTest_pm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [Category("Lend_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void CheckLendingOfferFromBorrowerSideEtoE_pm()
        {
            //MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }
        #endregion

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
