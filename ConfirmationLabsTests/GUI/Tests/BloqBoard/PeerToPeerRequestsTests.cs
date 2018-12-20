using System;
using System.Diagnostics;
using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.Helpers;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    public class PeerToPeerRequestsTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        #region STAGING_Kovan
        [Category("Borrow_sk")]
        [Category("BlqRequests_sk")]
        [Category("OFRSlndRequests_sk")]
        [Test]
        public void OfferMyOwnBorrowTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewBorrowRequestCanBeCreated, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Cancel_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void CancelRequestTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRequestCanbeCancelled, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("BlqRequests_sk")]
        [Test]
        public void LendRequestTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRequestCanBeLended, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void RepayFunctionalityTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRepayFunctionality, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Return_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void ReturnCollateralTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollatrealCanbeReturned, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Seize_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void SeizeCollateralTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollateralCanBeSeized, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Borrow_sm")]
        [Category("BlqRequests_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void OfferMyOwnBorrowTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewBorrowRequestCanBeCreated, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Cancel_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void CancelRequestTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRequestCanbeCancelled, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("BlqRequests_sm")]
        [Test]
        public void LendRequestTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRequestCanBeLended, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void RepayFunctionalityTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRepayFunctionality, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Return_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void ReturnCollateralTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollatrealCanbeReturned, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Seize_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void SeizeCollateralTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollateralCanBeSeized, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("Borrow_pm")]
        [Category("BlqRequests_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void OfferMyOwnBorrowTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyNewBorrowRequestCanBeCreated, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Cancel_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void CancelRequestTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRequestCanbeCancelled, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("BlqRequests_pm")]
        [Test]
        public void LendRequestTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRequestCanBeLended, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void RepayFunctionalityTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRepayFunctionality, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Return_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void ReturnCollateralTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollatrealCanbeReturned, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Seize_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void SeizeCollateralTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollateralCanBeSeized, 3, TestReInitialize);
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
