using System;
using System.Diagnostics;
using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

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
            MainPageBb.VerifyNewBorrowRequestCanBeCreated();
        }

        [Ignore("Fix after redesign")]
        [Category("Cancel_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void CancelRequestTest_sk()
        {
            MainPageBb.VerifyRequestCanbeCancelled();
        }

        [Ignore("Fix after redesign")]
        [Category("BlqRequests_sk")]
        [Test]
        public void LendRequestTest_sk()
        {
            MainPageBb.VerifyRequestCanBeLended();
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void RepayFunctionalityTest_sk()
        {
            MainPageBb.VerifyRepayFunctionality();
        }

        [Ignore("Fix after redesign")]
        [Category("Return_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void ReturnCollateralTest_sk()
        {
            MainPageBb.VerifyCollatrealCanbeReturned();
        }

        [Ignore("Fix after redesign")]
        [Category("Seize_sk")]
        [Category("BlqRequests_sk")]
        [Test]
        public void SeizeCollateralTest_sk()
        {
            MainPageBb.VerifyCollateralCanBeSeized();
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Borrow_sm")]
        [Category("BlqRequests_sm")]
        [Category("OFRSlndRequests_sm")]
        [Test]
        public void OfferMyOwnBorrowTest_sm()
        {
            MainPageBb.VerifyNewBorrowRequestCanBeCreated();
        }

        [Ignore("Fix after redesign")]
        [Category("Cancel_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void CancelRequestTest_sm()
        {
            MainPageBb.VerifyRequestCanbeCancelled();
        }

        [Ignore("Fix after redesign")]
        [Category("BlqRequests_sm")]
        [Test]
        public void LendRequestTest_sm()
        {
            MainPageBb.VerifyRequestCanBeLended();
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void RepayFunctionalityTest_sm()
        {
            MainPageBb.VerifyRepayFunctionality();
        }

        [Ignore("Fix after redesign")]
        [Category("Return_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void ReturnCollateralTest_sm()
        {
            MainPageBb.VerifyCollatrealCanbeReturned();
        }

        [Ignore("Fix after redesign")]
        [Category("Seize_sm")]
        [Category("BlqRequests_sm")]
        [Test]
        public void SeizeCollateralTest_sm()
        {
            MainPageBb.VerifyCollateralCanBeSeized();
        }
        #endregion

        #region PROD_Mainnet
        [Category("Borrow_pm")]
        [Category("BlqRequests_pm")]
        [Category("OFRSlndRequests_pm")]
        [Test]
        public void OfferMyOwnBorrowTest_pm()
        {
            MainPageBb.VerifyNewBorrowRequestCanBeCreated();
        }

        [Ignore("Fix after redesign")]
        [Category("Cancel_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void CancelRequestTest_pm()
        {
            MainPageBb.VerifyRequestCanbeCancelled();
        }

        [Ignore("Fix after redesign")]
        [Category("BlqRequests_pm")]
        [Test]
        public void LendRequestTest_pm()
        {
            MainPageBb.VerifyRequestCanBeLended();
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void RepayFunctionalityTest_pm()
        {
            MainPageBb.VerifyRepayFunctionality();
        }

        [Ignore("Fix after redesign")]
        [Category("Return_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void ReturnCollateralTest_pm()
        {
            MainPageBb.VerifyCollatrealCanbeReturned();
        }

        [Ignore("Fix after redesign")]
        [Category("Seize_pm")]
        [Category("BlqRequests_pm")]
        [Test]
        public void SeizeCollateralTest_pm()
        {
            MainPageBb.VerifyCollateralCanBeSeized();
        }
        #endregion

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
