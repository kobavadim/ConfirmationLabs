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

        [Category("BlqTest")]
        [Test]
        public void TestForTeamCity()
        {
            Console.WriteLine("TC test");
        }

        [Category("BlqRequestCreate")]
        [Test]
        public void CreateNewRequestTest()
        {
            MainPageBB.VerifyNewRequestCanbeCreated();
        }

        [Category("BlqRequestCreate")]
        [Test]
        public void CancelRequestTest()
        {
            MainPageBB.VerifyRequestCanbeCancelled();
        }

        [Ignore("Presetup needed")]
        [Category("BlqRequest")]
        [Test]
        public void LendRequestTest()
        {
            MainPageBB.VerifyRequestCanBeLended();
        }

        [Ignore("Presetup needed")]
        [Category("BlqRequest")]
        [Test]
        public void RepayFunctionalityTest()
        {
            MainPageBB.VerifyRepayFunctionality();
        }

        [Ignore("Presetup needed")]
        [Category("BlqRequest")]
        [Test]
        public void ReturnCollateralTest()
        {
            MainPageBB.VerifyCollatrealCanbeReturned();
        }

        [Ignore("BLQ-368 Issue with seize collateral")]
        [Category("BlqRequest")]
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
