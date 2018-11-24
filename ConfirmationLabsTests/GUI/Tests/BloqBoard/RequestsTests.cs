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
            MainPageBB.VerifyNewRequestCanbeCreated();
        }

        [Category("Cancel")]
        [Category("BlqRequests")]
        [Test]
        public void CancelRequestTest()
        {
            MainPageBB.VerifyRequestCanbeCancelled();
        }

        [Category("Lend")]
        [Category("BlqRequests")]
        [Test]
        public void LendRequestTest()
        {
            MainPageBB.VerifyRequestCanBeLended();
        }

        [Category("Repay")]
        [Category("BlqRequests")]
        [Test]
        public void RepayFunctionalityTest()
        {
            MainPageBB.VerifyRepayFunctionality();
        }

        [Category("Return")]
        [Category("BlqRequests")]
        [Test]
        public void ReturnCollateralTest()
        {
            MainPageBB.VerifyCollatrealCanbeReturned();
        }

        [Category("Seize")]
        [Category("BlqRequests")]
        [Test]
        public void SeizeCollateralTest()
        {
            MainPageBB.VerifyCollateralCanBeSeized();
        }


        [Category("Bloqboard")]
        [Test]
        public void RequestWithBATCreationTest()
        {
            MainPageBB.VerifyRequestwithBatCreation();
        }



        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
