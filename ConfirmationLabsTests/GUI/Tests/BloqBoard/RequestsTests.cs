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

        [Category("Bloqboard")]
        [Test]
        public void CreateNewRequestTest()
        {
            MainPageBB.VerifyNewRequestCanbeCreated();
        }

        [Ignore("BLQ-366 Issue with cancel table")]
        [Category("Bloqboard")]
        [Test]
        public void CancelRequestTest()
        {
            MainPageBB.VerifyRequestCanbeCancelled();
        }

        [Category("Bloqboard")]
        [Test]
        public void LendRequestTest()
        {
            MainPageBB.VerifyRequestCanBeLended();
        }

        [Ignore("Presetup needed")]
        [Category("Bloqboard")]
        [Test]
        public void RepayFunctionalityTest()
        {
            MainPageBB.VerifyRepayFunctionality();
        }

        [Ignore("Presetup needed")]
        [Category("Bloqboard")]
        [Test]
        public void ReturnCollateralTest()
        {
            MainPageBB.VerifyCollatrealCanbeReturned();
        }

        [Ignore("BLQ-368 Issue with seize collateral")]
        [Category("Bloqboard")]
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
