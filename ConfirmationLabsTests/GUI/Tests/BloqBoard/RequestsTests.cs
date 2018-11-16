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

        [Category("BlqRequests")]
        [Test]
        public void CreateNewRequestTest()
        {
            MainPageBB.VerifyNewRequestCanbeCreated();
        }

        [Category("BlqRequests")]
        [Test]
        public void CancelRequestTest()
        {
            MainPageBB.VerifyRequestCanbeCancelled();
        }

        [Category("BlqRequests")]
        [Test]
        public void LendRequestTest()
        {
            MainPageBB.VerifyRequestCanBeLended();
        }

        [Category("BlqRequests")]
        [Test]
        public void RepayFunctionalityTest()
        {
            MainPageBB.VerifyRepayFunctionality();
        }

        [Category("BlqRequests")]
        [Test]
        public void ReturnCollateralTest()
        {
            MainPageBB.VerifyCollatrealCanbeReturned();
        }

        [Category("BlqRequests")]
        [Test]
        public void SeizeCollateralTest()
        {
            MainPageBB.VerifyCollateralCanBeSeized();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
