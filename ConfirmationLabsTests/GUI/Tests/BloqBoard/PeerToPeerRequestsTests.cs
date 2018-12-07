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

        //https://staging.bloqboard.com/add-request-to-borrow
        //Add your request to borrow (WETH maze)
        //You don't have enough REP for collateral. Please transfer additional REP to your wallet or use different type of collateral.
        [Category("Borrow")]
        [Category("Create")]
        [Category("BlqRequests")]
        [Test]
        public void AddBorrowRequestTest()
        {
            MainPageBb.VerifyNewBorrowRequestCanBeCreated();
        }

        [Ignore("Fix after redesign")]
        [Category("Cancel")]
        [Category("BlqRequests")]
        [Test]
        public void CancelRequestTest()
        {
            MainPageBb.VerifyRequestCanbeCancelled();
        }

        [Ignore("Fix after redesign")]
        [Category("BlqRequests")]
        [Test]
        public void LendRequestTest()
        {
            MainPageBb.VerifyRequestCanBeLended();
        }

        [Ignore("Fix after redesign")]
        [Category("Repay")]
        [Category("BlqRequests")]
        [Test]
        public void RepayFunctionalityTest()
        {
            MainPageBb.VerifyRepayFunctionality();
        }

        [Ignore("Fix after redesign")]
        [Category("Return")]
        [Category("BlqRequests")]
        [Test]
        public void ReturnCollateralTest()
        {
            MainPageBb.VerifyCollatrealCanbeReturned();
        }

        [Ignore("Fix after redesign")]
        [Category("Seize")]
        [Category("BlqRequests")]
        [Test]
        public void SeizeCollateralTest()
        {
            MainPageBb.VerifyCollateralCanBeSeized();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
