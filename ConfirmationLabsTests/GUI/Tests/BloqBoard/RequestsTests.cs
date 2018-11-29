using System;
using System.Diagnostics;
using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    public class RequestsTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("Create")]
        [Category("BlqRequests")]
        [Test]
        public void CreateNewRequestTest()
        {
            MainPageBb.VerifyNewRequestCanbeCreated();
        }

        [Category("Cancel")]
        [Category("BlqRequests")]
        [Test]
        public void CancelRequestTest()
        {
            MainPageBb.VerifyRequestCanbeCancelled();
        }

        [Category("Lend")]
        [Category("BlqRequests")]
        [Test]
        public void LendRequestTest()
        {
            MainPageBb.VerifyRequestCanBeLended();
        }

        [Category("Repay")]
        [Category("BlqRequests")]
        [Test]
        public void RepayFunctionalityTest()
        {
            MainPageBb.VerifyRepayFunctionality();
        }

        [Category("Return")]
        [Category("BlqRequests")]
        [Test]
        public void ReturnCollateralTest()
        {
            MainPageBb.VerifyCollatrealCanbeReturned();
        }

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
